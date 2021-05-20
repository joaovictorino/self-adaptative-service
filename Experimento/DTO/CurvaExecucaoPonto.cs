using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace DTO
{
    [DataContract]
    public class CurvaExecucaoPonto
    {
        [DataMember]
        public DateTime DataVencimento
        {
            get;
            set;
        }

        [DataMember]
        public double ValorVertice
        {
            get;
            set;
        }

        [DataMember]
        public int QuantidadeDiasCorridos
        {
            get;
            set;
        }

        [DataMember]
        public int QuantidadeDiasUteis
        {
            get;
            set;
        }

        [DataMember]
        public int IndicadorVertice
        {
            get;
            set;
        }

        [DataMember]
        public double DurationDiasUteis
        {
            get;
            set;
        }

        [DataMember]
        public double DurationDiasCorridos
        {
            get;
            set;
        }

    }
}
