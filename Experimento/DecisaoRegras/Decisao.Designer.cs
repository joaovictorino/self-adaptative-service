namespace DecisaoRegras
{
    partial class Decisao
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
            System.Workflow.ComponentModel.ActivityBind activitybind2 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding2 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.Activities.Rules.RuleSetReference rulesetreference1 = new System.Workflow.Activities.Rules.RuleSetReference();
            this.EnviarContainer = new System.Workflow.Activities.InvokeWebServiceActivity();
            this.CriarRequisicao = new System.Workflow.Activities.CodeActivity();
            this.ExecutarRegras = new System.Workflow.Activities.PolicyActivity();
            this.BuscarRequisicoes = new System.Workflow.Activities.CodeActivity();
            // 
            // EnviarContainer
            // 
            this.EnviarContainer.MethodName = "setarContainer";
            this.EnviarContainer.Name = "EnviarContainer";
            activitybind1.Name = "Decisao";
            activitybind1.Path = "DadosMonitoracao.Container";
            workflowparameterbinding1.ParameterName = "nome";
            workflowparameterbinding1.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind1)));
            activitybind2.Name = "Decisao";
            activitybind2.Path = "DadosAtuacao";
            workflowparameterbinding2.ParameterName = "dados";
            workflowparameterbinding2.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind2)));
            this.EnviarContainer.ParameterBindings.Add(workflowparameterbinding1);
            this.EnviarContainer.ParameterBindings.Add(workflowparameterbinding2);
            this.EnviarContainer.ProxyClass = typeof(DecisaoRegras.Atuador.Atuador);
            // 
            // CriarRequisicao
            // 
            this.CriarRequisicao.Name = "CriarRequisicao";
            this.CriarRequisicao.ExecuteCode += new System.EventHandler(this.CriarRequisicao_ExecuteCode);
            // 
            // ExecutarRegras
            // 
            this.ExecutarRegras.Name = "ExecutarRegras";
            rulesetreference1.RuleSetName = "regrasteste";
            this.ExecutarRegras.RuleSetReference = rulesetreference1;
            // 
            // BuscarRequisicoes
            // 
            this.BuscarRequisicoes.Name = "BuscarRequisicoes";
            this.BuscarRequisicoes.ExecuteCode += new System.EventHandler(this.BuscarRequisicoes_ExecuteCode);
            // 
            // Decisao
            // 
            this.Activities.Add(this.BuscarRequisicoes);
            this.Activities.Add(this.ExecutarRegras);
            this.Activities.Add(this.CriarRequisicao);
            this.Activities.Add(this.EnviarContainer);
            this.Name = "Decisao";
            this.CanModifyActivities = false;

        }

        #endregion

        private System.Workflow.Activities.CodeActivity CriarRequisicao;

        private System.Workflow.Activities.PolicyActivity ExecutarRegras;

        private System.Workflow.Activities.InvokeWebServiceActivity EnviarContainer;

        private System.Workflow.Activities.CodeActivity BuscarRequisicoes;











































    }
}
