using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Workflow.Runtime;
using System.Threading;
using System.Data.SqlClient;

namespace DecisaoRegras
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                using (WorkflowRuntime workflowRuntime = new WorkflowRuntime())
                {
                    WorkflowInstance instance = workflowRuntime.CreateWorkflow
                      (typeof(Decisao));

                    instance.Start();
                }

                Thread.Sleep(Int32.Parse(System.Configuration.ConfigurationManager.AppSettings["tempoPausaMilisegundos"]));
            }
        }
    }
}
