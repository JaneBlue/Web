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

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Save()
        {
            VisitRecordOperation vr = new VisitRecordOperation();
            PatOtherTest po = new PatOtherTest();
            //po.Id = 1;
            //po.PatCDR = "123";
            //vr.InsertPatotherTest(po, 1);
            //PatDisease PDisease = new PatDisease();
            //PDisease.Description = "12";
            //vr.InsertPatDisease(PDisease, "0582f3c014d741d79d36bad3a620341e");
          return  this.Json(new { OK = true, Message = "保存成功" });  
        }

    }
}
