using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LNCDCDSS.Models;

namespace LNCDCDSS.Controllers
{
    public class EnterPatInforController : Controller
    {
        VisitRecordOperation visitop = new VisitRecordOperation();
        //
        // GET: /EnterPatInfor/

        public ActionResult Index()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = "正常", Value = "正常" });
            items.Add(new SelectListItem { Text = "AD", Value = "AD" });
            items.Add(new SelectListItem { Text = "MCI", Value = "MCI" });
            this.ViewData["Diagnosis"] = items;
            return View();
        }
        [HttpPost]
        public ActionResult Index(PatBasicInfor pat)
        {

            PatOperation pto = new PatOperation();
            string HID = Request.Form["住院号"];
            string PID = Request.Form["门诊号"];
            pto.InsertPat(pat, HID, PID);

            return RedirectToAction("Index", "Diagnosis", new { ID = pat.Id });
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
            return View(vrecord);
        }

        public ActionResult DetailView(int ID)
        {
            List<string> text = visitop.GetVisitContet(ID.ToString());
            DetaiInfor a = new DetaiInfor() { Name = "TestResult", Contetntext = text[0] };
            DetaiInfor b = new DetaiInfor() { Name = "RecordNote", Contetntext = text[1] };
            DetaiInfor c = new DetaiInfor() { Name = "DiagnosisResult", Contetntext = text[2] };
            DetaiInfor e = new DetaiInfor() { Name = "PatID", Contetntext = text[2] };
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
        public ActionResult DeleteRecord()
        {
            try
            {
                // string jsonStr = Request.Params["postjson"];
                string PatID = this.TempData["PatID"].ToString();
                string RecordID = this.TempData["recordID"].ToString();
                visitop.DeleteRecord(PatID, RecordID);
            }
            catch (Exception e)
            {
                return this.Json(new { OK = false, Message = "删除失败" });
            }

            return this.Json(new { OK = true, Message = "删除成功" });
        }
    }
}
