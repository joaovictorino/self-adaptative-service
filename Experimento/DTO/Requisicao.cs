using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class Requisicao
    {

        public string Id
        {
            get;
            set;
        }

        public DateTime DataHoraInclusao
        {
            get;
            set;
        }

        public string Dados
        {
            get;
            set;
        }

        public DateTime DataHoraRequisicao
        {
            get;
            set;
        }

        public TimeSpan TempoRequisicao
        {
            get;
            set;
        }
    }
}
