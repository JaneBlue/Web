﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.586
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.586.
// 
#pragma warning disable 1591

namespace LNCDCDSS.LocalAQLExecute {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.ComponentModel;
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="AQLExecuteImplServiceSoapBinding", Namespace="http://ws.adr/")]
    public partial class AQLExecuteImplService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback updateOperationCompleted;
        
        private System.Threading.SendOrPostCallback insertOperationCompleted;
        
        private System.Threading.SendOrPostCallback reconfigureOperationCompleted;
        
        private System.Threading.SendOrPostCallback selectOperationCompleted;
        
        private System.Threading.SendOrPostCallback registerArmOperationCompleted;
        
        private System.Threading.SendOrPostCallback selectParaOperationCompleted;
        
        private System.Threading.SendOrPostCallback registerArchetypeOperationCompleted;
        
        private System.Threading.SendOrPostCallback deleteOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public AQLExecuteImplService() {
            this.Url = global::LNCDCDSS.Properties.Settings.Default.LNCDCDSS_LocalAQLExecute_AQLExecuteImplService;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event updateCompletedEventHandler updateCompleted;
        
        /// <remarks/>
        public event insertCompletedEventHandler insertCompleted;
        
        /// <remarks/>
        public event reconfigureCompletedEventHandler reconfigureCompleted;
        
        /// <remarks/>
        public event selectCompletedEventHandler selectCompleted;
        
        /// <remarks/>
        public event registerArmCompletedEventHandler registerArmCompleted;
        
        /// <remarks/>
        public event selectParaCompletedEventHandler selectParaCompleted;
        
        /// <remarks/>
        public event registerArchetypeCompletedEventHandler registerArchetypeCompleted;
        
        /// <remarks/>
        public event deleteCompletedEventHandler deleteCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("", RequestNamespace="http://ws.adr/", ResponseNamespace="http://ws.adr/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int update([System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string arg0) {
            object[] results = this.Invoke("update", new object[] {
                        arg0});
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        public void updateAsync(string arg0) {
            this.updateAsync(arg0, null);
        }
        
        /// <remarks/>
        public void updateAsync(string arg0, object userState) {
            if ((this.updateOperationCompleted == null)) {
                this.updateOperationCompleted = new System.Threading.SendOrPostCallback(this.OnupdateOperationCompleted);
            }
            this.InvokeAsync("update", new object[] {
                        arg0}, this.updateOperationCompleted, userState);
        }
        
        private void OnupdateOperationCompleted(object arg) {
            if ((this.updateCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.updateCompleted(this, new updateCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("", RequestNamespace="http://ws.adr/", ResponseNamespace="http://ws.adr/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void insert([System.Xml.Serialization.XmlElementAttribute("arg0", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string[] arg0) {
            this.Invoke("insert", new object[] {
                        arg0});
        }
        
        /// <remarks/>
        public void insertAsync(string[] arg0) {
            this.insertAsync(arg0, null);
        }
        
        /// <remarks/>
        public void insertAsync(string[] arg0, object userState) {
            if ((this.insertOperationCompleted == null)) {
                this.insertOperationCompleted = new System.Threading.SendOrPostCallback(this.OninsertOperationCompleted);
            }
            this.InvokeAsync("insert", new object[] {
                        arg0}, this.insertOperationCompleted, userState);
        }
        
        private void OninsertOperationCompleted(object arg) {
            if ((this.insertCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.insertCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("", RequestNamespace="http://ws.adr/", ResponseNamespace="http://ws.adr/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void reconfigure([System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] out bool @return, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] [System.Xml.Serialization.XmlIgnoreAttribute()] out bool returnSpecified) {
            object[] results = this.Invoke("reconfigure", new object[0]);
            @return = ((bool)(results[0]));
            returnSpecified = ((bool)(results[1]));
        }
        
        /// <remarks/>
        public void reconfigureAsync() {
            this.reconfigureAsync(null);
        }
        
        /// <remarks/>
        public void reconfigureAsync(object userState) {
            if ((this.reconfigureOperationCompleted == null)) {
                this.reconfigureOperationCompleted = new System.Threading.SendOrPostCallback(this.OnreconfigureOperationCompleted);
            }
            this.InvokeAsync("reconfigure", new object[0], this.reconfigureOperationCompleted, userState);
        }
        
        private void OnreconfigureOperationCompleted(object arg) {
            if ((this.reconfigureCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.reconfigureCompleted(this, new reconfigureCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("", RequestNamespace="http://ws.adr/", ResponseNamespace="http://ws.adr/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string[] select([System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string arg0, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string arg1) {
            object[] results = this.Invoke("select", new object[] {
                        arg0,
                        arg1});
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        public void selectAsync(string arg0, string arg1) {
            this.selectAsync(arg0, arg1, null);
        }
        
        /// <remarks/>
        public void selectAsync(string arg0, string arg1, object userState) {
            if ((this.selectOperationCompleted == null)) {
                this.selectOperationCompleted = new System.Threading.SendOrPostCallback(this.OnselectOperationCompleted);
            }
            this.InvokeAsync("select", new object[] {
                        arg0,
                        arg1}, this.selectOperationCompleted, userState);
        }
        
        private void OnselectOperationCompleted(object arg) {
            if ((this.selectCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.selectCompleted(this, new selectCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("", RequestNamespace="http://ws.adr/", ResponseNamespace="http://ws.adr/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string registerArm([System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string arg0, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string arg1) {
            object[] results = this.Invoke("registerArm", new object[] {
                        arg0,
                        arg1});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void registerArmAsync(string arg0, string arg1) {
            this.registerArmAsync(arg0, arg1, null);
        }
        
        /// <remarks/>
        public void registerArmAsync(string arg0, string arg1, object userState) {
            if ((this.registerArmOperationCompleted == null)) {
                this.registerArmOperationCompleted = new System.Threading.SendOrPostCallback(this.OnregisterArmOperationCompleted);
            }
            this.InvokeAsync("registerArm", new object[] {
                        arg0,
                        arg1}, this.registerArmOperationCompleted, userState);
        }
        
        private void OnregisterArmOperationCompleted(object arg) {
            if ((this.registerArmCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.registerArmCompleted(this, new registerArmCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("", RequestNamespace="http://ws.adr/", ResponseNamespace="http://ws.adr/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string[] selectPara([System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string arg0, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string arg1, [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] [System.Xml.Serialization.XmlArrayItemAttribute("entry", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)] selectParaEntry[] arg2) {
            object[] results = this.Invoke("selectPara", new object[] {
                        arg0,
                        arg1,
                        arg2});
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        public void selectParaAsync(string arg0, string arg1, selectParaEntry[] arg2) {
            this.selectParaAsync(arg0, arg1, arg2, null);
        }
        
        /// <remarks/>
        public void selectParaAsync(string arg0, string arg1, selectParaEntry[] arg2, object userState) {
            if ((this.selectParaOperationCompleted == null)) {
                this.selectParaOperationCompleted = new System.Threading.SendOrPostCallback(this.OnselectParaOperationCompleted);
            }
            this.InvokeAsync("selectPara", new object[] {
                        arg0,
                        arg1,
                        arg2}, this.selectParaOperationCompleted, userState);
        }
        
        private void OnselectParaOperationCompleted(object arg) {
            if ((this.selectParaCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.selectParaCompleted(this, new selectParaCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("", RequestNamespace="http://ws.adr/", ResponseNamespace="http://ws.adr/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string registerArchetype([System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string arg0, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string arg1) {
            object[] results = this.Invoke("registerArchetype", new object[] {
                        arg0,
                        arg1});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void registerArchetypeAsync(string arg0, string arg1) {
            this.registerArchetypeAsync(arg0, arg1, null);
        }
        
        /// <remarks/>
        public void registerArchetypeAsync(string arg0, string arg1, object userState) {
            if ((this.registerArchetypeOperationCompleted == null)) {
                this.registerArchetypeOperationCompleted = new System.Threading.SendOrPostCallback(this.OnregisterArchetypeOperationCompleted);
            }
            this.InvokeAsync("registerArchetype", new object[] {
                        arg0,
                        arg1}, this.registerArchetypeOperationCompleted, userState);
        }
        
        private void OnregisterArchetypeOperationCompleted(object arg) {
            if ((this.registerArchetypeCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.registerArchetypeCompleted(this, new registerArchetypeCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("", RequestNamespace="http://ws.adr/", ResponseNamespace="http://ws.adr/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int delete([System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string arg0) {
            object[] results = this.Invoke("delete", new object[] {
                        arg0});
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        public void deleteAsync(string arg0) {
            this.deleteAsync(arg0, null);
        }
        
        /// <remarks/>
        public void deleteAsync(string arg0, object userState) {
            if ((this.deleteOperationCompleted == null)) {
                this.deleteOperationCompleted = new System.Threading.SendOrPostCallback(this.OndeleteOperationCompleted);
            }
            this.InvokeAsync("delete", new object[] {
                        arg0}, this.deleteOperationCompleted, userState);
        }
        
        private void OndeleteOperationCompleted(object arg) {
            if ((this.deleteCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.deleteCompleted(this, new deleteCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.450")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://ws.adr/")]
    public partial class selectParaEntry {
        
        private string keyField;
        
        private string valueField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string key {
            get {
                return this.keyField;
            }
            set {
                this.keyField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string value {
            get {
                return this.valueField;
            }
            set {
                this.valueField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void updateCompletedEventHandler(object sender, updateCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class updateCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal updateCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public int Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((int)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void insertCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void reconfigureCompletedEventHandler(object sender, reconfigureCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class reconfigureCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal reconfigureCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public bool @return {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
        
        /// <remarks/>
        public bool returnSpecified {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[1]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void selectCompletedEventHandler(object sender, selectCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class selectCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal selectCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void registerArmCompletedEventHandler(object sender, registerArmCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class registerArmCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal registerArmCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void selectParaCompletedEventHandler(object sender, selectParaCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class selectParaCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal selectParaCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void registerArchetypeCompletedEventHandler(object sender, registerArchetypeCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class registerArchetypeCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal registerArchetypeCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void deleteCompletedEventHandler(object sender, deleteCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class deleteCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal deleteCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public int Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((int)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591