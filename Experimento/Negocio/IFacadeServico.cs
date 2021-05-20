using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using DTO;
using Negocio.DTOs;

namespace Negocio
{
    [ServiceContract]
    public interface IFacadeServico
    {
        [OperationContract]
        ResponseInterpolador Interpolar(RequestInterpolador request);
    }
}
