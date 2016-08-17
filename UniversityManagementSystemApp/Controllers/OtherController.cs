using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystemApp.BLL;

namespace UniversityManagementSystemApp.Controllers
{
    public class OtherController : Controller
    {
        OtherManager aOtherManager = new OtherManager();
        //
        // GET: /Other/
        //public ActionResult Index()
        //{
        //    return View();
        //}

        public ActionResult UnassignCourse()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UnassignCourse(int? a)
        {
            string message = aOtherManager.UnassignCourse();
            ViewBag.message = message;
            
            return View();
        }

        public ActionResult UnAllocateClassRoom()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UnAllocateClassRoom(int? a)
        {
            string message = aOtherManager.UnAllocateClassRoom();
            ViewBag.message = message;
            return View();
        }

       
	}
}