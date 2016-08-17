using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystemApp.BLL;
using UniversityManagementSystemApp.DAL.Model;

namespace UniversityManagementSystemApp.Controllers
{
    public class ResultController : Controller
    {
        StudentManager aStudentManager = new StudentManager();
        EnrollCourseManager aEnrollCourseManager = new EnrollCourseManager();
        ResultManager aResultManager = new ResultManager();
        ViewResultManager aViewResultManager = new ViewResultManager();
        //
        // GET: /Result/
        //public ActionResult Index()
        //{
        //    return View();
        //}

        [HttpGet]
        public ActionResult SaveStudentResult()
        {
            List<Student> aStudents = aStudentManager.GetAllStudent();

            ViewBag.StudentList = aStudents;
            List<Grade> aGrades = aResultManager.GetAllGrade();
            ViewBag.GradeList = aGrades;
            return View();
        }
        [HttpPost]
        public ActionResult SaveStudentResult(Result aResult)
        {
            List<Student> aStudents = aStudentManager.GetAllStudent();

            ViewBag.StudentList = aStudents;
            List<Grade> aGrades = aResultManager.GetAllGrade();
            ViewBag.GradeList = aGrades;
            string message = aResultManager.SaveResult(aResult);
            ViewBag.message = message;
               
            
            return View();
        }

        public ActionResult ViewResult()
        {
            List<Student> aStudents = aStudentManager.GetAllStudent();

            ViewBag.StudentList = aStudents;
            return View();
        }





        public JsonResult GetStudentById(int studentId)
        {
            var student = aStudentManager.GetAllStudent();
            var studentList = student.Where(a => a.Id == studentId).ToList();
            return Json(studentList, JsonRequestBehavior.AllowGet);

        }
        public JsonResult GetEnrollCourseByStdId(int studentIdforCourse)
        {
            var aViewEnrollCourses = aEnrollCourseManager.GetAllEnrolledCourse();
            var aViewEnrollCoursesList = aViewEnrollCourses.Where(a => a.StudentId == studentIdforCourse).ToList();
            return Json(aViewEnrollCoursesList, JsonRequestBehavior.AllowGet);

        }
        public JsonResult GetviewResultByStdId(int stdIdforECourse)
        {
            var aViewResults = aViewResultManager.GetAllEnrollCourse();
            var selectedaViewResults = aViewResults.Where(a => a.StudentId == stdIdforECourse).ToList();
            return Json(selectedaViewResults, JsonRequestBehavior.AllowGet);

        }

    }
}