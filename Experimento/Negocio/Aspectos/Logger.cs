using Microsoft.Practices.Unity.InterceptionExtension;
using Negocio.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Aspectos
{
    public class Logger : IInterceptionBehavior
    {
        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return Type.EmptyTypes;
        }

        public bool WillExecute
        {
            get
            {
                return true;
            }
        }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            var returnValue = getNext()(input, getNext);
            LogWriter.Escrever(input.MethodBase.Name);
            return returnValue;
        }
    }
}
