﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Negocio.ServicoSeguranca {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServicoSeguranca.IServicoControleAcesso")]
    public interface IServicoControleAcesso {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicoControleAcesso/ValidarAcesso", ReplyAction="http://tempuri.org/IServicoControleAcesso/ValidarAcessoResponse")]
        bool ValidarAcesso(string usuario, string senha, string servico);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicoControleAcesso/ValidarAcesso", ReplyAction="http://tempuri.org/IServicoControleAcesso/ValidarAcessoResponse")]
        System.Threading.Tasks.Task<bool> ValidarAcessoAsync(string usuario, string senha, string servico);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServicoControleAcessoChannel : Negocio.ServicoSeguranca.IServicoControleAcesso, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServicoControleAcessoClient : System.ServiceModel.ClientBase<Negocio.ServicoSeguranca.IServicoControleAcesso>, Negocio.ServicoSeguranca.IServicoControleAcesso {
        
        public ServicoControleAcessoClient() {
        }
        
        public ServicoControleAcessoClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServicoControleAcessoClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServicoControleAcessoClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServicoControleAcessoClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool ValidarAcesso(string usuario, string senha, string servico) {
            return base.Channel.ValidarAcesso(usuario, senha, servico);
        }
        
        public System.Threading.Tasks.Task<bool> ValidarAcessoAsync(string usuario, string senha, string servico) {
            return base.Channel.ValidarAcessoAsync(usuario, senha, servico);
        }
    }
}
