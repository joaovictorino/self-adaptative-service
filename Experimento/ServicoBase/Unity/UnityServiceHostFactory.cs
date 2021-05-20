using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel.Activation;

namespace ServicoBase
{
    public class UnityServiceHostFactory : ServiceHostFactory
    {
        protected override System.ServiceModel.ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
        {
            return new UnityServiceHost(serviceType, baseAddresses);
        }
    }
}