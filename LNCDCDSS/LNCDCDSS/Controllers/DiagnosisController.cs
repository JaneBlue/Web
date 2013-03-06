using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
          return  this.Json(new { OK = true, Message = "Programer" });  
        }

    }
}
