﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Cliente.Servico {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="RequestInterpolador", Namespace="http://schemas.datacontract.org/2004/07/Negocio.DTOs")]
    [System.SerializableAttribute()]
    public partial class RequestInterpolador : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DominioField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Cliente.Servico.Execucao ExecucaoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SenhaField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UsuarioField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Dominio {
            get {
                return this.DominioField;
            }
            set {
                if ((object.ReferenceEquals(this.DominioField, value) != true)) {
                    this.DominioField = value;
                    this.RaisePropertyChanged("Dominio");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Cliente.Servico.Execucao Execucao {
            get {
                return this.ExecucaoField;
            }
            set {
                if ((object.ReferenceEquals(this.ExecucaoField, value) != true)) {
                    this.ExecucaoField = value;
                    this.RaisePropertyChanged("Execucao");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Senha {
            get {
                return this.SenhaField;
            }
            set {
                if ((object.ReferenceEquals(this.SenhaField, value) != true)) {
                    this.SenhaField = value;
                    this.RaisePropertyChanged("Senha");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Usuario {
            get {
                return this.UsuarioField;
            }
            set {
                if ((object.ReferenceEquals(this.UsuarioField, value) != true)) {
                    this.UsuarioField = value;
                    this.RaisePropertyChanged("Usuario");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Execucao", Namespace="http://schemas.datacontract.org/2004/07/DTO")]
    [System.SerializableAttribute()]
    public partial class Execucao : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int AnosExtensaoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Cliente.Servico.TipoInterpolacao AntepolacaoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Cliente.Servico.TipoBaseDias BaseDiasField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime DataBaseField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime DataHoraExecucaoCurvaField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Cliente.Servico.TipoInterpolacao ExtrapolacaoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Cliente.Servico.TipoInterpolacao InterpolacaoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NomeCurvaField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Collections.Generic.List<Cliente.Servico.CurvaExecucaoPonto> PontosField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Cliente.Servico.TipoVertice VerticeField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int AnosExtensao {
            get {
                return this.AnosExtensaoField;
            }
            set {
                if ((this.AnosExtensaoField.Equals(value) != true)) {
                    this.AnosExtensaoField = value;
                    this.RaisePropertyChanged("AnosExtensao");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Cliente.Servico.TipoInterpolacao Antepolacao {
            get {
                return this.AntepolacaoField;
            }
            set {
                if ((this.AntepolacaoField.Equals(value) != true)) {
                    this.AntepolacaoField = value;
                    this.RaisePropertyChanged("Antepolacao");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Cliente.Servico.TipoBaseDias BaseDias {
            get {
                return this.BaseDiasField;
            }
            set {
                if ((this.BaseDiasField.Equals(value) != true)) {
                    this.BaseDiasField = value;
                    this.RaisePropertyChanged("BaseDias");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime DataBase {
            get {
                return this.DataBaseField;
            }
            set {
                if ((this.DataBaseField.Equals(value) != true)) {
                    this.DataBaseField = value;
                    this.RaisePropertyChanged("DataBase");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime DataHoraExecucaoCurva {
            get {
                return this.DataHoraExecucaoCurvaField;
            }
            set {
                if ((this.DataHoraExecucaoCurvaField.Equals(value) != true)) {
                    this.DataHoraExecucaoCurvaField = value;
                    this.RaisePropertyChanged("DataHoraExecucaoCurva");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Cliente.Servico.TipoInterpolacao Extrapolacao {
            get {
                return this.ExtrapolacaoField;
            }
            set {
                if ((this.ExtrapolacaoField.Equals(value) != true)) {
                    this.ExtrapolacaoField = value;
                    this.RaisePropertyChanged("Extrapolacao");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Cliente.Servico.TipoInterpolacao Interpolacao {
            get {
                return this.InterpolacaoField;
            }
            set {
                if ((this.InterpolacaoField.Equals(value) != true)) {
                    this.InterpolacaoField = value;
                    this.RaisePropertyChanged("Interpolacao");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string NomeCurva {
            get {
                return this.NomeCurvaField;
            }
            set {
                if ((object.ReferenceEquals(this.NomeCurvaField, value) != true)) {
                    this.NomeCurvaField = value;
                    this.RaisePropertyChanged("NomeCurva");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Collections.Generic.List<Cliente.Servico.CurvaExecucaoPonto> Pontos {
            get {
                return this.PontosField;
            }
            set {
                if ((object.ReferenceEquals(this.PontosField, value) != true)) {
                    this.PontosField = value;
                    this.RaisePropertyChanged("Pontos");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Cliente.Servico.TipoVertice Vertice {
            get {
                return this.VerticeField;
            }
            set {
                if ((this.VerticeField.Equals(value) != true)) {
                    this.VerticeField = value;
                    this.RaisePropertyChanged("Vertice");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="TipoInterpolacao", Namespace="http://schemas.datacontract.org/2004/07/DTO")]
    public enum TipoInterpolacao : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        EXPONENCIAL = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        LINEAR = 2,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="TipoBaseDias", Namespace="http://schemas.datacontract.org/2004/07/DTO")]
    public enum TipoBaseDias : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        BASE252 = 252,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        BASE360 = 360,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        BASE30 = 30,
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CurvaExecucaoPonto", Namespace="http://schemas.datacontract.org/2004/07/DTO")]
    [System.SerializableAttribute()]
    public partial class CurvaExecucaoPonto : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime DataVencimentoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double DurationDiasCorridosField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double DurationDiasUteisField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IndicadorVerticeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int QuantidadeDiasCorridosField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int QuantidadeDiasUteisField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double ValorVerticeField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime DataVencimento {
            get {
                return this.DataVencimentoField;
            }
            set {
                if ((this.DataVencimentoField.Equals(value) != true)) {
                    this.DataVencimentoField = value;
                    this.RaisePropertyChanged("DataVencimento");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double DurationDiasCorridos {
            get {
                return this.DurationDiasCorridosField;
            }
            set {
                if ((this.DurationDiasCorridosField.Equals(value) != true)) {
                    this.DurationDiasCorridosField = value;
                    this.RaisePropertyChanged("DurationDiasCorridos");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double DurationDiasUteis {
            get {
                return this.DurationDiasUteisField;
            }
            set {
                if ((this.DurationDiasUteisField.Equals(value) != true)) {
                    this.DurationDiasUteisField = value;
                    this.RaisePropertyChanged("DurationDiasUteis");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int IndicadorVertice {
            get {
                return this.IndicadorVerticeField;
            }
            set {
                if ((this.IndicadorVerticeField.Equals(value) != true)) {
                    this.IndicadorVerticeField = value;
                    this.RaisePropertyChanged("IndicadorVertice");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int QuantidadeDiasCorridos {
            get {
                return this.QuantidadeDiasCorridosField;
            }
            set {
                if ((this.QuantidadeDiasCorridosField.Equals(value) != true)) {
                    this.QuantidadeDiasCorridosField = value;
                    this.RaisePropertyChanged("QuantidadeDiasCorridos");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int QuantidadeDiasUteis {
            get {
                return this.QuantidadeDiasUteisField;
            }
            set {
                if ((this.QuantidadeDiasUteisField.Equals(value) != true)) {
                    this.QuantidadeDiasUteisField = value;
                    this.RaisePropertyChanged("QuantidadeDiasUteis");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double ValorVertice {
            get {
                return this.ValorVerticeField;
            }
            set {
                if ((this.ValorVerticeField.Equals(value) != true)) {
                    this.ValorVerticeField = value;
                    this.RaisePropertyChanged("ValorVertice");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="TipoVertice", Namespace="http://schemas.datacontract.org/2004/07/DTO")]
    public enum TipoVertice : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        FATOR_DIARIO = 3,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        PU = 4,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        TAXA = 7,
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ResponseInterpolador", Namespace="http://schemas.datacontract.org/2004/07/Negocio.DTOs")]
    [System.SerializableAttribute()]
    public partial class ResponseInterpolador : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Collections.Generic.List<Cliente.Servico.CurvaExecucaoPonto> PontosField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Collections.Generic.List<Cliente.Servico.CurvaExecucaoPonto> Pontos {
            get {
                return this.PontosField;
            }
            set {
                if ((object.ReferenceEquals(this.PontosField, value) != true)) {
                    this.PontosField = value;
                    this.RaisePropertyChanged("Pontos");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="Servico.IFacadeServico")]
    public interface IFacadeServico {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFacadeServico/Interpolar", ReplyAction="http://tempuri.org/IFacadeServico/InterpolarResponse")]
        Cliente.Servico.ResponseInterpolador Interpolar(Cliente.Servico.RequestInterpolador request);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IFacadeServicoChannel : Cliente.Servico.IFacadeServico, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class FacadeServicoClient : System.ServiceModel.ClientBase<Cliente.Servico.IFacadeServico>, Cliente.Servico.IFacadeServico {
        
        public FacadeServicoClient() {
        }
        
        public FacadeServicoClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public FacadeServicoClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public FacadeServicoClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public FacadeServicoClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Cliente.Servico.ResponseInterpolador Interpolar(Cliente.Servico.RequestInterpolador request) {
            return base.Channel.Interpolar(request);
        }
    }
}
