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

            PatOperation pto = new PatOperation();
            pto.InsertPat(pat);
             return Redirect("/Diagnosis/Index");
           
            
        }
    }
}
