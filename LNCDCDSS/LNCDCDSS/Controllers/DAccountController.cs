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
         // return View();
            return RedirectToAction("Index", "EnterPatInfor");
       
        }
        [HttpPost]
        public ActionResult  Index(DoctorAccount dacount)
        {
            var students = from s in DataContainer.DoctorAccountSet.ToList() select s;
            var student = students.Where(s => s.UserName == dacount.UserName && s.PassWord == dacount.PassWord).FirstOrDefault();
          if (student!=null)
          {
              return RedirectToAction("Index","EnterPatInfor");
 
          }
          else
            {
                ViewBag.message = "用户名或密码错误";
                return View();
            }
          

           
        }
    }
}
