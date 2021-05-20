using System;
using System.Workflow.Activities;
using Raven.Client.Document;
using Raven.Client;
using DTO;
using System.Linq;

namespace Decisao
{
    public partial class Regras : SequentialWorkflowActivity
    {

        public Monitoracao DadosMonitoracao
        {
            get;
            set;
        }

        public Regras()
        {
            InitializeComponent();
            DadosMonitoracao = new Monitoracao();
        }

        private void BuscarRequisicoes_ExecuteCode(object sender, EventArgs e)
        {
            //DadosMonitoracao.Acessos = 3;
            using (var documentStore = new DocumentStore
            {
                Url = System.Configuration.ConfigurationManager.AppSettings["bancoRaven"]
            })
            {
                documentStore.Initialize();

                using (IDocumentSession session = documentStore.OpenSession())
                {
                    DadosMonitoracao.Acessos = (from requisicao in session.Query<Requisicao>()
                                                select requisicao).ToList().Count;
                }

            }
        }
    }
}
