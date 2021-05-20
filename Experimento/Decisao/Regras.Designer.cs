namespace Decisao
{
    partial class Regras
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.CanModifyActivities = true;
            System.Workflow.ComponentModel.ActivityBind activitybind1 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding1 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.Activities.Rules.RuleSetReference rulesetreference1 = new System.Workflow.Activities.Rules.RuleSetReference();
            this.AlterarContainer = new System.Workflow.Activities.InvokeWebServiceActivity();
            this.ExecutarRegras = new System.Workflow.Activities.PolicyActivity();
            this.BuscarRequisicoes = new System.Workflow.Activities.CodeActivity();
            // 
            // AlterarContainer
            // 
            this.AlterarContainer.MethodName = "setarContainer";
            this.AlterarContainer.Name = "AlterarContainer";
            activitybind1.Name = "Regras";
            activitybind1.Path = "DadosMonitoracao.Container";
            workflowparameterbinding1.ParameterName = "nome";
            workflowparameterbinding1.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind1)));
            this.AlterarContainer.ParameterBindings.Add(workflowparameterbinding1);
            this.AlterarContainer.ProxyClass = typeof(Decisao.Atuador.Atuador);
            // 
            // ExecutarRegras
            // 
            this.ExecutarRegras.Name = "ExecutarRegras";
            rulesetreference1.RuleSetName = "testeregras";
            this.ExecutarRegras.RuleSetReference = rulesetreference1;
            // 
            // BuscarRequisicoes
            // 
            this.BuscarRequisicoes.Name = "BuscarRequisicoes";
            this.BuscarRequisicoes.ExecuteCode += new System.EventHandler(this.BuscarRequisicoes_ExecuteCode);
            // 
            // Regras
            // 
            this.Activities.Add(this.BuscarRequisicoes);
            this.Activities.Add(this.ExecutarRegras);
            this.Activities.Add(this.AlterarContainer);
            this.Name = "Regras";
            this.CanModifyActivities = false;

        }

        #endregion

        private System.Workflow.Activities.InvokeWebServiceActivity AlterarContainer;

        private System.Workflow.Activities.CodeActivity BuscarRequisicoes;

        private System.Workflow.Activities.PolicyActivity ExecutarRegras;






























    }
}
