using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;

namespace Negocio
{
    public class Interpolador : IInterpolador
    {
        #region Atributos

        /*
            1 EXPONENCIAL         
            2 LINEAR              
            3 FATOR DIARIO        
            4 PU                  
            5 CONSTANTE           
            6 CUBIC SPLINE        
            7 TAX
             */
        public const int VERTICE_INTERPOLACAO_FATOR_DIARIO = 3;
        public const int VERTICE_INTERPOLACAO_PU = 4;
        public const int VERTICE_INTERPOLACAO_TAXA = 7;

        public const int METODO_AJUST_BASEFATOR = 6;
        public const int METODO_AJUST_BASETAXA= 7;


        public const int EXPONENCIAL = 1;
        public const int LINEAR = 2;
        public const int CONSTANTE = 5;
        public const int CUBIC_SPLINE = 6;
        public const int NA = 8; 

        public const int BASE_252 = 252;
        public const int BASE_360 = 360;
        public const int BASE_30 = 30;

        #endregion

        #region Metodos

        public IList<CurvaExecucaoPonto> InterpolarTunel(IList<CurvaExecucaoPonto> vertices, Double taxaOver, DateTime dataBase, int extensaoDiasCorridos, int antepolacaoID, int interpolacaoID, int extrapolacaoID, int baseDias, int tipoVerticeInterpolacao)
        {
            IEnumerable<CurvaExecucaoPonto> EnumList = vertices.OrderBy(f => f.QuantidadeDiasCorridos);
            vertices = EnumList.ToList();

            DateTime DataFinalVertices = dataBase.AddDays(extensaoDiasCorridos);

            CalendarioReguaBS calRegua = new CalendarioReguaBS(dataBase, DataFinalVertices);

            return Interpolar(ref vertices, taxaOver, ref dataBase, antepolacaoID, interpolacaoID, extrapolacaoID, baseDias, tipoVerticeInterpolacao, calRegua);
        }

        public virtual IList<CurvaExecucaoPonto> Interpola(IList<CurvaExecucaoPonto> vertices, Double taxaOver, DateTime dataBase, int dataMaxGeracaoCurva, int antepolacaoID, int interpolacaoID, int extrapolacaoID, int baseDias, int tipoVerticeInterpolacao)
        {
            IEnumerable<CurvaExecucaoPonto> EnumList = vertices.OrderBy(f => f.QuantidadeDiasCorridos);
            vertices = EnumList.ToList();

            ServicoBloomberg.ServicoConsultarPrecoClient clienteBloomberg = new ServicoBloomberg.ServicoConsultarPrecoClient();
            double valorBloomberg = clienteBloomberg.Consultar(string.Empty);

            ServicoReuters.ServicoConsultarPrecoClient clienteReuters = new ServicoReuters.ServicoConsultarPrecoClient();
            double valorReuters = clienteReuters.Consultar(string.Empty);

            CalendarioReguaBS calRegua;

            int QteDiasCorridos_Vertice = vertices[vertices.Count - 1].QuantidadeDiasCorridos;
            DateTime DataFinal = dataBase.AddYears(dataMaxGeracaoCurva);
            DateTime DataFinalVertices = dataBase.AddDays(QteDiasCorridos_Vertice);

            //verifica se o prazo em dias corridos informado no ultimo vertice da curva é maior que a extensão da curva.
            if (DataFinalVertices > DataFinal)
            {
                calRegua = new CalendarioReguaBS(dataBase, DataFinalVertices);
            }
            else
            {
                calRegua = new CalendarioReguaBS(dataBase, DataFinal);
            }

            return Interpolar(ref vertices, taxaOver, ref dataBase, antepolacaoID, interpolacaoID, extrapolacaoID, baseDias, tipoVerticeInterpolacao, calRegua);
        }

