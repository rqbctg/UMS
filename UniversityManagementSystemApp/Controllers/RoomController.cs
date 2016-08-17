using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using UniversityManagementSystemApp.BLL;
using UniversityManagementSystemApp.DAL.Model;

namespace UniversityManagementSystemApp.Controllers
{
    public class RoomController : Controller
    {
        DepartmentManager aDepartmentManager = new DepartmentManager();
        CourseManager aCourseManager = new CourseManager();
        RoomAndDayManager aRoomAndDayManager = new RoomAndDayManager();
        AllocateClassRoomManager aAllocateClassRoomManager = new AllocateClassRoomManager();
        ViewAllocatedClassRoomManager aViewAllocatedClassRoomManager = new ViewAllocatedClassRoomManager();
        //
        // GET: /Room/
        //public ActionResult Index()
        //{
        //    return View();
        //}

        [HttpGet]
        public ActionResult AllocateClassRoom()
        {
            List<Department> aDepartments = aDepartmentManager.GetAllDepartment();
            ViewBag.Departmentlist = aDepartments;
            List<Day> aDays = aRoomAndDayManager.GetAllDay();
            ViewBag.Daylist = aDays;
            List<Room> aRooms = aRoomAndDayManager.GetAllRoom();
            ViewBag.RoomList = aRooms;
            return View();
        }
        [HttpPost]
        public ActionResult AllocateClassRoom(AllocateClassRoom allocateClassRoom)
        {
            List<Department> aDepartments = aDepartmentManager.GetAllDepartment();
            ViewBag.Departmentlist = aDepartments;
            List<Day> aDays = aRoomAndDayManager.GetAllDay();
            ViewBag.Daylist = aDays;
            List<Room> aRooms = aRoomAndDayManager.GetAllRoom();
            ViewBag.RoomList = aRooms;
            string message = aAllocateClassRoomManager.SaveAlocateClassRoom(allocateClassRoom);
            ViewBag.message = message;
            return View();
        }

        public ActionResult ViewAllocatedClass()
        {
            List<Department> aDepartments = aDepartmentManager.GetAllDepartment();
            ViewBag.Departmentlist = aDepartments;
            return View();
        }
        public JsonResult GetCourseBydeptId(int departmentId)
        {
            var course = aCourseManager.GetAllCourse();
            var acourseList = course.Where(a => a.Department_Id == departmentId).ToList();
            return Json(acourseList, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetAllocatedRoomViewByDepartmentId(int departmentId)
        {
            var aViewAllocatedClassRooms =
                aViewAllocatedClassRoomManager.GetAllViewAllocatedClassRoom();
            var seletedViewAllocatedClassRooms = aViewAllocatedClassRooms.Where(a => a.DepartmentId == departmentId).ToList();
            return Json(seletedViewAllocatedClassRooms, JsonRequestBehavior.AllowGet);
        }
       
	}
}