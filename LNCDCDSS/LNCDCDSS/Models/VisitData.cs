using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LNCDCDSS.Models
{
    public class VisitData
    {
        public PatMMSE pme{ get; set; }
        public PatMoCA pma{ get; set; }
        public PatADL pal{ get; set; }
        public PatDisease pds { get; set; }
        public PatOtherTest pot{ get; set; }
        public PatPhysicalExam ppe{ get; set; }
        public PatLabExam ple{ get; set; }
        public List<PatRecentDrug> prd { get; set; }
        //public List<Drug> drug{ get; set; }
        public VisitRecord vsr { get; set; }
    }
}