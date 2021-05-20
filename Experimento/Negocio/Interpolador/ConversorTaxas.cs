using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Negocio
{
    public class ConversorTaxas
    {
        #region Métodos

        public double ConverterFatorDiarioParaLinear(double Fator_diario, long Dias_Ano, long NU_DIAS)
        {
            double retorno = 0.0;

            if (Fator_diario != 0)
            {
                retorno = (double)100 * (Fator_diario - 1) * ((double)Dias_Ano / NU_DIAS);
            }

            return retorno;
        }

        public double ConverterFatorDiarioParaExponencial(double Fator_diario, long Dias_Ano, long NU_DIAS)
        {
            double retorno = 0.0;

            if (Fator_diario != 0)
            {
                retorno = (double)100 * (Math.Pow(Fator_diario, ((double)Dias_Ano / NU_DIAS)) - 1);
            }

            return retorno;
        }

        public double ConverterFatorDiarioParaOver(double Fator_diario, long NU_DIAS)
        {
            double retorno = 0.0;

            if (Fator_diario != 0)
            {
                retorno = (double)3000 * (Math.Pow(Fator_diario, ((double)1 / NU_DIAS)) - 1);
            }

            return retorno;
        }

        public double ConverterFatorDiarioParaPU(double Fator_Desconto)
        {
            double retorno = 0.0;

            if (Fator_Desconto != 0)
            {
                retorno = (double)100000 / Fator_Desconto;
            }

            return retorno;
        }

        public double ConverterTaxaExponencialParaFatorDiario(Double Taxa_Exponencial, int Dias_Ano, long Nu_Dias)
        {
            double retorno = 0.0;

            if (Dias_Ano != 0)
            {
                retorno = (double)Math.Pow(1 + ((double)Taxa_Exponencial / 100), ((double)Nu_Dias / Dias_Ano));
            }

            return retorno;
        }

        public double ConverterTaxaLinearParaFatorDiario(double Taxa_Linear, int Dias_Ano, long Nu_Dias)
        {
            double retorno = 0.0;

            if (Dias_Ano != 0)
            {
                retorno = 1 + ((double)Taxa_Linear / 100) * ((double)Nu_Dias / Dias_Ano);
            }

            return retorno;
        }

        public double ConverterTaxaOverParaFatorDiario(double Taxa_Over, long Nu_Dias)
        {
            return Math.Pow((((double)Taxa_Over / 3000) + 1), ((double)1 / Nu_Dias));
        }

        public double ConverterPUParaFatorDiario(double PU)
        {
            double retorno = 0.0;

            if (PU != 0)
            {
                retorno = (double)100000 / PU;
            }

            return retorno;
        }

        public double ConverterTaxaLinearParaPU(double Taxa_Linear, int Dias_Ano, long Nu_Dias)
        {
            double retorno = 0.0;

            if (Dias_Ano != 0)
            {
                retorno = (double)100000 / ((Taxa_Linear * ((double)Nu_Dias / Dias_Ano)) + 1);
            }

            return retorno;
        }

        public double ConverterTaxaExponencialParaPU(double Taxa_Exponencial, int Dias_Ano, long Nu_Dias)
        {
            double retorno = 0.0;

            if (Dias_Ano != 0)
            {
                retorno = (double)100000 / Math.Pow((Taxa_Exponencial + 1), ((double)Nu_Dias / Dias_Ano));
            }

            return retorno;
        }

        public double ConvertePUParaLinear(double PU, int Dias_Ano, long Nu_Dias)
        {
            double retorno = 0.0;

            if (Nu_Dias != 0)
            {
                retorno = ((100000 / PU) - 1) * (Dias_Ano / Nu_Dias);
            }

            return retorno;
        }

        public double ConvertePUParaExponencial(double PU, int Dias_Ano, long Nu_Dias)
        {
            double retorno = 0.0;

            if (Nu_Dias != 0)
            {
                retorno = Math.Pow(((double)100000 / PU), ((double)Dias_Ano / Nu_Dias)) - 1;
            }

            return retorno;
        }

        public double ConverteFatorDiarioParaExponencial(double Fator_Diario, int Dias_Ano, long Nu_Dias)
        {
            double retorno = 0.0;

            if (Nu_Dias != 0)
            {
                retorno = (double)100 * (Math.Pow(Fator_Diario, (((double)Dias_Ano / Nu_Dias))) - 1);
            }

            return retorno;
        }

        // naka - conversor de taxa 252 para taxa 360 e vice-versa
        //public double ConverteLinearParaExponencial(double TaxaLinear, long DC, long DU)
        //{
        //    double retorno = 0.0;

        //    retorno = (Math.Pow(Math.Pow(1 + TaxaLinear / 100, ((double)DC / 360)), ((double)252 / DU)) - 1) * 100d;

        //    return retorno;
        //}

        //public double ConverteExponencialParaLinear(double TaxaExponencial, long DC, long DU)
        //{
        //    double retorno = 0.0;

        //    retorno = (Math.Pow(Math.Pow(1 + TaxaExponencial / 100, ((double)DU / 252)), ((double)360 / DC)) - 1) * 100d;

        //    return retorno;
        //}

        public double ConverteTaxaBaseDCParaBaseDU(double taxaExponencial, double DC, double DU, double baseDiasExponencial)
        {
            double fator = 1d + (taxaExponencial / 100d);

            double fatorPorDC = Math.Pow(fator, DC / baseDiasExponencial);

            double fatorPorDU = Math.Pow(fatorPorDC, 252d / DU);

            double taxa = (fatorPorDU - 1) * 100d;

            return taxa;
        }

        public double ConverteTaxaBaseDUParaBaseDC(double taxaExponencial, double DC, double DU, double baseDiasExponencial)
        {
            double fator = 1d + (taxaExponencial / 100d);

            double fatorPorDC = Math.Pow(fator, baseDiasExponencial / DC);

            double fatorPorDU = Math.Pow(fatorPorDC, DU / 252d);

            double taxa = (fatorPorDU - 1) * 100d;

            return taxa;
        }

        public double ConverteTaxaBaseDCParaBaseDC(double taxaExponencial, double baseDiasOrigem, double baseDiasDestino)
        {
            double fator = 1d + (taxaExponencial / 100d);

            double fatorPorDC = Math.Pow(fator, baseDiasDestino / baseDiasOrigem);

            double taxa = (fatorPorDC - 1) * 100d;

            return taxa;
        }

        #endregion
    }
}
