using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ServicoBase
{
    [DataContract]
    public class DadosAtuacao
    {
        [DataMember]
        public string NomeContainer { get; set; }

        [DataMember]
        public string Usuario { get; set; }

        [DataMember]
        public string Senha { get; set; }
    }
}
