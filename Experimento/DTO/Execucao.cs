using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace DTO
{

    [DataContract]
    public class Execucao
    {

        [DataMember]
        public string NomeCurva
        {
            get;
            set;
        }

        [DataMember]
        public List<CurvaExecucaoPonto> Pontos
        {
            get;
            set;
        }

        [DataMember]
        public DateTime DataHoraExecucaoCurva
        {
            get;
            set;
        }

        [DataMember]
        public DateTime DataBase 
        { 
            get; 
            set; 
        }

        [DataMember]
        public int AnosExtensao 
        { 
            get; 
            set; 
        }

        [DataMember]
        public TipoBaseDias BaseDias 
        { 
            get; 
            set; 
        }

        [DataMember]
        public TipoInterpolacao Antepolacao 
        { 
            get; 
            set; 
        }

        [DataMember]
        public TipoInterpolacao Interpolacao 
        { 
            get; 
            set; 
        }

        [DataMember]
        public TipoInterpolacao Extrapolacao 
        { 
            get; 
            set; 
        }

        [DataMember]
        public TipoVertice Vertice
        {
            get;
            set;
        }

    }

}
