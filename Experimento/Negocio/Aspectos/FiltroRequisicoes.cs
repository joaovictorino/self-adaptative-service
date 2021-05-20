using Microsoft.Practices.Unity.InterceptionExtension;
using Negocio.DAO;
using Negocio.DTOs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Negocio.Aspectos
{
    public class FiltroRequisicoes : IInterceptionBehavior
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

            if (request.Dominio == "Risco")
            {
                return getNext()(input, getNext);
            }
            else
            {
                XmlSerializer xml = new XmlSerializer(typeof(RequestInterpolador));
                StringWriter sw = new StringWriter();
                xml.Serialize(sw, request);
                FilaDAO dao = new FilaDAO();
                dao.Gravar(sw.ToString(), request.Dominio);
                return input.CreateMethodReturn(null, input.Arguments);
            }
        }
    }
}