        private IList<CurvaExecucaoPonto> Interpolar(ref IList<CurvaExecucaoPonto> vertices, Double taxaOver, ref DateTime dataBase, int antepolacaoID, int interpolacaoID, int extrapolacaoID, int baseDias, int tipoVerticeInterpolacao, CalendarioReguaBS calRegua)
        {
            IList<CurvaExecucaoPonto> curvaInterpolada;

            try
            {
                if (antepolacaoID == NA)
                {
                    return vertices;
                }

                int QteDC_Curva = calRegua.NumeroMaxDiasCorridos;
                curvaInterpolada = new List<CurvaExecucaoPonto>(QteDC_Curva);

                for (int index = 0; index < QteDC_Curva; index++)
                {
                    bool isVertice = false;
                    CurvaExecucaoPonto pontoCurva = new CurvaExecucaoPonto();

                    //Verifica na lista de vertices se o ponto atual é um vertice.
                    foreach (CurvaExecucaoPonto item in vertices)
                    {
                        if (item.QuantidadeDiasCorridos == index)
                        {
                            isVertice = true;
                            pontoCurva = item;
                            pontoCurva.QuantidadeDiasCorridos = index;
                            pontoCurva.DataVencimento = dataBase.AddDays(index);
                            pontoCurva.QuantidadeDiasUteis = calRegua.ObterQuantidadeDiasUteis(pontoCurva.DataVencimento.ToString("yyyyMMdd"));
                        }
                    }

                    //Se não for vertice inclui as informações da curva.
                    if (!isVertice)
                    {
                        pontoCurva.DataVencimento = dataBase.AddDays(index);
                        pontoCurva.QuantidadeDiasCorridos = index;
                        pontoCurva.QuantidadeDiasUteis = calRegua.ObterQuantidadeDiasUteis(pontoCurva.DataVencimento.ToString("yyyyMMdd"));
                    }
                    curvaInterpolada.Add(pontoCurva);
                }

                ConversorTaxasBS conversor = new ConversorTaxasBS();

                if (antepolacaoID == EXPONENCIAL)
                {
                    AntepolacaoExponencial(vertices, dataBase, baseDias, curvaInterpolada);
                }
                else if (antepolacaoID == LINEAR)
                {
                    AntepolacaoLinear(vertices, dataBase, baseDias,  curvaInterpolada);
                }
                
                if (interpolacaoID == EXPONENCIAL)
                {
                    InterpolacaoExponencial(vertices, dataBase, baseDias, curvaInterpolada);
                }
                else if (interpolacaoID == LINEAR)
                {
                    InterpolacaoLinear(vertices, dataBase, baseDias, curvaInterpolada);
                }
                //else if (interpolacaoID == CUBIC_SPLINE)
                //{
                //    listaInterpolacao = InterpolacaoCubicSpline(vertices);
                //}

                if (extrapolacaoID == EXPONENCIAL)
                {
                    ExtrapolacaoExponencial(vertices, dataBase, baseDias, curvaInterpolada);
                }
                else if (extrapolacaoID == LINEAR)
                {
                    ExtrapolacaoLinear(vertices, dataBase, baseDias, curvaInterpolada);
                }

                return curvaInterpolada.ToList();
            }
            finally
            {
                calRegua.Dispose();
                calRegua = null;
            }
        }

