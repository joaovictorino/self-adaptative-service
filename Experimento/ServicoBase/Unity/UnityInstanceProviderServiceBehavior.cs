using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace ServicoBase
{
    public class UnityInstanceProviderServiceBehavior : IServiceBehavior
    {
        public void AddBindingParameters(ServiceDescription serviceDescription, System.ServiceModel.ServiceHostBase serviceHostBase, System.Collections.ObjectModel.Collection<ServiceEndpoint> endpoints, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
        {
        }

        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, System.ServiceModel.ServiceHostBase serviceHostBase)
        {
            serviceHostBase.ChannelDispatchers.ToList().ForEach(channel =>
            {
                ChannelDispatcher dispatcher = channel as ChannelDispatcher;
                if (dispatcher != null)
                {
                    dispatcher.Endpoints.ToList().ForEach(endpoint =>
                    {
                        endpoint.DispatchRuntime.InstanceProvider = new UnityInstanceProvider(serviceDescription.ServiceType);
                    });
                }
            });
        }

        public void Validate(ServiceDescription serviceDescription, System.ServiceModel.ServiceHostBase serviceHostBase)
        {
        }
    }
}