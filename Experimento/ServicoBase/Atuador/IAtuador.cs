using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace ServicoBase
{
    [ServiceContract]
    public interface IAtuador
    {
        [OperationContract()]
        void setarContainer(DadosAtuacao dados);
    }
}
