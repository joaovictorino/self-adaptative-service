using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity.InterceptionExtension;
using Microsoft.Practices.Unity;
using Negocio.DTOs;
using System.Management;
using System.Diagnostics;

namespace ServicoBase.Monitoracao
{
    public class MonitoracaoAspecto : IInterceptionBehavior
    {
        [Dependency]
        public IContador Contador
        {
            get;
            set;
        }

        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return Type.EmptyTypes;
        }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            DateTime dataInicio = System.DateTime.Now;
            string id = Guid.NewGuid().ToString();
            RequestInterpolador request = (RequestInterpolador)input.Arguments[0];

            Contador.GravarEntrada(id, dataInicio, request.Dominio);
            
            var returnValue = getNext()(input, getNext);

            DateTime dataFim = System.DateTime.Now;
            TimeSpan tempoRequisicao = dataFim.Subtract(dataInicio);
            Contador.GravarSaida(id, dataFim, tempoRequisicao);

            return returnValue;
        }

        public bool WillExecute
        {
            get 
            { 
                return true; 
            }
        }
    }
}
