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
                pdisease.Id = pt.PatDisease.Id;
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
                PatBasicInfor pt = context.PatBasicInforSet.Find(ID);
                pt.VisitRecord.Last().PatOtherTest = Ptext;
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

        public bool UpdateVisitRecord(VisitRecord vsr, string ID)
        {
            PatBasicInfor pt = context.PatBasicInforSet.Find(ID);
            pt.VisitRecord.Last().CDSSDiagnosis = vsr.CDSSDiagnosis;
            pt.VisitRecord.Last().DiagnosisiResult = vsr.CDSSDiagnosis;
            pt.VisitRecord.Last().RecordNote = vsr.RecordNote;
            return true;

        }

        public List<string> GetVisitContent(string RecordID)
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
                else
                {
                    test += "MMSE=";
                }
                if (vd.PatMoCA != null)
                {
                    test += ";MoCA= " + vd.PatMoCA.Total;
                }
                else
                {
                    test += ";MoCA= ";
                }
                if (vd.PatOtherTest != null)
                {
                    test += ";CDR= " + vd.PatOtherTest.PatCDR;
                }
                else
                {
                    test += ";CDR= ";
                }
                if (vd.PatOtherTest != null)
                {
                    test += ";GDS= " + vd.PatOtherTest.PatGDS;
                }
                else
                {
                    test += ";GDS= ";
                }
                if (vd.PatADL != null)
                {
                    test += ";ADL= " + vd.PatADL.Total;
                }
                else
                {
                    test += ";ADL= ";
                }
                if (vd.PatOtherTest != null)
                {
                    test += ";词语学习1= " + vd.PatOtherTest.Vocabulary1;
                    test += ";词语学习2= " + vd.PatOtherTest.Vocabulary2;
                    test += ";词语学习3= " + vd.PatOtherTest.Vocabulary3;
                    test += ";延迟记忆= " + vd.PatOtherTest.Vocabulary4;
                    test += ";原词辨认 =" + vd.PatOtherTest.VocabularyAnalyse1;
                    test += ";新词辨认 =" + vd.PatOtherTest.VocabularyAnalyse2;
                    test += ";图形复制 =" + vd.PatOtherTest.Picture1;
                    test += ";即刻回忆 =" + vd.PatOtherTest.Picture2;
                    test += ";延迟回忆 =" + vd.PatOtherTest.Picture3;
                    test += ";连线A =" + vd.PatOtherTest.ConnectNumber1;
                    test += ";连线B =" + vd.PatOtherTest.ConnectNumber2;
                }
                else
                {
                    test += ";词语学习1= ";
                    test += ";词语学习2= ";
                    test += ";词语学习3= ";
                    test += ";延迟记忆= ";
                    test += ";原词辨认 =";
                    test += ";新词辨认 =";
                    test += ";图形复制 =";
                    test += ";即刻回忆 =";
                    test += ";延迟回忆 =";
                    test += ";连线A =";
                    test += ";连线B =";
                }
                conttext.Add(test);
                conttext.Add(vd.RecordNote);
                conttext.Add(vd.DiagnosisiResult);
            }
            catch (Exception e)
            { }
            return conttext;
        }

        public List<PatBasicInfor> GetPat(List<string> Condition)
        {
            List<PatBasicInfor> pat = new List<PatBasicInfor>();
            var pats = from p in context.PatBasicInforSet.ToList()
                       where (string.IsNullOrEmpty(Condition[0]) ? true : p.Name == Condition[0])
                      && (string.IsNullOrEmpty(Condition[1]) ? true : p.Sex == Condition[1])
                      && (string.IsNullOrEmpty(Condition[2]) ? true : p.VisitRecord.Last().VisitDate == DateTime.Parse(Condition[2]))
                      && (string.IsNullOrEmpty(Condition[3]) ? true : p.VisitRecord.Last().DiagnosisiResult == Condition[3])
                       select p;

            try
            {

                foreach (PatBasicInfor pt in pats)
                {
                    pat.Add(pt);
                }
            }
            catch (Exception e)
            {
                string error = e.Message;

            }
            return pat;
        }
        public List<VisitRecord> GetVistRecord(string PatID)
        {
            PatBasicInfor pt = context.PatBasicInforSet.Find(PatID);
            List<VisitRecord> visit = new List<VisitRecord>();
            foreach (VisitRecord vr in pt.VisitRecord)
            {
                visit.Add(vr);
            }
            visit.Reverse();
            return visit;
        }
        public void AddNewRecord(string PatID)
        {


            PatBasicInfor pt = context.PatBasicInforSet.Find(PatID);

            VisitRecord vr = new VisitRecord();
            if (pt.VisitRecord.Count != 0)
            {
                vr.VisitRecordID = pt.VisitRecord.Last().VisitRecordID;
            }
            else
            {
                vr.VisitRecordID = "1";
            }
            vr.VisitDate = DateTime.Now;
            vr.PatBasicInforId = PatID;
            pt.VisitRecord.Add(vr);
            context.SaveChanges();
        }
        public bool DeleteRecord(string PatID, string RecordID)
        {
            try
            {

                var record = from p in context.VisitRecordSet.ToList()
                             where (p.PatBasicInfor.Id == PatID) && (p.Id == int.Parse(RecordID))
                             select p;
                VisitRecord r = record.First();
                if (r.PatADL != null)
                {
                    context.PatADLSet.Remove(r.PatADL);
                }
                if (r.PatMMSE != null)
                {
                    context.PatMMSESet.Remove(r.PatMMSE);
                }
                if (r.PatMoCA != null)
                {
                    context.PatMoCASet.Remove(r.PatMoCA);
                }
                if (r.PatOtherTest != null)
                {
                    context.PatOtherTestSet.Remove(r.PatOtherTest);
                }
                if (r.PatLabExam != null)
                {
                    context.PatLabExamSet.Remove(r.PatLabExam);
                }
                if (r.PatRecentDrug.Count != 0)
                {
                    foreach (PatRecentDrug rd in r.PatRecentDrug)
                    {
                        foreach (Drug d in rd.Drug)
                        {
                            context.DrugSet.Remove(d);
                        }

                        context.PatRecentDrugSet.Remove(rd);
                    }

                }
                context.VisitRecordSet.Remove(r);
                context.SaveChanges();
                return true;
            }
            catch (System.Exception e)
            {
                return false;

            }
        }

    }
}
