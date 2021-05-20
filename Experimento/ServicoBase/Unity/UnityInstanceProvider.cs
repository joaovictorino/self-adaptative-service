using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel.Dispatcher;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System.Configuration;
using Negocio.Util;

namespace ServicoBase
{
    public class UnityInstanceProvider : IInstanceProvider
    {
        private Type _serviceType;
        private static object objeto = new object();

        public UnityInstanceProvider(Type serviceType)
        {
            this._serviceType = serviceType;
            //instanciarContainer();
        }

        private IUnityContainer instanciarContainer()
        {
            IUnityContainer _container = new UnityContainer();
            UnityConfigurationSection section = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
            section.Configure(_container, Application.obterValor());
            _container.RegisterType<IAtuador, Atuador>();
            return _container;
        }

        public object GetInstance(System.ServiceModel.InstanceContext instanceContext, System.ServiceModel.Channels.Message message)
        {
            try
            {

                IUnityContainer _container = instanciarContainer();
                return _container.Resolve(_serviceType);
            }
            catch (Exception ex)
            {
                LogWriter.Escrever(ex.Message);
                LogWriter.Escrever(ex.StackTrace);
                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                    LogWriter.Escrever(ex.Message);
                    LogWriter.Escrever(ex.StackTrace);
                }
            }

            return null;
        }

        public object GetInstance(System.ServiceModel.InstanceContext instanceContext)
        {
            return GetInstance(instanceContext, null);
        }

        public void ReleaseInstance(System.ServiceModel.InstanceContext instanceContext, object instance)
        {
            if (instance is IDisposable)
                ((IDisposable)instance).Dispose();
        }
    }
}