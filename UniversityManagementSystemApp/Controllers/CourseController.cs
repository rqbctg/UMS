using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Antlr.Runtime.Tree;
using UniversityManagementSystemApp.BLL;
using UniversityManagementSystemApp.DAL.Model;

namespace UniversityManagementSystemApp.Controllers
{
    public class CourseController : Controller
    {
        CourseManager aCourseManager = new CourseManager();
        DepartmentManager aDepartmentManager = new DepartmentManager();
        SemesterManager aSemesterManager = new SemesterManager();
        TeacherManager aTeacherManager = new TeacherManager();
        AssignCourseManager assignCourseManager = new AssignCourseManager();
        ViewCourseManager aViewCourseManager = new ViewCourseManager();
        //
        // GET: /Course/
        //public ActionResult Index()
        //{
        //    return View();
        //}

        [HttpGet]
        public ActionResult AddCourse()
        {
            List<Department> aDepartments = aDepartmentManager.GetAllDepartment();
            ViewBag.DepatmentList = aDepartments;
            List<Semester> aSemesters = aSemesterManager.GetAllSemester();
            ViewBag.SemesterList = aSemesters;
            return View();
        }
        [HttpPost]
        public ActionResult AddCourse(Course aCourse)
        {
            List<Department> aDepartments = aDepartmentManager.GetAllDepartment();
            ViewBag.DepatmentList = aDepartments;
            List<Semester> aSemesters = aSemesterManager.GetAllSemester();
            ViewBag.SemesterList = aSemesters;

            string message = aCourseManager.AddCoures(aCourse);
            ViewBag.message = message;
            return View();
        }

        [HttpGet]
        public ActionResult AssignCourse()
        {
            List<Department> aDepartments = aDepartmentManager.GetAllDepartment();
            ViewBag.DepatmentList = aDepartments;
            return View();

        }

        [HttpPost]
        public ActionResult AssignCourse(AssignCourse assignCourse)
        {
            List<Department> aDepartments = aDepartmentManager.GetAllDepartment();
            ViewBag.DepatmentList = aDepartments;
            string message =assignCourseManager.SaveAssignedCourse(assignCourse);
            ViewBag.message = message;
            
            return View();
        }

        public ActionResult ViewCourse()
        {
            List<Department> aDepartments = aDepartmentManager.GetAllDepartment();
            ViewBag.DepatmentList = aDepartments;
            return View();
        }
       

        public JsonResult GetTeacherByDeptId(int Department_Id)
        {
            var aTeacher = aTeacherManager.GetAllTeacher();
            var teachers = aTeacher.Where(a => a.Department_Id == Department_Id).ToList();
            return Json(teachers, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetTeacherById(int Teacher_Id)
        {
            var aTeacher = aTeacherManager.GetAllTeacher();
            var ateacherslist = aTeacher.Where(a => a.Id == Teacher_Id).ToList();
            return Json(ateacherslist, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetCourseById(int Course_Id)
        {
            var course = aCourseManager.GetAllCourse();
            var courseList = course.Where(a => a.Id == Course_Id).ToList();
            return Json(courseList, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetCourseBydeptId(int Department_Id)
        {
            var course = aCourseManager.GetAllCourse();
            var acourseList = course.Where(a => a.Department_Id == Department_Id).ToList();
            return Json(acourseList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ViewAssigendCourse(int Department_Id)
        {
            var aViewCourses = aViewCourseManager.GetAllViewCourse();
            var aViewCoursesList = aViewCourses.Where(a => a.Department_Id == Department_Id).ToList();
            return Json(aViewCoursesList, JsonRequestBehavior.AllowGet);
        }
	}
}