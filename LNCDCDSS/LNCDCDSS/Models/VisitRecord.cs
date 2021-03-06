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
    
    public partial class VisitRecord
    {
        public VisitRecord()
        {
            this.PatRecentDrug = new HashSet<PatRecentDrug>();
        }
    
        public int Id { get; set; }
        public string PatBasicInforId { get; set; }
        public string VisitRecordID { get; set; }
        public string DiagnosisiResult { get; set; }
        public string CDSSDiagnosis { get; set; }
        public string RecordNote { get; set; }
        public string OutpatientID { get; set; }
        public string HospitalID { get; set; }
        public System.DateTime VisitDate { get; set; }
    
        public virtual PatADL PatADL { get; set; }
        public virtual PatMoCA PatMoCA { get; set; }
        public virtual PatOtherTest PatOtherTest { get; set; }
        public virtual PatMMSE PatMMSE { get; set; }
        public virtual PatBasicInfor PatBasicInfor { get; set; }
        public virtual PatLabExam PatLabExam { get; set; }
        public virtual ICollection<PatRecentDrug> PatRecentDrug { get; set; }
    }
}
