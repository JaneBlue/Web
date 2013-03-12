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
        //
        // GET: /EnterPatInfor/

        public ActionResult Index()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = "正常", Value = "29" });
            items.Add(new SelectListItem { Text = "轻度痴呆", Value = "28" });
            items.Add(new SelectListItem { Text = "MCI", Value = "24" });
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


            return Redirect("/Diagnosis/Index");


        }
        [HttpPost]
        public ActionResult Query()
        {
            string patname = Request["name"];
            string patsex = Request["sex"];
            string d = Request["date"];
            // DateTime dt = DateTime.Parse(Request["date"]);
            string diagnosisresult = Request["Diagnosis"];
            // return Redirect("/Diagnosis/Index");
            List<string> cities = new List<string>(); // List of city names
            cities.Add("San Diego");                  // String element 1
            cities.Add("Humboldt");                   // 2
            cities.Add("Los Angeles");                // 3
            cities.Add("Auburn");
            return PartialView("PatList", cities);
        }

        public ActionResult ViewRecord(string ID)
        {
            string t = ID;
            List<string> cities = new List<string>(); // List of city names
            cities.Add("San Diego");                  // String element 1
            cities.Add("Humboldt");                   // 2
            cities.Add("Los Angeles");                // 3
            cities.Add("Auburn");
            ViewBag.Visit = cities;
            return View(cities);
        }

        public ActionResult DetailView(string date)
        {
            DetaiInfor a = new DetaiInfor() { Name = "TestResult", Contetntext = "12" };
            DetaiInfor b = new DetaiInfor() { Name = "RecordNote", Contetntext = "17" };
            List<DetaiInfor> list = new List<DetaiInfor>();
            list.Add(a);
            list.Add(b);

            return Json(list, JsonRequestBehavior.AllowGet); 
         
        }
        public class DetaiInfor
        {
            public string Name { set; get; }
            public string Contetntext { set; get; }
        }


    }
}
