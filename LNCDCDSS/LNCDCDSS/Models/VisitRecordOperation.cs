using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Diagnostics;
using System.Data.Entity.Validation;

using org.openehr.am.archetype;
using org.openehr.am.archetype.constraintmodel;
using System.Reflection;
namespace LNCDCDSS.Models
{
    public class VisitRecordOperation
    {
        LNCDDataModelContainer context = new LNCDDataModelContainer();

        public void SaveVisitRecordInPBInfo()
        {
            try
            {
                context.SaveChanges();
            }
            catch (Exception e)
            {
                string a = e.InnerException.Message;
            }
        }

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

        public String GetLastVisitRecordID(String patientID)
        {
            PatBasicInfor pt = context.PatBasicInforSet.Find(patientID);
            return pt.VisitRecord.Last().Id.ToString();
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
            pt.VisitRecord.Last().DiagnosisiResult = vsr.DiagnosisiResult;
            pt.VisitRecord.Last().RecordNote = vsr.RecordNote;
            context.SaveChanges();
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
        public DataFromReporter GetExamContent(string PatID, string RecordID)
        {
            //AQLExecute.AQLExecuteImplService aqlImpl = new AQLExecute.AQLExecuteImplService();
            LocalAQLExecute.AQLExecuteImplService aqlImpl = new LocalAQLExecute.AQLExecuteImplService();

            //create DataFromReporter
            DataFromReporter oDataFromReporter = new DataFromReporter();
            foreach (List<string> keyPathsInArchetype in LNCDCDSS.MvcApplication.oPathsInArchetypes.Keys)
            {
                //every archetype
                String strArchetypeID = LNCDCDSS.MvcApplication.oPathsInArchetypes[keyPathsInArchetype];

                //write AQL
                string aqlQuery = "select o from " + strArchetypeID + " as o ";
                aqlQuery += "where o#";
                if ("openEHR-EHR-OBSERVATION.adl.v1" == strArchetypeID)
                {
                    aqlQuery += "/data[at0001]/events[at0002]/data[at0003]/items[at0126]/value/value" + " = '" + RecordID + "'";
                }
                else if ("openEHR-EHR-OBSERVATION.cdr.v1" == strArchetypeID)
                {
                    aqlQuery += "/data[at0001]/events[at0002]/data[at0003]/items[at0057]/value/value" + " = '" + RecordID + "'";
                }
                else if ("openEHR-EHR-OBSERVATION.gds.v1" == strArchetypeID)
                {
                    aqlQuery += "/data[at0001]/events[at0002]/data[at0003]/items[at0020]/value/value" + " = '" + RecordID + "'";
                }
                else if ("openEHR-EHR-OBSERVATION.mmse.v1" == strArchetypeID)
                {
                    aqlQuery += "/data[at0001]/events[at0002]/data[at0003]/items[at0107]/value/value" + " = '" + RecordID + "'";
                }
                else if ("openEHR-EHR-OBSERVATION.moca.v1" == strArchetypeID)
                {
                    aqlQuery += "/data[at0001]/events[at0002]/data[at0003]/items[at0068]/value/value" + " = '" + RecordID + "'";
                }
                else if ("openEHR-EHR-OBSERVATION.other_cognitions_scale_exams.v1" == strArchetypeID)
                {
                    aqlQuery += "/data[at0001]/events[at0002]/data[at0003]/items[at0022]/value/value" + " = '" + RecordID + "'";
                }
                else
                    continue;

                //get query results
                String[] selectResults = aqlImpl.select(aqlQuery, "");
                if (selectResults != null && selectResults.Length > 0)
                {
                    //set results into object
                    org.openehr.am.parser.DADLParser dADLParser = new org.openehr.am.parser.DADLParser(selectResults[0]);
                    org.openehr.am.parser.ContentObject dADLcontentObj = dADLParser.parse();
                    org.openehr.rm.binding.DADLBinding binding = new org.openehr.rm.binding.DADLBinding();
                    org.openehr.rm.common.archetyped.Locatable dADLloc = binding.bind(dADLcontentObj) as org.openehr.rm.common.archetyped.Locatable;

                    //get values in one archetype
                    //create ArchetypeFromReporter
                    DataFromReporter.ArchetypeFromReporter oArchetypeFromReporter = new DataFromReporter.ArchetypeFromReporter();
                    oArchetypeFromReporter.ArchetypeID = strArchetypeID;
                    foreach (string strPathInArchetype in keyPathsInArchetype)
                    {
                        //create ValueFromReporter
                        DataFromReporter.ValueFromReporter oValueFromReporter = new DataFromReporter.ValueFromReporter();
                        oValueFromReporter.Path = strPathInArchetype;

                        {
                            int i = strPathInArchetype.LastIndexOf("/");
                            if (i < 0 || i == strPathInArchetype.Length)
                                continue;

                            String objPath = "/";
                            if (i > 0)
                            {
                                objPath = strPathInArchetype.Substring(0, i);
                            }
                            String attributeName = strPathInArchetype.Substring(i + 1);

                            Object obj = dADLloc.itemAtPath(objPath);
                            if (obj != null)
                            {
                                Type tObjectType = obj.GetType();
                                FieldInfo iFieldInfo = tObjectType.GetField(attributeName, BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);

                                oValueFromReporter.Value = iFieldInfo.GetValue(obj).ToString().ToLower();
                            }
                        }

                        //add ValueFromReporter into ArchetypeFromReporter
                        oArchetypeFromReporter.valuesFromReporter.Add(oValueFromReporter);
                    }
                    //add ArchetypeFromReporter into DataFromReporter
                    oDataFromReporter.archetypesFromReporter.Add(oArchetypeFromReporter);
                 }
            }

            return oDataFromReporter;
        }
        public List<PatBasicInfor> GetPat(List<string> Condition)
        {
            List<PatBasicInfor> pat = new List<PatBasicInfor>();
            List<PatBasicInfor> Unormalpat = new List<PatBasicInfor>();
            var pats = from p in context.PatBasicInforSet.ToList()
                       where (string.IsNullOrEmpty(Condition[0]) ? true : p.Name == Condition[0])
                      && (string.IsNullOrEmpty(Condition[1]) ? true : p.Sex == Condition[1])
                      && (string.IsNullOrEmpty(Condition[2]) ? true : p.VisitRecord.Last().VisitDate == DateTime.Parse(Condition[2]))
                      && (string.IsNullOrEmpty(Condition[3]) ? true : p.VisitRecord.Last().DiagnosisiResult == Condition[3])
                       select p;

            try
            {
                
                foreach (PatBasicInfor pt in pats)
                {if (pt.VisitRecord!=null&&pt.VisitRecord.Count!=0)
                {
                     pat.Add(pt);
                } 
                 else
                {
                    Unormalpat.Add(pt);
                }
                }
                if (string.IsNullOrEmpty(Condition[2]))
                {
                    InsertSort(pat);
                }
                pat.AddRange(Unormalpat);
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
        public bool SaveContinueRecord(string PatID, string RecordID, VisitData visitdata)
        {
            try
            {

                int recordId = int.Parse(RecordID);
                VisitRecord vd = context.VisitRecordSet.Find(recordId);
                if (vd.PatADL == null)
                {
                    vd.PatADL = visitdata.pal;
                }
                else if (vd.PatADL.Total == "")
                {
                    ObjectMapper.CopyValueProperties(visitdata.pal, vd.PatADL);
                }
                if (vd.PatMMSE == null)
                {
                    vd.PatMMSE = visitdata.pme;
                }
                else if (vd.PatMMSE.Total == "")
                {
                    ObjectMapper.CopyValueProperties(visitdata.pme, vd.PatMMSE);
                }
                if (vd.PatMoCA == null)
                {
                    vd.PatMoCA = visitdata.pma;
                }
                else if (vd.PatMoCA.Total == "")
                {
                    ObjectMapper.CopyValueProperties(visitdata.pma, vd.PatMoCA);
                }
                if (vd.PatOtherTest == null)
                {
                    vd.PatOtherTest = visitdata.pot;
                }
                else
                {
                    if (vd.PatOtherTest.Vocabulary1 == "")
                    {
                        vd.PatOtherTest.Vocabulary1 = visitdata.pot.Vocabulary1;
                    }
                    if (vd.PatOtherTest.Vocabulary2 == "")
                    {
                        vd.PatOtherTest.Vocabulary2 = visitdata.pot.Vocabulary2;
                    }
                    if (vd.PatOtherTest.Vocabulary3 == "")
                    {
                        vd.PatOtherTest.Vocabulary3 = visitdata.pot.Vocabulary3;
                    }
                    if (vd.PatOtherTest.Vocabulary4 == "")
                    {
                        vd.PatOtherTest.Vocabulary4 = visitdata.pot.Vocabulary4;
                    }
                    if (vd.PatOtherTest.ConnectNumber1 == "")
                    {
                        vd.PatOtherTest.ConnectNumber1 = visitdata.pot.ConnectNumber1;
                    }
                    if (vd.PatOtherTest.ConnectNumber2 == "")
                    {
                        vd.PatOtherTest.ConnectNumber2 = visitdata.pot.ConnectNumber2;
                    }
                    if (vd.PatOtherTest.PatCDR == "")
                    {
                        vd.PatOtherTest.PatCDR = visitdata.pot.PatCDR;
                    }
                    if (vd.PatOtherTest.PatGDS == "")
                    {
                        vd.PatOtherTest.PatGDS = visitdata.pot.PatGDS;
                    }
                    if (vd.PatOtherTest.Picture1 == "")
                    {
                        vd.PatOtherTest.Picture1 = visitdata.pot.Picture1;
                    }
                    if (vd.PatOtherTest.Picture2 == "")
                    {
                        vd.PatOtherTest.Picture2 = visitdata.pot.Picture2;
                    }
                    if (vd.PatOtherTest.Picture3 == "")
                    {
                        vd.PatOtherTest.Picture3 = visitdata.pot.Picture3;
                    }
                    if (vd.PatOtherTest.VocabularyAnalyse1 == "")
                    {
                        vd.PatOtherTest.VocabularyAnalyse1 = visitdata.pot.VocabularyAnalyse1;
                    }
                    if (vd.PatOtherTest.VocabularyAnalyse2 == "")
                    {
                        vd.PatOtherTest.VocabularyAnalyse2 = visitdata.pot.VocabularyAnalyse2;
                    }
                   


                }

                vd.CDSSDiagnosis = visitdata.vsr.CDSSDiagnosis;
                vd.DiagnosisiResult = visitdata.vsr.DiagnosisiResult;
                vd.RecordNote = visitdata.vsr.RecordNote;
                context.SaveChanges();
                return true;
            }
            catch (System.Exception ex)
            {
                return false;
            }

        }
        public bool CopyContinueRecord(string PatID, string RecordID, VisitData visitdata)
        {
            try
            {

                int recordId = int.Parse(RecordID);
                VisitRecord vd = context.VisitRecordSet.Find(recordId);
                if (vd.PatADL != null && vd.PatADL.Total != "")
                {
                    ObjectMapper.CopyValueProperties(vd.PatADL, visitdata.pal);
                }


                if (vd.PatMMSE != null && vd.PatMMSE.Total != "")
                {
                    ObjectMapper.CopyValueProperties(vd.PatMMSE, visitdata.pme);
                }

                if (vd.PatMoCA != null && vd.PatMoCA.Total != "")
                {
                    ObjectMapper.CopyValueProperties(vd.PatMoCA, visitdata.pma);
                }

                if (vd.PatOtherTest != null)
                {
                    if (vd.PatOtherTest.Vocabulary1 != "")
                    {
                        visitdata.pot.Vocabulary1 = vd.PatOtherTest.Vocabulary1;
                    }
                    if (vd.PatOtherTest.Vocabulary2 != "")
                    {
                        visitdata.pot.Vocabulary2 = vd.PatOtherTest.Vocabulary2;
                    }
                    if (vd.PatOtherTest.Vocabulary3 != "")
                    {
                        visitdata.pot.Vocabulary3 = vd.PatOtherTest.Vocabulary3;
                    }
                    if (vd.PatOtherTest.Vocabulary4 != "")
                    {
                        visitdata.pot.Vocabulary4 = vd.PatOtherTest.Vocabulary4;
                    }
                    if (vd.PatOtherTest.ConnectNumber1 != "")
                    {
                        visitdata.pot.ConnectNumber1 = vd.PatOtherTest.ConnectNumber1;
                    }
                    if (vd.PatOtherTest.ConnectNumber2 != "")
                    {
                        visitdata.pot.ConnectNumber2 = vd.PatOtherTest.ConnectNumber2;
                    }
                    if (vd.PatOtherTest.PatCDR != "")
                    {
                        visitdata.pot.PatCDR = vd.PatOtherTest.PatCDR;
                    }
                    if (vd.PatOtherTest.PatGDS != "")
                    {
                        visitdata.pot.PatGDS = vd.PatOtherTest.PatGDS;
                    }
                    if (vd.PatOtherTest.Picture1 != "")
                    {
                        visitdata.pot.Picture1 = vd.PatOtherTest.Picture1;
                    }
                    if (vd.PatOtherTest.Picture2 != "")
                    {
                        visitdata.pot.Picture2 = vd.PatOtherTest.Picture2;
                    }
                    if (vd.PatOtherTest.Picture3 != "")
                    {
                        visitdata.pot.Picture3 = vd.PatOtherTest.Picture3;
                    }
                    if (vd.PatOtherTest.VocabularyAnalyse1 != "")
                    {
                        visitdata.pot.VocabularyAnalyse1 = vd.PatOtherTest.VocabularyAnalyse1;
                    }
                    if (vd.PatOtherTest.VocabularyAnalyse2 != "")
                    {
                        visitdata.pot.VocabularyAnalyse2 = vd.PatOtherTest.VocabularyAnalyse2;
                    }


                }

                return true;
            }
            catch (System.Exception ex)
            {
                return false;
            }

        }
        public static void InsertSort(List<PatBasicInfor> data)
        {
            var count = data.Count;
            for (int i = 1; i < count; i++)
            {
                var t = data[i].VisitRecord.Last().VisitDate;
                var d = data[i];
                var j = i;
                while (j > 0 && data[j - 1].VisitRecord.Last().VisitDate < t)
                {
                    data[j] = data[j - 1];
                    --j;
                }
                data[j] =d;
            }
        }

        


    }
}
