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
    
    public partial class PatRecentDrug
    {
        public PatRecentDrug()
        {
            this.Drug = new HashSet<Drug>();
        }
    
        public int Id { get; set; }
        public string Drugcatogary { get; set; }
        public int VisitRecordId { get; set; }
    
        public virtual VisitRecord VisitRecord { get; set; }
        public virtual ICollection<Drug> Drug { get; set; }
    }
}
