using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;

namespace ServicoBase
{
    public class UnityServiceHost : ServiceHost
    {
        public UnityServiceHost()
            : base()
        {
        }

        public UnityServiceHost(Type serviceType, params Uri[] baseAddresses)
            : base(serviceType, baseAddresses)
        {
        }

        protected override void OnOpening()
        {
            this.Description.Behaviors.Add(new UnityInstanceProviderServiceBehavior());
            base.OnOpening();
        }
    }
}