        public void AjustarTaxaParaPontosEmDiasNaoUteis(ref IList<CurvaExecucaoPonto> listaVertices, int CodigoModeloCalculo, int tipoVerticeInterpolacao, int interpolacaoID, int baseDias)
        {
            int duAnt = 0;
            if (CodigoModeloCalculo == METODO_AJUST_BASEFATOR || CodigoModeloCalculo == METODO_AJUST_BASETAXA)
            {
                ConversorTaxasBS conversor = new ConversorTaxasBS();

                if (CodigoModeloCalculo == METODO_AJUST_BASEFATOR)
                {

                    if (tipoVerticeInterpolacao == VERTICE_INTERPOLACAO_TAXA && interpolacaoID == LINEAR)
                    {
                        //taxaOver = vertices[0].ValorVertice;
                        listaVertices = conversor.ConverterTaxasLinearesParaFatorDiario(listaVertices, baseDias);
                    }
                    else if (tipoVerticeInterpolacao == VERTICE_INTERPOLACAO_TAXA && interpolacaoID == EXPONENCIAL)
                    {
                        //Se tipo de vertice para interpolacao for TAXA e o tipo de interpolacao for Exponencial converter a taxa para fator diário.
                        listaVertices = conversor.ConverterTaxasExponenciaisParaFatorDiario(listaVertices, baseDias);
                    }
                }
            
                for (int i = 0; i < listaVertices.Count; i++)
                {
                    CurvaExecucaoPonto pontoCurva = listaVertices[i];

                    //Se quantidade de dias uteis é igual à quantidade de dias uteis anterior, então não é um dia util. 
                    if (pontoCurva.QuantidadeDiasUteis == duAnt && duAnt != 0)
                    {
                        for (int j = i + 1; j < listaVertices.Count; j++)
                        {
                            if (listaVertices[j].QuantidadeDiasUteis == duAnt + 1)
                            {
                                duAnt = pontoCurva.QuantidadeDiasUteis;
                                //pontoCurva.QuantidadeDiasUteis = listaVertices[j].QuantidadeDiasUteis;
                                pontoCurva.ValorVertice = listaVertices[j].ValorVertice;
                                break;
                            }
                        }
                    }
                    else
                    {
                        duAnt = pontoCurva.QuantidadeDiasUteis;
                    }
                }

                if (CodigoModeloCalculo == METODO_AJUST_BASEFATOR)
                {

                    if (tipoVerticeInterpolacao == VERTICE_INTERPOLACAO_TAXA && interpolacaoID == LINEAR)
                    {
                        //taxaOver = vertices[0].ValorVertice;
                        listaVertices = conversor.ConverteFatoresDiariosParaLinear(listaVertices, baseDias);
                    }
                    else if (tipoVerticeInterpolacao == VERTICE_INTERPOLACAO_TAXA && interpolacaoID == EXPONENCIAL)
                    {
                        listaVertices = conversor.ConverteFatoresDiariosExponenciais(listaVertices, baseDias);
                    }
                }
            }
            
        }

        private void AntepolacaoLinear(IList<CurvaExecucaoPonto> vertices, DateTime dataBase, int baseDias, IList<CurvaExecucaoPonto> curvaInterpolada)
        {

            int indPrimeiroPonto = 0;
            int indSegundoPonto = 1;

            int lPrazoProxFator = 0;
            int lPrazoFatorAnt = 0;

            if (baseDias == BASE_252)
            {
                lPrazoFatorAnt = vertices[indPrimeiroPonto].QuantidadeDiasUteis;
                lPrazoProxFator = vertices[indSegundoPonto].QuantidadeDiasUteis;
            }
            else
            {
                lPrazoFatorAnt = vertices[indPrimeiroPonto].QuantidadeDiasCorridos;
                lPrazoProxFator = vertices[indSegundoPonto].QuantidadeDiasCorridos;
            }

            for (int i = vertices[indPrimeiroPonto].QuantidadeDiasCorridos - 1; i > 0; i--)
            {
                //Calculo do Ponto Interpolado
                if (baseDias == BASE_252)
                {
                    //Calculo do Ponto
                    curvaInterpolada[i].ValorVertice = vertices[indPrimeiroPonto].ValorVertice -
                        (double) ((vertices[indSegundoPonto].ValorVertice - vertices[indPrimeiroPonto].ValorVertice) *
                        ((double)(lPrazoFatorAnt - curvaInterpolada[i].QuantidadeDiasUteis) / (lPrazoProxFator - lPrazoFatorAnt)));
                }
                else
                {
                    //Calculo do Ponto
                    curvaInterpolada[i].ValorVertice = vertices[indPrimeiroPonto].ValorVertice -
                       (double)((vertices[indSegundoPonto].ValorVertice - vertices[indPrimeiroPonto].ValorVertice) *
                       (double)(lPrazoFatorAnt - curvaInterpolada[i].QuantidadeDiasCorridos) / (lPrazoProxFator - lPrazoFatorAnt));
                }
            }
        }

