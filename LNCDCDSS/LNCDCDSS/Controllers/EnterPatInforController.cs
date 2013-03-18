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


            return Redirect("/Diagnosis/Index/"+pat.Id);


        }
        [HttpPost]
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

            ICollection<PatBasicInfor> pts = visitop.GetPat(query);
            // return Redirect("/Diagnosis/Index");

            return PartialView("PatList", pts);
        }

        public ActionResult ViewRecord(string ID)
        {
            string t = ID;
            List<VisitRecord> vrecord = visitop.GetVistRecord(t);
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
            list.Add(a);
            list.Add(b);
            list.Add(c);
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
            return Redirect("/Diagnosis/Index/"+ID);
        }
    }
}
