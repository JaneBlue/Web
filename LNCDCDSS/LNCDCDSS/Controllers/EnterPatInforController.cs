using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LNCDCDSS.Models;
using System.Text.RegularExpressions;  

namespace LNCDCDSS.Controllers
{
    public class EnterPatInforController : Controller
    {
        VisitRecordOperation visitop = new VisitRecordOperation();
        //
        // GET: /EnterPatInfor/

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(PatBasicInfor pat)
        {

            PatOperation pto = new PatOperation();
            string HID = Request.Form["住院号"];
            string PID = Request.Form["门诊号"];
            if (string.IsNullOrEmpty(pat.Name) || string.IsNullOrEmpty(pat.Sex) || string.IsNullOrEmpty(pat.Age) || string.IsNullOrEmpty(pat.Education) || string.IsNullOrEmpty(pat.Phone) || string.IsNullOrEmpty(pat.FamilyMember) || string.IsNullOrEmpty(pat.ChiefDoctor))
            {
                ModelState.AddModelError("", "输入项不能为空");
            }
            else
            {
                Regex reg = new Regex("^[0-9]+$");
                Match ma1 = reg.Match(pat.Age);  
                Match ma2 = reg.Match(pat.Phone);
                if (ma1.Success && ma2.Success)
                {
                }
                else
                {
                    ModelState.AddModelError("", "手机和年龄必须为数字");
                }
                     
                
            }
             if (ModelState.IsValid)
            {
          
            pto.InsertPat(pat, HID, PID);
            return RedirectToAction("Index", "Diagnosis", new { ID = pat.Id });
                  }
            else
            {
                return View();
            }
            //   return Redirect("/Diagnosis/Index/"+pat.Id);


        }

        public ActionResult Query()
        {
            string patname = Request["name"];
            string patsex = Request["sex"];
            string date = Request["date"];
            string diagnosisresult = Request["Diagnosis"];
            List<string> query = new List<string>();
            query.Add(patname);
            query.Add(patsex);
            query.Add(date);
            query.Add(diagnosisresult);

            List<PatBasicInfor> pts = visitop.GetPat(query);

            //  return Json(pts, JsonRequestBehavior.AllowGet);
            return PartialView("PatList", pts);
        }

        public ActionResult ViewRecord(string ID)
        {
            string t = ID;
            List<VisitRecord> vrecord = visitop.GetVistRecord(t);
            this.TempData["PatID"] = ID;
            this.ViewBag.patId = ID;
            return View(vrecord);
        }

        public ActionResult DetailView(int ID)
        {
            List<string> text = visitop.GetVisitContent(ID.ToString());
            DetaiInfor a = new DetaiInfor() { Name = "TestResult", Contetntext = text[0] };
            DetaiInfor b = new DetaiInfor() { Name = "RecordNote", Contetntext = text[1] };
            DetaiInfor c = new DetaiInfor() { Name = "DiagnosisResult", Contetntext = text[2] };

            List<DetaiInfor> list = new List<DetaiInfor>();
            DetaiInfor id = new DetaiInfor() { Name = "ID", Contetntext = ID.ToString() };
            list.Add(a);
            list.Add(b);
            list.Add(c);
            this.TempData["recordID"] = ID.ToString();
            return Json(list, JsonRequestBehavior.AllowGet);

        }
        public class DetaiInfor
        {
            public string Name { set; get; }
            public string Contetntext { set; get; }
        }

        public ActionResult GoToDiagnosis(string ID)
        {
            visitop.AddNewRecord(ID);
            return RedirectToAction("Index", "Diagnosis", new { ID = ID });
        }
        public ActionResult DeleteRecord(string ID)
        {

            // string jsonStr = Request.Params["postjson"];
            //  string PatID = this.TempData["PatID"].ToString();
            string PatID = ID;
            string RecordID = this.TempData["recordID"].ToString();
            try
            {
                visitop.DeleteRecord(PatID, RecordID);
            }
            catch (Exception e)
            {
                return this.Json(new { OK = false, Message = "删除失败" });
            }

            return this.Json(new { OK = true, Message = RecordID });
        }
    }
}
