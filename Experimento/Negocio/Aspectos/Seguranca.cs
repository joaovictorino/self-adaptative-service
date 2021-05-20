using Microsoft.Practices.Unity.InterceptionExtension;
using Negocio.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Aspectos
{
    public class Seguranca : IInterceptionBehavior
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
            RequestInterpolador request = (RequestInterpolador)input.Arguments[0];
            ServicoSeguranca.IServicoControleAcesso controleAcesso = new ServicoSeguranca.ServicoControleAcessoClient();

            if (!string.IsNullOrEmpty(request.Usuario)
                && !string.IsNullOrEmpty(request.Senha)
                && !string.IsNullOrEmpty(request.Dominio)
                && controleAcesso.ValidarAcesso(request.Usuario, request.Senha, request.Dominio))
            {
                return getNext()(input, getNext);
            }
            else
            {
                return input.CreateMethodReturn(null, input.Arguments);
            }
        }
    }
}
