using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace DTO
{
    [DataContract]
    public class DiaInfo
    {
        [DataMember]
        public DateTime Data
        {
            get;
            set;
        }

        [DataMember]
        public int DiasCorridos
        {
            get;
            set;
        }

        [DataMember]
        public int DiasUteis
        {
            get;
            set;
        }

        [DataMember]
        public bool EhDiaUtil
        {
            get;
            set;
        }
    }
}
