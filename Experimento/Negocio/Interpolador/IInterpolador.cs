using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using DTO;

namespace Negocio
{
    public interface IInterpolador
    {
        IList<CurvaExecucaoPonto> Interpola(IList<CurvaExecucaoPonto> vertices, Double taxaOver, DateTime dataBase, int dataMaxGeracaoCurva, int antepolacaoID, int interpolacaoID, int extrapolacaoID, int baseDias, int tipoVerticeInterpolacao);
    }
}
