using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Validation;
using System.Diagnostics;
namespace LNCDCDSS.Models
{
    public class PatOperation
    {
        LNCDDataModelContainer context = new LNCDDataModelContainer();
        public IEnumerable<PatBasicInfor> GetPats()
        {
            return context.PatBasicInforSet.ToList();
        }
        public void InsertPat(PatBasicInfor pat, string PID, string HID,string User)
        {

            try
            {
                pat.Id = System.Guid.NewGuid().ToString().Replace("-", "");
                pat.DoctorAccountId = 1;
                PatPhysicalExam pexam = new PatPhysicalExam();
                // pexam.Id = 1;
                //pexam.PatBasicInforId = pat.Id;
                pat.PatPhysicalExam = pexam;
                PatDisease pdisease = new PatDisease();
                // pdisease.Id = 1;
                pdisease.PatBasicInforId = pat.Id;
                pat.PatDisease = pdisease;

                VisitRecord r = new VisitRecord();
                r.PatBasicInforId = pat.Id;
                r.HospitalID = HID;
                r.OutpatientID = PID;
                r.VisitRecordID = "1";
                r.VisitDate = DateTime.Now.Date;
                pat.VisitRecord.Add(r);
                //context.PatBasicInforSet.Add(pat);
                var students = from s in context.DoctorAccountSet.ToList() select s;
                DoctorAccount student = students.Where(s => s.UserName == User).FirstOrDefault();
                student.PatBasicInfor.Add(pat);

                context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
            }
        }

    }
}