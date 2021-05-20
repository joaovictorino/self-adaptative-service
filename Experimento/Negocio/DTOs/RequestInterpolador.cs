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
    public class RequestInterpolador
    {
        [DataMember]
        public Execucao Execucao
        {
            get;
            set;
        }

        [DataMember]
        public string Usuario
        {
            get;
            set;
        }

        [DataMember]
        public string Senha
        {
            get;
            set;
        }

        [DataMember]
        public string Dominio
        {
            get;
            set;
        }
    }
}
