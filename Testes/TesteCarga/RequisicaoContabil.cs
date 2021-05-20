using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TesteCarga.ServicoInterpolador;
using System.Collections.Generic;

namespace TesteCarga
{
    [TestClass]
    public class RequisicaoContabil
    {
        [TestMethod]
        public void ConsultarContabil()
        {
            FacadeServicoClient servico = new FacadeServicoClient();
            Execucao execucao = new Execucao();
            execucao.AnosExtensao = 20;
            execucao.Antepolacao = TipoInterpolacao.LINEAR;
            execucao.BaseDias = TipoBaseDias.BASE360;
            execucao.DataBase = System.DateTime.Now.Date;
            execucao.DataHoraExecucaoCurva = System.DateTime.Now;
            execucao.Extrapolacao = TipoInterpolacao.LINEAR;
            execucao.Interpolacao = TipoInterpolacao.LINEAR;
            execucao.NomeCurva = string.Empty;
            execucao.Pontos = new List<CurvaExecucaoPonto>();

            execucao.Pontos.Add(new CurvaExecucaoPonto()
            {
                DataVencimento = System.DateTime.Now.Date,
                QuantidadeDiasCorridos = 0,
                QuantidadeDiasUteis = 0,
                IndicadorVertice = 1,
                ValorVertice = 1
            });
            execucao.Pontos.Add(new CurvaExecucaoPonto()
            {
                DataVencimento = new DateTime(2022, 12, 01),
                QuantidadeDiasCorridos = Convert.ToInt32((new DateTime(2022, 12, 01) - System.DateTime.Now.Date).TotalDays),
                QuantidadeDiasUteis = 0,
                IndicadorVertice = 1,
                ValorVertice = 10
            });

            execucao.Vertice = TipoVertice.TAXA;

            RequestInterpolador request = new RequestInterpolador();
            request.Execucao = execucao;
            request.Usuario = "Joao";
            request.Senha = "12345";
            request.Dominio = "Contabil";

            ResponseInterpolador response = servico.Interpolar(request);
        }
    }
}
