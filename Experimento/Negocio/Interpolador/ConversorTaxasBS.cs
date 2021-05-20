using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;

namespace Negocio
{
    public class ConversorTaxasBS : IConversorTaxas
    {
        ConversorTaxas conversor = new ConversorTaxas();

        public IList<CurvaExecucaoPonto> ConvertePUsParaExponencial(IList<CurvaExecucaoPonto> listaPontos, int baseDias)
        {
            for (int i = 0; i < listaPontos.Count; i++)
            {
                // Verifica a quantidade base de dias
                if (baseDias == 252)
                {
                    // Verifica a quantidade de dias corridos
                    listaPontos[i].ValorVertice = conversor.ConvertePUParaLinear(listaPontos[i].ValorVertice, baseDias, listaPontos[i].QuantidadeDiasUteis);
                }
                else
                {
                    // Verifica a quantidade de dias corridos
                    listaPontos[i].ValorVertice = conversor.ConvertePUParaLinear(listaPontos[i].ValorVertice, baseDias, listaPontos[i].QuantidadeDiasCorridos);
                }

            }

            return listaPontos;
        }

        public IList<CurvaExecucaoPonto> ConverteFatoresDiariosParaLinear(IList<CurvaExecucaoPonto> listaPontos, int baseDias)
        {
            List<CurvaExecucaoPonto> novaListaPontos = null;
            CurvaExecucaoPonto novoPonto = null;

            novaListaPontos = new List<CurvaExecucaoPonto>();

            foreach (CurvaExecucaoPonto curvaExecucaoPonto in listaPontos)
            {
                novoPonto = new CurvaExecucaoPonto();

                novoPonto.DataVencimento = curvaExecucaoPonto.DataVencimento;
                novoPonto.IndicadorVertice = curvaExecucaoPonto.IndicadorVertice;
                novoPonto.QuantidadeDiasCorridos = curvaExecucaoPonto.QuantidadeDiasCorridos;
                novoPonto.QuantidadeDiasUteis = curvaExecucaoPonto.QuantidadeDiasUteis;
                novoPonto.ValorVertice = curvaExecucaoPonto.ValorVertice;

                // Verifica a quantidade base de dias
                if (baseDias == 252)
                {
                    // Verifica a quantidade de dias corridos
                    if ((curvaExecucaoPonto.QuantidadeDiasUteis != 0))
                        novoPonto.ValorVertice = (double)100 * ((curvaExecucaoPonto.ValorVertice - 1) * ((double)baseDias / curvaExecucaoPonto.QuantidadeDiasUteis));
                    else
                        novoPonto.ValorVertice = 0;
                }
                else
                {
                    // Verifica a quantidade de dias corridos
                    if ((curvaExecucaoPonto.QuantidadeDiasCorridos != 0))
                        novoPonto.ValorVertice = (double)100 * ((curvaExecucaoPonto.ValorVertice - 1) * ((double)baseDias / curvaExecucaoPonto.QuantidadeDiasCorridos));
                    else
                        novoPonto.ValorVertice = 0;
                }

                // Adiciona o objeto na lista 
                novaListaPontos.Add(novoPonto);
            }

            // Retorna a lista
            return novaListaPontos;
        }

        public IList<CurvaExecucaoPonto> ConverteFatoresDiariosExponenciais(IList<CurvaExecucaoPonto> listaPontos, int baseDias)
        {
            for (int i = 0; i < listaPontos.Count; i++)
            {
                if (i != 0)
                {
                    // Verifica a quantidade base de dias
                    if (baseDias == 252)
                    {
                        // Verifica a quantidade de dias corridos
                        listaPontos[i].ValorVertice = conversor.ConverteFatorDiarioParaExponencial(listaPontos[i].ValorVertice, baseDias, listaPontos[i].QuantidadeDiasUteis);
                    }
                    else
                    {
                        // Verifica a quantidade de dias corridos
                        listaPontos[i].ValorVertice = conversor.ConverteFatorDiarioParaExponencial(listaPontos[i].ValorVertice, baseDias, listaPontos[i].QuantidadeDiasCorridos);
                    }
                }
                else
                {
                    listaPontos[i].ValorVertice = 0;
                }
            }

            return listaPontos;
        }

        public IList<CurvaExecucaoPonto> ConverterFatoresDiariosParaTaxasOver(IList<CurvaExecucaoPonto> listaPontos)
        {
            for (int i = 0; i < listaPontos.Count; i++)
            {
                if (i != 0)
                {
                    listaPontos[i].ValorVertice = conversor.ConverterFatorDiarioParaOver(listaPontos[i].ValorVertice, listaPontos[i].QuantidadeDiasCorridos);
                }
                else
                {
                    listaPontos[i].ValorVertice = 0;
                }
            }

            return listaPontos;
        }

        public IList<CurvaExecucaoPonto> ConvertePUsParaLinear(IList<CurvaExecucaoPonto> listaVertices, int baseDias)
        {
            if (baseDias == 252)
            {
                for (int i = 0; i < listaVertices.Count; i++)
                {
                    listaVertices[i].ValorVertice = conversor.ConvertePUParaLinear(listaVertices[i].ValorVertice, baseDias, listaVertices[i].QuantidadeDiasUteis);
                }
            }
            else
            {
                for (int i = 0; i < listaVertices.Count; i++)
                {
                    listaVertices[i].ValorVertice = conversor.ConvertePUParaLinear(listaVertices[i].ValorVertice, baseDias, listaVertices[i].QuantidadeDiasCorridos);
                }
            }

            return listaVertices;
        }