        private void InterpolacaoLinear(IList<CurvaExecucaoPonto> vertices, DateTime dataBase, int baseDias, IList<CurvaExecucaoPonto> curvaInterpolada)
        {
            int iAnt, iProx;
            iProx = 0;
            iAnt = 0;

            for (int i = 0; i < vertices.Count; i++)
            {
                iProx = i;

                //Pula o Primeiro Fator
                if (iProx > 0)
                {
                    for (int j = vertices[iAnt].QuantidadeDiasCorridos + 1; j < (vertices[iProx].QuantidadeDiasCorridos); j++)
                    {
                        CurvaExecucaoPonto pontoCurva = new CurvaExecucaoPonto();

                        if (baseDias == BASE_252)
                        {
                            //Calcula o valor vertice no do ponto interpolado 
                            curvaInterpolada[j].ValorVertice = vertices[iAnt].ValorVertice + (vertices[iProx].ValorVertice - vertices[iAnt].ValorVertice) *
                                                            ((double)(curvaInterpolada[j].QuantidadeDiasUteis - vertices[iAnt].QuantidadeDiasUteis) /
                                                            (vertices[iProx].QuantidadeDiasUteis - vertices[iAnt].QuantidadeDiasUteis));
                        }
                        else
                        {

                            //Calcula o valor vertice no do ponto interpolado 
                            curvaInterpolada[j].ValorVertice = vertices[iAnt].ValorVertice + (vertices[iProx].ValorVertice - vertices[iAnt].ValorVertice) *
                                                            ((double)(curvaInterpolada[j].QuantidadeDiasCorridos - vertices[iAnt].QuantidadeDiasCorridos) /
                                                            (vertices[iProx].QuantidadeDiasCorridos - vertices[iAnt].QuantidadeDiasCorridos));
                        }
                    }
                }
                iAnt = iProx;
            }

        }

        private void ExtrapolacaoLinear(IList<CurvaExecucaoPonto> vertices, DateTime dataBase, int baseDias, IList<CurvaExecucaoPonto> curvaInterpolada)
        {
            int indUltimoPonto = vertices.Count - 1;
            int indPenultimoPonto = vertices.Count - 2;

            int lPrazoProxFator = 0;
            int lPrazoFatorAnt = 0;

            if (baseDias == BASE_252)
            {
                lPrazoProxFator = vertices[indUltimoPonto].QuantidadeDiasUteis;
                lPrazoFatorAnt = vertices[indPenultimoPonto].QuantidadeDiasUteis;
            }
            else
            {
                lPrazoProxFator = vertices[indUltimoPonto].QuantidadeDiasCorridos;
                lPrazoFatorAnt = vertices[indPenultimoPonto].QuantidadeDiasCorridos;
            }

            for (int i = vertices[indUltimoPonto].QuantidadeDiasCorridos + 1; i < curvaInterpolada.Count; i++)
            {
                //Calculo do Ponto Interpolado
                if (baseDias == BASE_252)
                {
                    //Calculo do Ponto
                    curvaInterpolada[i].ValorVertice = vertices[indUltimoPonto].ValorVertice +
                        (vertices[indUltimoPonto].ValorVertice - vertices[indPenultimoPonto].ValorVertice) *
                        ((double)(curvaInterpolada[i].QuantidadeDiasUteis - lPrazoProxFator) / (lPrazoProxFator - lPrazoFatorAnt));
                }
                else
                {
                    //Calculo do Ponto
                    curvaInterpolada[i].ValorVertice = vertices[indUltimoPonto].ValorVertice +
                        (vertices[indUltimoPonto].ValorVertice - vertices[indPenultimoPonto].ValorVertice) *
                        ((double)(curvaInterpolada[i].QuantidadeDiasCorridos - lPrazoProxFator) / (lPrazoProxFator - lPrazoFatorAnt));
                }
            }
        }

        private void AntepolacaoExponencial(IList<CurvaExecucaoPonto> vertices, DateTime dataBase, int baseDias, IList<CurvaExecucaoPonto> curvaInterpolada)
        {
            int indPrimeiroPonto = 0;
            int indSegundoPonto = 1;

            int lPrazoProxFator = 0;
            int lPrazoFatorAnt = 0;

            if (baseDias == BASE_252)
            {
                lPrazoFatorAnt = vertices[indPrimeiroPonto].QuantidadeDiasUteis;
                lPrazoProxFator = vertices[indSegundoPonto].QuantidadeDiasUteis;
            }
            else
            {
                lPrazoFatorAnt = vertices[indPrimeiroPonto].QuantidadeDiasCorridos;
                lPrazoProxFator = vertices[indSegundoPonto].QuantidadeDiasCorridos;
            }

            //curvaInterpolada[0].ValorVertice = 1;
            for (int i = vertices[indPrimeiroPonto].QuantidadeDiasCorridos - 1; i > 0; i--)
            {

                //Calculo do Ponto Interpolado
                if (baseDias == BASE_252)
                {
                    curvaInterpolada[i].ValorVertice = vertices[indPrimeiroPonto].ValorVertice /
                        Math.Pow((vertices[indSegundoPonto].ValorVertice /vertices[indPrimeiroPonto].ValorVertice),
                        ((double)(lPrazoFatorAnt - curvaInterpolada[i].QuantidadeDiasUteis) / (lPrazoProxFator - lPrazoFatorAnt)));
                }
                else
                {
                    curvaInterpolada[i].ValorVertice = vertices[indPrimeiroPonto].ValorVertice /
                        Math.Pow((vertices[indSegundoPonto].ValorVertice / vertices[indPrimeiroPonto].ValorVertice),
                        ((double)(lPrazoFatorAnt - curvaInterpolada[i].QuantidadeDiasCorridos) / (lPrazoProxFator - lPrazoFatorAnt)));

                }
            }
        }

