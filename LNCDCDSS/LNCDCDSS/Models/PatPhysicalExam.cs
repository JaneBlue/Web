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
    
    public partial class PatPhysicalExam
    {
        public PatPhysicalExam()
        {
            this.B1 = new BodyExam();
            this.B2 = new BodyExam();
            this.B3 = new BodyExam();
            this.B4 = new BodyExam();
            this.B5 = new BodyExam();
            this.B6 = new BodyExam();
            this.B7 = new BodyExam();
            this.B8 = new BodyExam();
            this.B9 = new BodyExam();
            this.B10 = new BodyExam();
            this.B11 = new BodyExam();
            this.B12 = new BodyExam();
            this.B12a = new BodyExam();
            this.B12b = new BodyExam();
            this.B12c = new BodyExam();
            this.B12d = new BodyExam();
            this.B12e = new BodyExam();
            this.B12f = new BodyExam();
        }
    
        public int Id { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public string Waistline { get; set; }
        public string Hipline { get; set; }
        public string BloodPressureH { get; set; }
        public string BloodPressureL { get; set; }
    
        public BodyExam B1 { get; set; }
        public BodyExam B2 { get; set; }
        public BodyExam B3 { get; set; }
        public BodyExam B4 { get; set; }
        public BodyExam B5 { get; set; }
        public BodyExam B6 { get; set; }
        public BodyExam B7 { get; set; }
        public BodyExam B8 { get; set; }
        public BodyExam B9 { get; set; }
        public BodyExam B10 { get; set; }
        public BodyExam B11 { get; set; }
        public BodyExam B12 { get; set; }
        public BodyExam B12a { get; set; }
        public BodyExam B12b { get; set; }
        public BodyExam B12c { get; set; }
        public BodyExam B12d { get; set; }
        public BodyExam B12e { get; set; }
        public BodyExam B12f { get; set; }
    
        public virtual PatBasicInfor PatBasicInfor_1 { get; set; }
    }
}
