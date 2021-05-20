using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cliente
{
    class Program
    {
        static void Main(string[] args)
        {
            Servico.FacadeServicoClient servico = new Servico.FacadeServicoClient();
            Servico.Execucao execucao = new Servico.Execucao();
            execucao.AnosExtensao = 20;
            execucao.Antepolacao = Servico.TipoInterpolacao.LINEAR;
            execucao.BaseDias = Servico.TipoBaseDias.BASE360;
            execucao.DataBase = System.DateTime.Now.Date;
            execucao.DataHoraExecucaoCurva = System.DateTime.Now;
            execucao.Extrapolacao = Servico.TipoInterpolacao.LINEAR;
            execucao.Interpolacao = Servico.TipoInterpolacao.LINEAR;
            execucao.NomeCurva = string.Empty;
            execucao.Pontos = new List<Servico.CurvaExecucaoPonto>();

            execucao.Pontos.Add(new Servico.CurvaExecucaoPonto()
            {
                DataVencimento = System.DateTime.Now.Date,
                QuantidadeDiasCorridos = 0,
                QuantidadeDiasUteis = 0,
                IndicadorVertice = 1,
                ValorVertice = 1
            });
            execucao.Pontos.Add(new Servico.CurvaExecucaoPonto()
            {
                DataVencimento = new DateTime(2022, 12, 01),
                QuantidadeDiasCorridos = Convert.ToInt32((new DateTime(2022, 12, 01) - System.DateTime.Now.Date).TotalDays),
                QuantidadeDiasUteis = 0,
                IndicadorVertice = 1,
                ValorVertice = 10
            });

            execucao.Vertice = Servico.TipoVertice.TAXA;

            Servico.RequestInterpolador request = new Servico.RequestInterpolador();
            request.Execucao = execucao;
            request.Usuario = "Joao";
            request.Senha = "12345";
            request.Dominio = "IBBA";

            Servico.ResponseInterpolador response = servico.Interpolar(request);

            if (response != null
                && response.Pontos != null)
            {
                Console.WriteLine(response.Pontos.Count + " pontos");
            }
            else
            {
                Console.WriteLine("Nao vieram pontos");
            }

            Console.ReadKey();
        }
    }
}
