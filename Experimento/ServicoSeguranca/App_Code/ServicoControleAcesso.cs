using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading;

public class ServicoControleAcesso : IServicoControleAcesso
{
    public bool ValidarAcesso(string usuario, string senha, string servico)
    {
        for (int i = 0; i < 10; i++)
        {
            Thread.Sleep(50);
        }
        return true;
    }
}
