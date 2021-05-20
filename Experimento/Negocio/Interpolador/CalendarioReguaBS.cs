using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;

namespace Negocio
{
    public class CalendarioReguaBS : IDisposable
    {
        public Dictionary<string, DiaInfo> Regua = new Dictionary<string, DiaInfo>();
        protected DateTime DataReferencia;
        protected DateTime DataFinal;
        protected int DiasExtensao;
        public int NumeroMaxDiasCorridos;
        public int NumeroMaxDiasUteis;
        protected IList<string> Feriados;

        public CalendarioReguaBS(DateTime dataReferencia, int diasExtensao)
        {
            this.DataReferencia = dataReferencia;
            this.DiasExtensao = diasExtensao;
            this.DataFinal = this.DataReferencia.AddYears(DiasExtensao);
            this.Feriados = new List<string>();
            MontarReguaCalendario();
        }

        public CalendarioReguaBS(DateTime dataReferencia, DateTime dataExtensao)
        {
            this.DataReferencia = dataReferencia;
            this.DiasExtensao = 0;
            this.DataFinal = dataExtensao;
            this.Feriados = new List<string>();
            MontarReguaCalendario();
        }

        private CalendarioReguaBS(Dictionary<string, DiaInfo> regua, DateTime dataReferencia, DateTime dataExtensao)
        {
            this.DataReferencia = dataReferencia;
            this.DiasExtensao = 0;
            this.DataFinal = dataExtensao;
            this.Regua = regua;
            this.NumeroMaxDiasCorridos = regua.Max(x => x.Value.DiasCorridos);
            this.NumeroMaxDiasCorridos = regua.Max(x => x.Value.DiasUteis);
        }

        protected virtual void MontarReguaCalendario()
        {
            ServicoCalendario.ServicoCalendarioClient cliente = new ServicoCalendario.ServicoCalendarioClient();
            cliente.VerificarFeriado(new DateTime());

            int contadorDC = 0;
            int contadorDU = 0;

            for (int i = 0; i <= (this.DataFinal - this.DataReferencia).Days; i++)
            {
                contadorDC = i;
                DiaInfo dia = new DiaInfo();
                dia.Data = DataReferencia.AddDays(i);
                dia.DiasCorridos = contadorDC;

                if (dia.Data.DayOfWeek != DayOfWeek.Saturday && dia.Data.DayOfWeek != DayOfWeek.Sunday && !Feriados.Contains(dia.Data.ToString("yyyyMMdd")))
                {
                    if (i > 0)
                        contadorDU++;
                    dia.EhDiaUtil = true;
                }
                dia.DiasUteis = contadorDU;
                this.Regua.Add(dia.Data.ToString("yyyyMMdd"), dia);
            }

            this.NumeroMaxDiasCorridos = contadorDC;
            this.NumeroMaxDiasUteis = contadorDU;
        }

        public virtual CalendarioReguaBS ObterIntervalo(DateTime dataInicio, DateTime dataFim)
        {
            Dictionary<string, DiaInfo> regua = (from dia in Regua
                                                 where dia.Value.Data >= dataInicio
                                                 && dia.Value.Data <= dataFim
                                                 orderby dia.Value.Data
                                                 select dia).ToDictionary(dia => dia.Key, dia => dia.Value);
            CalendarioReguaBS calendarioIntervalo = new CalendarioReguaBS(regua, dataInicio, dataFim);
            return calendarioIntervalo;
        }

        public virtual CalendarioReguaBS ObterIntervalo(DateTime dataInicio, int diasExtensao)
        {
            //DateTime dataFim = dataInicio.AddDays(diasExtensao);
            DateTime dataFim = dataInicio.AddYears(diasExtensao);

            return ObterIntervalo(dataInicio, dataFim);
        }

        public int ObterQuantidadeDiasUteis(string dia_yyyyMMdd)
        {
            try
            {
                DiaInfo retorno = (DiaInfo)Regua[dia_yyyyMMdd];
                return retorno.DiasUteis;
            }
            catch
            {
            }

            return 0;
        }

        #region IDisposable Members

        public void Dispose()
        {
            Regua = null;
            Feriados = null;
        }

        #endregion
    }
}
