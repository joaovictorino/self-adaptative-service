//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Negocio.ServicoCalendario {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServicoCalendario.IServicoCalendario")]
    public interface IServicoCalendario {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicoCalendario/VerificarFeriado", ReplyAction="http://tempuri.org/IServicoCalendario/VerificarFeriadoResponse")]
        bool VerificarFeriado(System.DateTime data);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicoCalendario/VerificarFeriado", ReplyAction="http://tempuri.org/IServicoCalendario/VerificarFeriadoResponse")]
        System.Threading.Tasks.Task<bool> VerificarFeriadoAsync(System.DateTime data);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServicoCalendarioChannel : Negocio.ServicoCalendario.IServicoCalendario, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServicoCalendarioClient : System.ServiceModel.ClientBase<Negocio.ServicoCalendario.IServicoCalendario>, Negocio.ServicoCalendario.IServicoCalendario {
        
        public ServicoCalendarioClient() {
        }
        
        public ServicoCalendarioClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServicoCalendarioClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServicoCalendarioClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServicoCalendarioClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool VerificarFeriado(System.DateTime data) {
            return base.Channel.VerificarFeriado(data);
        }
        
        public System.Threading.Tasks.Task<bool> VerificarFeriadoAsync(System.DateTime data) {
            return base.Channel.VerificarFeriadoAsync(data);
        }
    }
}
