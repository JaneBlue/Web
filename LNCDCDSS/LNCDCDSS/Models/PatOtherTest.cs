//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LNCDCDSS.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class PatOtherTest
    {
        public int Id { get; set; }
        public string Vocabulary1 { get; set; }
        public string Vocabulary2 { get; set; }
        public string Vocabulary3 { get; set; }
        public string Picture1 { get; set; }
        public string Picture2 { get; set; }
        public string ConnectNumber1 { get; set; }
        public string ConnectNumber2 { get; set; }
        public string Vocabulary4 { get; set; }
        public string VocabularyAnalyse1 { get; set; }
        public string Picture3 { get; set; }
        public string VocabularyAnalyse2 { get; set; }
        public string PatCDR { get; set; }
        public string PatGDS { get; set; }
    
        public virtual VisitRecord VisitRecord { get; set; }
    }
}
