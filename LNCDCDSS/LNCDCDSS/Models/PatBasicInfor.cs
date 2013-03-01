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
    
    public partial class PatBasicInfor
    {
        public PatBasicInfor()
        {
            this.VisitRecord = new HashSet<VisitRecord>();
        }
    
        public int Id { get; set; }
        public int DoctorAccountId { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }
        public string Age { get; set; }
        public string Education { get; set; }
        public string Job { get; set; }
        public string Phone { get; set; }
        public string FamilyMember { get; set; }
        public string ChiefDoctor { get; set; }
    
        public virtual PatPhysicalExam PatExam_1 { get; set; }
        public virtual PatDisease PatDisease { get; set; }
        public virtual DoctorAccount DoctorAccount { get; set; }
        public virtual ICollection<VisitRecord> VisitRecord { get; set; }
    }
}