        private void InterpolacaoExponencial(IList<CurvaExecucaoPonto> vertices, DateTime dataBase, int baseDias, IList<CurvaExecucaoPonto> curvaInterpolada)
        {
            int iAnt, iProx;
            iProx = 0;
            iAnt = 0;

            //DateTime DataBase = Vertices[0].DataVencimento.AddDays(-1); 

            for (int i = 0; i < vertices.Count; i++)
            {
                //Verificar o tipo de da curva para realizar o calculo.
                iProx = i;
                //Pula o Primeiro Fator
                if (iProx > 0)
                {
                    for (int j = vertices[iAnt].QuantidadeDiasCorridos + 1; j < vertices[iProx].QuantidadeDiasCorridos; j++)
                    {
                        // CurvaExecucaoPonto pontoCurva = new CurvaExecucaoPonto();

                        //Calcula o ponto do vertice interpolado
                        if (baseDias == BASE_252)
                        {
                            curvaInterpolada[j].ValorVertice = vertices[iAnt].ValorVertice *
                                                      Math.Pow((vertices[iProx].ValorVertice / vertices[iAnt].ValorVertice),
                                                      ((double)(curvaInterpolada[j].QuantidadeDiasUteis - vertices[iAnt].QuantidadeDiasUteis) /
                                                      (vertices[iProx].QuantidadeDiasUteis - vertices[iAnt].QuantidadeDiasUteis)));

                            if(double.IsNaN(curvaInterpolada[j].ValorVertice) || double.IsInfinity(curvaInterpolada[j].ValorVertice))
                            {
                                curvaInterpolada[j].ValorVertice = curvaInterpolada[j-1].ValorVertice;
                            }
                        }
                        else
                        {
                            curvaInterpolada[j].ValorVertice = vertices[iAnt].ValorVertice *
                                                      Math.Pow((vertices[iProx].ValorVertice / vertices[iAnt].ValorVertice),
                                                      ((double)(curvaInterpolada[j].QuantidadeDiasCorridos - vertices[iAnt].QuantidadeDiasCorridos) /
                                                      (vertices[iProx].QuantidadeDiasCorridos - vertices[iAnt].QuantidadeDiasCorridos)));
                        }
                    }
                }
                iAnt = iProx;
            }
        }

        private void ExtrapolacaoExponencial(IList<CurvaExecucaoPonto> vertices, DateTime dataBase, int baseDias, IList<CurvaExecucaoPonto> curvaInterpolada)
        {
            int indUltimoPonto = vertices.Count - 1;
            int indPenultimoPonto = vertices.Count - 2;

            int lPrazoProxFator = 0;
            int lPrazoFatorAnt = 0;

            if (baseDias == BASE_252)
            {
                lPrazoProxFator = vertices[indUltimoPonto].QuantidadeDiasUteis;
                lPrazoFatorAnt = vertices[indPenultimoPonto].QuantidadeDiasUteis;
            }
            else
            {
                lPrazoProxFator = vertices[indUltimoPonto].QuantidadeDiasCorridos;
                lPrazoFatorAnt = vertices[indPenultimoPonto].QuantidadeDiasCorridos;
            }

            for (int i = vertices[indUltimoPonto].QuantidadeDiasCorridos + 1; i < curvaInterpolada.Count; i++)
            {
                //Calculo do Ponto Interpolado
                if (baseDias == BASE_252)
                {
                    curvaInterpolada[i].ValorVertice = vertices[indUltimoPonto].ValorVertice *
                        Math.Pow((vertices[indUltimoPonto].ValorVertice / vertices[indPenultimoPonto].ValorVertice),
                        ((double)(curvaInterpolada[i].QuantidadeDiasUteis - lPrazoProxFator) / (lPrazoProxFator - lPrazoFatorAnt)));
                }
                else
                {
                    curvaInterpolada[i].ValorVertice = vertices[indUltimoPonto].ValorVertice *
                        Math.Pow((vertices[indUltimoPonto].ValorVertice / vertices[indPenultimoPonto].ValorVertice),
                        ((double)(curvaInterpolada[i].QuantidadeDiasCorridos - lPrazoProxFator) / (lPrazoProxFator - lPrazoFatorAnt)));
                }
            }
        }

