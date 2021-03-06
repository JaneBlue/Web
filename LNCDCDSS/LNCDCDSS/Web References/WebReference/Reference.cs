﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.296
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.296.
// 
#pragma warning disable 1591

namespace LNCDCDSS.WebReference {
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
    [System.Web.Services.WebServiceBindingAttribute(Name="InferenceServiceSoap", Namespace="http://ADMCI.org/")]
    public partial class InferenceService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback DoInferenceOperationCompleted;
        
        private System.Threading.SendOrPostCallback DoTrainingOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public InferenceService() {
            this.Url = global::LNCDCDSS.Properties.Settings.Default.LNCDCDSS_WebReference_InferenceService;
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
        public event DoInferenceCompletedEventHandler DoInferenceCompleted;
        
        /// <remarks/>
        public event DoTrainingCompletedEventHandler DoTrainingCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://ADMCI.org/DoInference", RequestNamespace="http://ADMCI.org/", ResponseNamespace="http://ADMCI.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool DoInference(InputData InputDataValue, ref string strResult, ref double dProbalily) {
            object[] results = this.Invoke("DoInference", new object[] {
                        InputDataValue,
                        strResult,
                        dProbalily});
            strResult = ((string)(results[1]));
            dProbalily = ((double)(results[2]));
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void DoInferenceAsync(InputData InputDataValue, string strResult, double dProbalily) {
            this.DoInferenceAsync(InputDataValue, strResult, dProbalily, null);
        }
        
        /// <remarks/>
        public void DoInferenceAsync(InputData InputDataValue, string strResult, double dProbalily, object userState) {
            if ((this.DoInferenceOperationCompleted == null)) {
                this.DoInferenceOperationCompleted = new System.Threading.SendOrPostCallback(this.OnDoInferenceOperationCompleted);
            }
            this.InvokeAsync("DoInference", new object[] {
                        InputDataValue,
                        strResult,
                        dProbalily}, this.DoInferenceOperationCompleted, userState);
        }
        
        private void OnDoInferenceOperationCompleted(object arg) {
            if ((this.DoInferenceCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.DoInferenceCompleted(this, new DoInferenceCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://ADMCI.org/DoTraining", RequestNamespace="http://ADMCI.org/", ResponseNamespace="http://ADMCI.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool DoTraining(InputData InputDataValue) {
            object[] results = this.Invoke("DoTraining", new object[] {
                        InputDataValue});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void DoTrainingAsync(InputData InputDataValue) {
            this.DoTrainingAsync(InputDataValue, null);
        }
        
        /// <remarks/>
        public void DoTrainingAsync(InputData InputDataValue, object userState) {
            if ((this.DoTrainingOperationCompleted == null)) {
                this.DoTrainingOperationCompleted = new System.Threading.SendOrPostCallback(this.OnDoTrainingOperationCompleted);
            }
            this.InvokeAsync("DoTraining", new object[] {
                        InputDataValue}, this.DoTrainingOperationCompleted, userState);
        }
        
        private void OnDoTrainingOperationCompleted(object arg) {
            if ((this.DoTrainingCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.DoTrainingCompleted(this, new DoTrainingCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.233")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://ADMCI.org/")]
    public partial class InputData {
        
        private double timeorientationField;
        
        private double placeorientationField;
        
        private double languageimmediaterecallField;
        
        private double attentionandcalculationField;
        
        private double shortmemoryField;
        
        private double namingobjectsField;
        
        private double languageretellField;
        
        private double readingcomprehensionField;
        
        private double languageunderstandingField;
        
        private double languageexpressionField;
        
        private double drawgraphField;
        
        private double visualspaceandexecutiveabilityField;
        
        private double namingField;
        
        private double memoryField;
        
        private double attentionField;
        
        private double languageField;
        
        private double animalnumberField;
        
        private double abstractabilityField;
        
        private double moCadelayrecallField;
        
        private double orientaionField;
        
        private double physicalSelfmaintenanceField;
        
        private double grippingabilityField;
        
        private double word1Field;
        
        private double word2Field;
        
        private double word3Field;
        
        private double wordaverageField;
        
        private double worddelayrecallField;
        
        private double originalwordrecognitionField;
        
        private double newwordrecognizeField;
        
        private double graphcopyField;
        
        private double graphimmediaterecallField;
        
        private double graphdelayrecallField;
        
        private double lineAField;
        
        private double lineBField;
        
        private double gDSField;
        
        private double cDRField;
        
        private string strResultField;
        
        /// <remarks/>
        public double timeorientation {
            get {
                return this.timeorientationField;
            }
            set {
                this.timeorientationField = value;
            }
        }
        
        /// <remarks/>
        public double placeorientation {
            get {
                return this.placeorientationField;
            }
            set {
                this.placeorientationField = value;
            }
        }
        
        /// <remarks/>
        public double Languageimmediaterecall {
            get {
                return this.languageimmediaterecallField;
            }
            set {
                this.languageimmediaterecallField = value;
            }
        }
        
        /// <remarks/>
        public double Attentionandcalculation {
            get {
                return this.attentionandcalculationField;
            }
            set {
                this.attentionandcalculationField = value;
            }
        }
        
        /// <remarks/>
        public double shortmemory {
            get {
                return this.shortmemoryField;
            }
            set {
                this.shortmemoryField = value;
            }
        }
        
        /// <remarks/>
        public double namingobjects {
            get {
                return this.namingobjectsField;
            }
            set {
                this.namingobjectsField = value;
            }
        }
        
        /// <remarks/>
        public double languageretell {
            get {
                return this.languageretellField;
            }
            set {
                this.languageretellField = value;
            }
        }
        
        /// <remarks/>
        public double readingcomprehension {
            get {
                return this.readingcomprehensionField;
            }
            set {
                this.readingcomprehensionField = value;
            }
        }
        
        /// <remarks/>
        public double languageunderstanding {
            get {
                return this.languageunderstandingField;
            }
            set {
                this.languageunderstandingField = value;
            }
        }
        
        /// <remarks/>
        public double languageexpression {
            get {
                return this.languageexpressionField;
            }
            set {
                this.languageexpressionField = value;
            }
        }
        
        /// <remarks/>
        public double drawgraph {
            get {
                return this.drawgraphField;
            }
            set {
                this.drawgraphField = value;
            }
        }
        
        /// <remarks/>
        public double Visualspaceandexecutiveability {
            get {
                return this.visualspaceandexecutiveabilityField;
            }
            set {
                this.visualspaceandexecutiveabilityField = value;
            }
        }
        
        /// <remarks/>
        public double naming {
            get {
                return this.namingField;
            }
            set {
                this.namingField = value;
            }
        }
        
        /// <remarks/>
        public double memory {
            get {
                return this.memoryField;
            }
            set {
                this.memoryField = value;
            }
        }
        
        /// <remarks/>
        public double attention {
            get {
                return this.attentionField;
            }
            set {
                this.attentionField = value;
            }
        }
        
        /// <remarks/>
        public double language {
            get {
                return this.languageField;
            }
            set {
                this.languageField = value;
            }
        }
        
        /// <remarks/>
        public double animalnumber {
            get {
                return this.animalnumberField;
            }
            set {
                this.animalnumberField = value;
            }
        }
        
        /// <remarks/>
        public double abstractability {
            get {
                return this.abstractabilityField;
            }
            set {
                this.abstractabilityField = value;
            }
        }
        
        /// <remarks/>
        public double MoCadelayrecall {
            get {
                return this.moCadelayrecallField;
            }
            set {
                this.moCadelayrecallField = value;
            }
        }
        
        /// <remarks/>
        public double orientaion {
            get {
                return this.orientaionField;
            }
            set {
                this.orientaionField = value;
            }
        }
        
        /// <remarks/>
        public double PhysicalSelfmaintenance {
            get {
                return this.physicalSelfmaintenanceField;
            }
            set {
                this.physicalSelfmaintenanceField = value;
            }
        }
        
        /// <remarks/>
        public double grippingability {
            get {
                return this.grippingabilityField;
            }
            set {
                this.grippingabilityField = value;
            }
        }
        
        /// <remarks/>
        public double word1 {
            get {
                return this.word1Field;
            }
            set {
                this.word1Field = value;
            }
        }
        
        /// <remarks/>
        public double word2 {
            get {
                return this.word2Field;
            }
            set {
                this.word2Field = value;
            }
        }
        
        /// <remarks/>
        public double word3 {
            get {
                return this.word3Field;
            }
            set {
                this.word3Field = value;
            }
        }
        
        /// <remarks/>
        public double wordaverage {
            get {
                return this.wordaverageField;
            }
            set {
                this.wordaverageField = value;
            }
        }
        
        /// <remarks/>
        public double worddelayrecall {
            get {
                return this.worddelayrecallField;
            }
            set {
                this.worddelayrecallField = value;
            }
        }
        
        /// <remarks/>
        public double originalwordrecognition {
            get {
                return this.originalwordrecognitionField;
            }
            set {
                this.originalwordrecognitionField = value;
            }
        }
        
        /// <remarks/>
        public double Newwordrecognize {
            get {
                return this.newwordrecognizeField;
            }
            set {
                this.newwordrecognizeField = value;
            }
        }
        
        /// <remarks/>
        public double graphcopy {
            get {
                return this.graphcopyField;
            }
            set {
                this.graphcopyField = value;
            }
        }
        
        /// <remarks/>
        public double graphimmediaterecall {
            get {
                return this.graphimmediaterecallField;
            }
            set {
                this.graphimmediaterecallField = value;
            }
        }
        
        /// <remarks/>
        public double graphdelayrecall {
            get {
                return this.graphdelayrecallField;
            }
            set {
                this.graphdelayrecallField = value;
            }
        }
        
        /// <remarks/>
        public double lineA {
            get {
                return this.lineAField;
            }
            set {
                this.lineAField = value;
            }
        }
        
        /// <remarks/>
        public double lineB {
            get {
                return this.lineBField;
            }
            set {
                this.lineBField = value;
            }
        }
        
        /// <remarks/>
        public double GDS {
            get {
                return this.gDSField;
            }
            set {
                this.gDSField = value;
            }
        }
        
        /// <remarks/>
        public double CDR {
            get {
                return this.cDRField;
            }
            set {
                this.cDRField = value;
            }
        }
        
        /// <remarks/>
        public string strResult {
            get {
                return this.strResultField;
            }
            set {
                this.strResultField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void DoInferenceCompletedEventHandler(object sender, DoInferenceCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class DoInferenceCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal DoInferenceCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public bool Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
        
        /// <remarks/>
        public string strResult {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[1]));
            }
        }
        
        /// <remarks/>
        public double dProbalily {
            get {
                this.RaiseExceptionIfNecessary();
                return ((double)(this.results[2]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void DoTrainingCompletedEventHandler(object sender, DoTrainingCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class DoTrainingCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal DoTrainingCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public bool Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591