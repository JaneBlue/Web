using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LNCDCDSS.Models;
namespace LNCDCDSS.Controllers
{
    public class DiagnosisController : Controller
    {
        //
        // GET: /Diagnosis/
        string PatID = "";
        public ActionResult Index(string ID)
        {
            PatID = ID;
            return View();
        }
        [HttpPost]
        public JsonResult Save()
        {
            VisitRecordOperation vr = new VisitRecordOperation();
            //PatOtherTest po = new PatOtherTest();
            //po.Id = 1;
            //po.PatCDR = "123";
            //vr.InsertPatotherTest(po, 1);
            //PatDisease PDisease = new PatDisease();
            //PDisease.Description = "12";
            //vr.InsertPatDisease(PDisease, "0582f3c014d741d79d36bad3a620341e");
            string jsonStr = Request.Params["postjson"];
            try{

                VisitData obj = JsonHelper.JsonDeserialize<VisitData>(jsonStr);//jsonStr.FromJsonTo<VisitData>();
                //vr.InsertPatMoca(obj, "0582f3c014d741d79d36bad3a620341e");
               PatRecentDrug pd = new PatRecentDrug();
               //pd.DrugCatogary = "333";
               //pd.Id = 1;
               // List<Drug> dr=new List<Drug>();
               // Drug g1=new Drug();
               // g1.Id=1;
               // g1.Name="12";
               // dr.Add(g1);
               // vr.InsertPatRecentDrug(pd,dr,"0582f3c014d741d79d36bad3a620341e");
            }
            catch(Exception  e){
                int q = 1;
            }
            
          return  this.Json(new { OK = true, Message = "保存成功" });  
        }

    }
}
