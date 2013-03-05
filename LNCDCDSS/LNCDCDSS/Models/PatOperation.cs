using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LNCDCDSS.Models
{
    public class PatOperation
    {
        LNCDDataModelContainer context = new LNCDDataModelContainer();
        public IEnumerable<PatBasicInfor> GetPats()
        {
            return context.PatBasicInforSet.ToList();
        }
        public void InsertPat(PatBasicInfor pat, string PID, string HID)
        {
            pat.Id = System.Guid.NewGuid().ToString().Replace("-", "");
            context.PatBasicInforSet.Add(pat);
            
            VisitRecord r = new VisitRecord();
            r.PatBasicInforId = pat.Id;
            r.HospitalID = HID;
            r.OutpatientID = PID;
            context.VisitRecordSet.Add(r);
        }

    }
}