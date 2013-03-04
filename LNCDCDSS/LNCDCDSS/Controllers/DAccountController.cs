using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LNCDCDSS.Models;
namespace LNCDCDSS.Controllers
{
    public class DAccountController : Controller
    {

        LNCDDataModelContainer DataContainer = new LNCDDataModelContainer();
        //
        // GET: /DAccount/
       
        public ActionResult Index()
        {
            return Redirect("/Diagnosis/Index");
        }
        [HttpPost]
        public ActionResult Index(DoctorAccount dacount)
        {
            var students = from s in DataContainer.DoctorAccountSet.ToList() select s;
            var student = students.Where(s => s.UserName==dacount.UserName ).FirstOrDefault();
          if (student!=null)
          {
              return Redirect("/EnterPatInfor/Index");
          }
          else
            {

                return View(dacount);
            }
          

           
        }
    }
}
