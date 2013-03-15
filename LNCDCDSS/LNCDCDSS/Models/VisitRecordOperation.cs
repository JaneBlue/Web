using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Diagnostics;
using System.Data.Entity.Validation;
namespace LNCDCDSS.Models
{
    public class VisitRecordOperation
    {
        LNCDDataModelContainer context = new LNCDDataModelContainer();
        public void InsertPatPhysicaExam(PatPhysicalExam PExam, string ID)
        {
            try
            {
                PatBasicInfor pt = context.PatBasicInforSet.Find(ID);
              //  pt.PatPhysicalExam = PExam;
             //   pt.PatPhysicalExam.B1=PExam.B1;
                ObjectMapper.CopyProperties(PExam, pt.PatPhysicalExam);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                string a = e.InnerException.Message;
            }
        }
        public void InsertPatDisease(PatDisease pdisease, string ID)
        {
            try
            {
                PatBasicInfor pt = context.PatBasicInforSet.Find(ID);
                pdisease.PatBasicInforId = "123";
                pdisease.PatBasicInforId = ID;
                pdisease.Id =pt.PatDisease.Id;
                ObjectMapper.CopyProperties(pdisease, pt.PatDisease);
              //  pt.PatDisease = pdisease;
                context.SaveChanges();
            }
            catch (Exception e)
            {
                string a = e.InnerException.Message;
            }
        }
        public void InsertPatLabExam(PatLabExam Plab, string ID)
        {
            try
            {
                PatBasicInfor pt = context.PatBasicInforSet.Find(ID);

                pt.VisitRecord.Last().PatLabExam = Plab;
                context.SaveChanges();
            }
            catch (Exception e)
            {
                string a = e.InnerException.Message;
            }
        }
        public void InsertPatotherTest(PatOtherTest Ptext, string ID)
        {
            try
            {
                VisitRecord pt = context.VisitRecordSet.Find(ID);
                pt.PatOtherTest = Ptext;
                context.SaveChanges();
            }
            catch (Exception e)
            {
                string a = e.InnerException.Message;
            }
        }
        public void InsertPatADL(PatADL pl, string ID)
        {
            try
            {
                PatBasicInfor pt = context.PatBasicInforSet.Find(ID);
                pt.VisitRecord.Last().PatADL = pl;
                context.SaveChanges();
            }
            catch (Exception e)
            {
                string a = e.InnerException.Message;
            }
        }
        public void InsertPatMMSE(PatMMSE pmm, string ID)
        {
            try
            {
                PatBasicInfor pt = context.PatBasicInforSet.Find(ID);
                pt.VisitRecord.Last().PatMMSE = pmm;
                context.SaveChanges();
            }
            catch (Exception e)
            {
                string a = e.InnerException.Message;
            }
        }
        public void InsertPatMoca(PatMoCA pm, string ID)
        {
            try
            {
                PatBasicInfor pt = context.PatBasicInforSet.Find(ID);
                pt.VisitRecord.Last().PatMoCA = pm;
                context.SaveChanges();
            }
            catch (Exception e)
            {
                string a = e.InnerException.Message;
            }
        }
        public void InsertPatRecentDrug(List<PatRecentDrug> PRdrug, string ID)
        {
            try
            {
                PatBasicInfor pt = context.PatBasicInforSet.Find(ID);
                pt.VisitRecord.Last().PatRecentDrug = PRdrug;
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

        public bool UpdateVisitRecord()
        {
            return true;

        }

        public List<string> GetVisitContet(string RecordID)
        {
            int recordId = int.Parse(RecordID);
            VisitRecord vd = context.VisitRecordSet.Find(recordId);
            List<string> conttext = new List<string>();
            // string test = vd.PatADL.Total + vd.PatMMSE.Total;

            try
            {
                string test = "";
                if (vd.PatMMSE != null)
                {
                    test += "MMSE=" + vd.PatMMSE.Total;
                }
                if (vd.PatMoCA != null)
                {
                    test += "MoCA= " + vd.PatMoCA.Total;
                }
                if (vd.PatOtherTest != null)
                {
                    test += "CDR= " + vd.PatOtherTest.PatCDR;
                }
                if (vd.PatOtherTest != null)
                {
                    test += "GDS= " + vd.PatOtherTest.PatGDS;
                }
                if (vd.PatADL != null)
                {
                    test += "ADL= " + vd.PatADL.Total;
                }
                if (vd.PatOtherTest != null)
                {
                    test += "词语学习1= " + vd.PatOtherTest.Vocabulary1;
                    test += "词语学习2= " + vd.PatOtherTest.Vocabulary2;
                    test += "词语学习3= " + vd.PatOtherTest.Vocabulary3;
                    test += " 延迟记忆= " + vd.PatOtherTest.Vocabulary4;
                    test += "原词辨认 =" + vd.PatOtherTest.VocabularyAnalyse1;
                    test += "新词辨认 =" + vd.PatOtherTest.VocabularyAnalyse2;
                    test += "图形复制 =" + vd.PatOtherTest.Picture1;
                    test += "即刻回忆 =" + vd.PatOtherTest.Picture2;
                    test += "延迟回忆 =" + vd.PatOtherTest.Picture3;
                    test += "连线A =" + vd.PatOtherTest.ConnectNumber1;
                    test += "连线B =" + vd.PatOtherTest.ConnectNumber2;
                }
                conttext.Add(test);
                conttext.Add(vd.RecordNote);
                conttext.Add(vd.DiagnosisiResult);
            }
            catch (Exception e)
            { }
            return conttext;
        }

        public ICollection<PatBasicInfor> GetPat(List<string> Condition)
        {

            string sql = "Select * from dbo.PatBasicInforSet ";
            if (!(Condition[0] != "" && Condition[1] != ""))
            {
                sql += "where ";
                if (Condition[0] != "")
                {
                    sql += " Name =" + "'" + Condition[0] + "'";
                }
                if (Condition[1] != "")
                {
                    sql += "Sex =" + Condition[1];
                }
            }
            try
            {
                var pats = context.PatBasicInforSet.SqlQuery(sql).ToList();
                return pats;
            }
            catch (System.Exception ex)
            {
                string s = ex.Message;
                return null;
            }


            //if (!(Condition[2] != "" && Condition[3] != ""))
            //{

            //    if (Condition[0] != "")
            //    {
            //        sql += "Set Name =" + Condition[0];
            //    }
            //    if (Condition[1] != "")
            //    {
            //        sql += "Set Sex =" + Condition[1];
            //    }
            //}
        }
        public List<VisitRecord> GetVistRecord(string PatID)
        {
            PatBasicInfor pt = context.PatBasicInforSet.Find(PatID);
            List<VisitRecord> visit = new List<VisitRecord>();
            foreach (VisitRecord vr in pt.VisitRecord)
            {
                visit.Add(vr);
            }
            return visit;
        }
        public void AddNewRecord(string PatID, VisitRecord nvisit)
        {
            PatBasicInfor pt = context.PatBasicInforSet.Find(PatID);
            nvisit.PatBasicInforId = PatID;
            pt.VisitRecord.Add(nvisit);
        }

       
    }
}
