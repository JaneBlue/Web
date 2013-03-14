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
            string jsonStr = Request.Params["postjson"];
            try{
                VisitData obj = JsonHelper.JsonDeserialize<VisitData>(jsonStr);//jsonStr.FromJsonTo<VisitData>();
                vr.InsertPatADL(obj.pal, PatID);
                vr.InsertPatDisease(obj.pds, PatID);
                vr.InsertPatLabExam(obj.ple, PatID);
                vr.InsertPatMMSE(obj.pme, PatID);
                vr.InsertPatMoca(obj.pma, PatID);
                vr.InsertPatotherTest(obj.pot, PatID);
                vr.InsertPatPhysicaExam(obj.ppe, PatID);
                vr.InsertPatRecentDrug(obj.prd, PatID);
            }
            catch(Exception  e){
                return this.Json(new { OK = false, Message = "保存失败" });  
            }
            
          return  this.Json(new { OK = true, Message = "保存成功" });  
        }

    }
}