        public IList<CurvaExecucaoPonto> ConverterPUsParaFatorDiario(IList<CurvaExecucaoPonto> listaVertices)
        {
            for (int i = 0; i < listaVertices.Count; i++)
            {
                if (i != 0)
                {
                    listaVertices[i].ValorVertice = conversor.ConverterPUParaFatorDiario(listaVertices[i].ValorVertice);
                }
                else
                {
                    listaVertices[i].ValorVertice = 1;
                }
            }

            return listaVertices;
        }

        public IList<CurvaExecucaoPonto> ConverteFatoresDiariosParaPU(IList<CurvaExecucaoPonto> listaVertices)
        {
            for (int i = 0; i < listaVertices.Count; i++)
            {
                if (i != 0)
                {
                    listaVertices[i].ValorVertice = conversor.ConverterFatorDiarioParaPU(listaVertices[i].ValorVertice);
                }
                else
                {
                    listaVertices[i].ValorVertice = 0;
                }
            }

            return listaVertices;
        }

        public IList<CurvaExecucaoPonto> ConverterTaxasExponenciaisParaFatorDiario(IList<CurvaExecucaoPonto> listaVertices, int baseDias)
        {
            if (baseDias == 252)
            {
                for (int i = 0; i < listaVertices.Count; i++)
                {
                    if (i != 0)
                    {
                        listaVertices[i].ValorVertice = conversor.ConverterTaxaExponencialParaFatorDiario(listaVertices[i].ValorVertice, baseDias, listaVertices[i].QuantidadeDiasUteis);
                    }
                    else
                    {
                        listaVertices[i].ValorVertice = 1;
                    }
                }
            }
            else
            {
                for (int i = 0; i < listaVertices.Count; i++)
                {
                    if (i != 0)
                    {
                        listaVertices[i].ValorVertice = conversor.ConverterTaxaExponencialParaFatorDiario(listaVertices[i].ValorVertice, baseDias, listaVertices[i].QuantidadeDiasCorridos);
                    }
                    else
                    {
                        listaVertices[i].ValorVertice = 1;
                    }
                }
            }

            return listaVertices;
        }

        public IList<CurvaExecucaoPonto> ConverterTaxasLinearesParaFatorDiario(IList<CurvaExecucaoPonto> listaVertices, int baseDias)
        {
            if (baseDias == 252)
            {
                for (int i = 0; i < listaVertices.Count; i++)
                {
                    if (i != 0)
                    {
                        listaVertices[i].ValorVertice = conversor.ConverterTaxaLinearParaFatorDiario(listaVertices[i].ValorVertice, baseDias, listaVertices[i].QuantidadeDiasUteis);
                    }
                    else
                    {
                        listaVertices[i].ValorVertice = 1;
                    }
                }
            }
            else
            {
                for (int i = 0; i < listaVertices.Count; i++)
                {
                    if (i != 0)
                    {
                        listaVertices[i].ValorVertice = conversor.ConverterTaxaLinearParaFatorDiario(listaVertices[i].ValorVertice, baseDias, listaVertices[i].QuantidadeDiasCorridos);
                    }
                    else
                    {
                        listaVertices[i].ValorVertice = 1;
                    }
                }
            }

            return listaVertices;
        }

        public IList<CurvaExecucaoPonto> ConverterTaxasOverParaFatorDiario(IList<CurvaExecucaoPonto> listaVertices)
        {
            for (int i = 0; i < listaVertices.Count; i++)
            {
                if (i != 0)
                {
                    listaVertices[i].ValorVertice = conversor.ConverterTaxaOverParaFatorDiario(listaVertices[i].ValorVertice, listaVertices[i].QuantidadeDiasCorridos);
                }
                else
                {
                    listaVertices[i].ValorVertice = 1;
                }
            }

            return listaVertices;
        }

        public IList<CurvaExecucaoPonto> ConverterTaxasExponenciaisParaPU(IList<CurvaExecucaoPonto> listaVertices, int baseDias)
        {
            if (baseDias == 252)
            {
                for (int i = 0; i < listaVertices.Count; i++)
                {
                    listaVertices[i].ValorVertice = conversor.ConverterTaxaExponencialParaPU(listaVertices[i].ValorVertice, baseDias, listaVertices[i].QuantidadeDiasUteis);
                }
            }
            else
            {
                for (int i = 0; i < listaVertices.Count; i++)
                {
                    listaVertices[i].ValorVertice = conversor.ConverterTaxaExponencialParaPU(listaVertices[i].ValorVertice, baseDias, listaVertices[i].QuantidadeDiasCorridos);
                }
            }

            return listaVertices;
        }

        public IList<CurvaExecucaoPonto> ConverterTaxasLinearesParaPU(IList<CurvaExecucaoPonto> listaVertices, int baseDias)
        {
            if (baseDias == 252)
            {
                for (int i = 0; i < listaVertices.Count; i++)
                {
                    listaVertices[i].ValorVertice = conversor.ConverterTaxaLinearParaPU(listaVertices[i].ValorVertice, baseDias, listaVertices[i].QuantidadeDiasUteis);
                }
            }
            else
            {
                for (int i = 0; i < listaVertices.Count; i++)
                {
                    listaVertices[i].ValorVertice = conversor.ConverterTaxaLinearParaPU(listaVertices[i].ValorVertice, baseDias, listaVertices[i].QuantidadeDiasCorridos);
                }
            }

            return listaVertices;
        }
    }
}
