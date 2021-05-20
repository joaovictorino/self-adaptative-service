using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Workflow.Activities;
using Raven.Client;
using Raven.Client.Document;
using DTO;
using System.Data.SqlClient;

namespace DecisaoRegras
{
    public partial class Decisao : SequentialWorkflowActivity
    {
        public Monitoracao DadosMonitoracao
        {
            get;
            set;
        }

        public Atuador.DadosAtuacao DadosAtuacao
        {
            get;
            set;
        }

        public Decisao()
        {
            InitializeComponent();
            DadosMonitoracao = new Monitoracao();
            DadosAtuacao = new Atuador.DadosAtuacao();
        }

        private void BuscarRequisicoes_ExecuteCode(object sender, EventArgs e)
        {
            int tempoMedicaoIntervalo = Int32.Parse(System.Configuration.ConfigurationManager.AppSettings["tempoMinutosIntervaloMedicao"]);
            DateTime tempoDeMedicao = System.DateTime.Now.AddMinutes(tempoMedicaoIntervalo);
            string conexao = @"Data Source=JOAO-PC;Initial Catalog=Experimento;Persist Security Info=True;User ID=sa;Password=joao";

            string comandoSelectAcessos = @"SELECT COUNT(1) FROM RequisicaoSaida (nolock) WHERE DataHoraFim > @TempoMedicao;";
            string comandoSelectMaiorTempo = @"SELECT MAX(Duracao) FROM RequisicaoSaida (nolock) WHERE DataHoraFim > @TempoMedicao;";

            using (SqlConnection conn = new SqlConnection(conexao))
            {
                SqlCommand cmdAcessos = new SqlCommand(comandoSelectAcessos, conn);
                cmdAcessos.Parameters.AddWithValue("@TempoMedicao", tempoDeMedicao);
                SqlCommand cmdTempo = new SqlCommand(comandoSelectMaiorTempo, conn);
                cmdTempo.Parameters.AddWithValue("@TempoMedicao", tempoDeMedicao);

                try
                {
                    conn.Open();
                    DadosMonitoracao.Acessos = Convert.ToInt32(cmdAcessos.ExecuteScalar());
                    DadosMonitoracao.MaiorTempo = ((TimeSpan)cmdTempo.ExecuteScalar()).TotalSeconds;
                    Console.WriteLine("Acessos: " + DadosMonitoracao.Acessos);
                    Console.WriteLine("Maior Tempo: " + DadosMonitoracao.MaiorTempo);
                }
                catch { }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void CriarRequisicao_ExecuteCode(object sender, EventArgs e)
        {
            DadosAtuacao.NomeContainer = DadosMonitoracao.Container;
            DadosAtuacao.Usuario = "Joao";
            Console.WriteLine("Container: " + DadosMonitoracao.Container);
        }
    }
}
