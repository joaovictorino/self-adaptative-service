using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.DTOs
{
    [DataContract]
    public class ResponseInterpolador
    {
        [DataMember]
        public IList<CurvaExecucaoPonto> Pontos
        {
            get;
            set;
        }
    }
}
