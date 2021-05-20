using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using DTO;

namespace Negocio
{

    [ServiceContract]
    public interface IConversorTaxas
    {
        [OperationContract]
        IList<CurvaExecucaoPonto> ConvertePUsParaExponencial(IList<CurvaExecucaoPonto> listaPontos, int baseDias);

        [OperationContract]
        IList<CurvaExecucaoPonto> ConverteFatoresDiariosParaLinear(IList<CurvaExecucaoPonto> listaPontos, int baseDias);

        [OperationContract]
        IList<CurvaExecucaoPonto> ConverteFatoresDiariosExponenciais(IList<CurvaExecucaoPonto> listaPontos, int baseDias);

        [OperationContract]
        IList<CurvaExecucaoPonto> ConverterPUsParaFatorDiario(IList<CurvaExecucaoPonto> listaVertices);

        [OperationContract]
        IList<CurvaExecucaoPonto> ConverteFatoresDiariosParaPU(IList<CurvaExecucaoPonto> listaVertices);

        [OperationContract]
        IList<CurvaExecucaoPonto> ConverterTaxasExponenciaisParaFatorDiario(IList<CurvaExecucaoPonto> listaVertices, int baseDias);

        [OperationContract]
        IList<CurvaExecucaoPonto> ConverterTaxasLinearesParaFatorDiario(IList<CurvaExecucaoPonto> listaVertices, int baseDias);

        [OperationContract]
        IList<CurvaExecucaoPonto> ConverterTaxasExponenciaisParaPU(IList<CurvaExecucaoPonto> listaVertices, int baseDias);

        [OperationContract]
        IList<CurvaExecucaoPonto> ConverterTaxasLinearesParaPU(IList<CurvaExecucaoPonto> lsitaVertices, int baseDias);
    }
}
