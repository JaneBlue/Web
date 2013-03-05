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
            return View();
        }
        [HttpPost]
        public ActionResult Index(PatBasicInfor pat)
        {

            //PatOperation pto = new PatOperation();
            //string HID = Request.Form["住院号"];
            //string PID = Request.Form["病历号"];
            //pto.InsertPat(pat, HID, PID);


            return Redirect("/Diagnosis/Index");


        }
        [HttpPost]
        public ActionResult Query()
        {
            return Redirect("/Diagnosis/Index");
        }
    }
}
