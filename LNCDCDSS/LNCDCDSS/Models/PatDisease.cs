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
    
    public partial class PatDisease
    {
        public PatDisease()
        {
            this.D1 = new Exam();
            this.D2 = new Exam();
            this.D3 = new Exam();
            this.D4 = new Exam();
            this.D5 = new Exam();
            this.D6 = new Exam();
            this.D7 = new Exam();
            this.D8 = new Exam();
            this.D9 = new Exam();
            this.D10 = new Exam();
            this.D11 = new Exam();
            this.D12 = new Exam();
            this.D13 = new Exam();
            this.D14 = new Exam();
            this.D15 = new Exam();
            this.D16 = new Exam();
            this.D17 = new Exam();
            this.D18 = new Exam();
            this.D19 = new Exam();
            this.D20 = new Exam();
            this.D21 = new Exam();
            this.ImportantD = new Exam();
        }
    
        public int Id { get; set; }
        public int PatBasicInforId { get; set; }
    
        public Exam D1 { get; set; }
        public Exam D2 { get; set; }
        public Exam D3 { get; set; }
        public Exam D4 { get; set; }
        public Exam D5 { get; set; }
        public Exam D6 { get; set; }
        public Exam D7 { get; set; }
        public Exam D8 { get; set; }
        public Exam D9 { get; set; }
        public Exam D10 { get; set; }
        public Exam D11 { get; set; }
        public Exam D12 { get; set; }
        public Exam D13 { get; set; }
        public Exam D14 { get; set; }
        public Exam D15 { get; set; }
        public Exam D16 { get; set; }
        public Exam D17 { get; set; }
        public Exam D18 { get; set; }
        public Exam D19 { get; set; }
        public Exam D20 { get; set; }
        public Exam D21 { get; set; }
        public Exam ImportantD { get; set; }
    
        public virtual PatBasicInfor PatBasicInfor { get; set; }
    }
}