        private IList<CurvaExecucaoPonto> InterpolacaoCubicSpline(IList<CurvaExecucaoPonto> vertices, DateTime dataBase, int baseDias, IList<CurvaExecucaoPonto> curvaInterpolada)
        {
            IList<CurvaExecucaoPonto> listaVertice2 = vertices;

            vertices = (from lista in vertices
                        where lista.ValorVertice != 0
                        orderby lista.DataVencimento ascending
                        select lista).ToList();

            int qtePontos = curvaInterpolada.Count;
            int qteVertices = vertices.Count;

            int[] listaPrazos = new int[qtePontos];
            double[] listaTaxas = new double[qtePontos];

            double[] p = new double[qtePontos];

            double[] s = new double[qtePontos];

            double nPzMax;
            double nTaxaMax;
            int i;

            double[] dPrazos_EixoX = new double[qteVertices];
            double[] dTaxas_EixoY = new double[qteVertices];

            for (i = 0; i < qteVertices; i++)
            {
                dPrazos_EixoX[i] = vertices[i + 1].QuantidadeDiasCorridos - vertices[i].QuantidadeDiasCorridos;
                dTaxas_EixoY[i] = vertices[i + 1].ValorVertice - vertices[i].ValorVertice;
            }

            double[] d = new double[qteVertices];
            double[] w = new double[qteVertices];

            for (i = 1; i < qteVertices - 1; i++)
            {
                d[i] = 2 * (dPrazos_EixoX[i - 1] + dPrazos_EixoX[i]);
                w[i] = 6 * ((double)(dTaxas_EixoY[i] / dPrazos_EixoX[i]) - ((double)dTaxas_EixoY[i - 1] / dPrazos_EixoX[i - 1]));
            }

            p[0] = 0;
            p[qteVertices - 1] = 0;

            for (i = 1; i < qteVertices - 2; i++)
            {
                w[i + 1] = w[i + 1] - (w[i] * dPrazos_EixoX[i] / d[i]);
                d[i + 1] = d[i + 1] - Math.Pow(dPrazos_EixoX[i], ((double)2 / d[i]));
            }

            for (i = qteVertices - 1; i > 0; i--)
            {
                p[i] = (d[i] - dPrazos_EixoX[i] * p[i + 1]) / d[i];
            }

            nPzMax = curvaInterpolada[qtePontos].QuantidadeDiasCorridos;

            //Calcular no ponto maximo, caso não tenha sido informada nos vertices.
            if (nPzMax >= vertices[qteVertices - 1].QuantidadeDiasCorridos)
            {
                nTaxaMax = vertices[qteVertices - 2].ValorVertice + ((dTaxas_EixoY[qteVertices - 2] / dPrazos_EixoX[qteVertices - 2])
                          - (dPrazos_EixoX[qteVertices - 2] * (p[qteVertices - 1]) - 2 * p[qteVertices - 2]) / 6)
                          * (nPzMax - vertices[qteVertices - 1].QuantidadeDiasCorridos);
            }

            int valor = 0;
            for (int aux = 0; aux < listaPrazos.Length; i++)
            {
                if (valor < listaPrazos[aux] && listaPrazos[aux] < nPzMax - 1)
                {
                    valor = listaPrazos[aux];
                    i = aux;
                }
            }

            return null;
        }

        #endregion

    }
}
