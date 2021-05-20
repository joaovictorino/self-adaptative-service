using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity;
using DTO;
using Negocio.DTOs;
using Negocio.DAO;

namespace Negocio
{
    public class FacadeServico : IFacadeServico
    {
        public IInterpolador Interpolador
        {
            get;
            set;
        }

        [InjectionConstructor]
        public FacadeServico(IInterpolador _interpolador) 
        {
            this.Interpolador = _interpolador;
        }

        public virtual ResponseInterpolador Interpolar(RequestInterpolador request)
        {
            ResponseInterpolador response = new ResponseInterpolador();
            CurvaDAO curvaDAO = new CurvaDAO();
            Curva curva = curvaDAO.BuscarDadosCurva(request.Execucao.NomeCurva);
            response.Pontos = Interpolador.Interpola(request.Execucao.Pontos, 0, request.Execucao.DataBase, request.Execucao.AnosExtensao, (int)request.Execucao.Antepolacao, (int)request.Execucao.Interpolacao, (int)request.Execucao.Extrapolacao, (int)request.Execucao.BaseDias, (int)request.Execucao.Vertice);
            return response;
        }
    }
}
