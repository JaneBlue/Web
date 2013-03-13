using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace LNCDCDSS.Models
{
    public   class VisitRecordOperation
    {
        LNCDDataModelContainer context = new LNCDDataModelContainer();
        public void InsertPatPhysicaExam(PatPhysicalExam PExam, string ID)
        {
            PatBasicInfor pt = context.PatBasicInforSet.Find(ID);

        }
        public void InsertPatDisease(PatDisease pdisease, string ID)
        {
            try
            {
                PatBasicInfor pt = context.PatBasicInforSet.Find(ID);
               
                pdisease.Id = 1;
                pdisease.PatBasicInforId = ID;
                pt.PatDisease = pdisease;
                pdisease.Description = "125";
                context.Entry(pt.PatDisease).CurrentValues.SetValues(pdisease);
               // pt.PatDisease.Description = "123";
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
            }
            catch (Exception e)
            {
                string a = e.InnerException.Message;
            }
        }
        public void InsertPatotherTest(PatOtherTest Ptext, int ID)
        {
            try
            {
                VisitRecord pt = context.VisitRecordSet.Find(ID);

                pt.PatOtherTest.Picture1 = "12";
              //  pt.PatOtherTest = Ptext;
                //context.Entry(pt).CurrentValues.SetValues(pt);
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
       /// <summary>
       /// 需要修改
       /// </summary>
       /// <param name="Plab"></param>
       /// <param name="ID"></param>
        public void InsertPatRecentDrug(PatRecentDrug PRdrug, List<Drug> drug, string ID)
        {
            try
            {
                PatBasicInfor pt = context.PatBasicInforSet.Find(ID);
                pt.VisitRecord.Last().PatRecentDrug = PRdrug;
                foreach (Drug d in drug){
                    d.PatRecentDrugId = pt.VisitRecord.Last().PatRecentDrug.Id;
                 pt.VisitRecord.Last().PatRecentDrug.Drug.Add(d);
                }
                context.SaveChanges();
            }
            catch (Exception e)
            {
                string a = e.InnerException.Message;
            }
        }
       
        public bool UpdateVisitRecord()
        {
            return true;
        
        }
      
        public List<string> GetVisitContet(string RecordID){
            //PatBasicInfor pt = context.PatBasicInforSet.Find(PatID);

            VisitRecord vd = context.VisitRecordSet.Find(RecordID);
            List<string> conttext = new List<string>();
            string test = vd.PatADL.Total + vd.PatMMSE.Total;
            conttext.Add(test);
            conttext.Add(vd.RecordNote) ;
            conttext.Add(vd.DiagnosisiResult);
            return conttext;
        }
        
        public  ICollection< PatBasicInfor> GetPat(List<string>Condition){

             string sql="Select * from dbo.PatBasicInforSet ";
            if (!(Condition[0] != "" && Condition[1] != "" ))
            {
                sql += "where ";
            if (Condition[0] != "")
            {
                sql+=" Name ="+"'"+Condition[0]+"'";
            }
            if (Condition[1] != "")
            {
                  sql+="Sex ="+Condition[1];
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
        public List<VisitRecord> GetVistRecord(string PatID){
            PatBasicInfor pt = context.PatBasicInforSet.Find(PatID);
            List<VisitRecord> visit = new List<VisitRecord>();
            foreach (VisitRecord vr in pt.VisitRecord)
            {
                visit.Add(vr);
            }
            return visit;
        }

    }
}
