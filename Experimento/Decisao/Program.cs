using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.Workflow.Runtime;
using System.Threading;

namespace Decisao
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
                      (typeof(Regras));
                     
                    instance.Start();
                }

                Thread.Sleep(2000);
            }

        }
    }
}
