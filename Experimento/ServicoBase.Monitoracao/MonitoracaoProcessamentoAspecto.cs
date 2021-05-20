using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicoBase.Monitoracao
{
    public class MonitoracaoProcessamentoAspecto : IInterceptionBehavior
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
            var returnValue = getNext()(input, getNext);

            PerformanceCounter cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            PerformanceCounter ramCounter = new PerformanceCounter("Memory", "Available MBytes");

            float cpu = cpuCounter.NextValue();
            cpu = cpuCounter.NextValue();
            float memoria = ramCounter.NextValue();

            Contador.GravarInfra(cpu, memoria, System.DateTime.Now);

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
