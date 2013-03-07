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
        public void InsertPatRecentDrug(PatLabExam Plab, string ID)
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
       
        public bool UpdateVisitRecord()
        {
            return true;
        
        }
        public class  VisitContent {
            string[] TestResult;
            string RecordNote;
            string DIagnosisResult;
        }
        public VisitContent  GetVisitContet(string PatID,int RecordID){
            return null;
        }

       

    }
}
