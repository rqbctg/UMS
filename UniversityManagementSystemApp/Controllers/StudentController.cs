using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure.Interception;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using UniversityManagementSystemApp.BLL;
using UniversityManagementSystemApp.DAL.Model;

namespace UniversityManagementSystemApp.Controllers
{
    public class StudentController : Controller
    {
        //
        // GET: /Student/
        DepartmentManager aDepartmentManager = new DepartmentManager();
        StudentManager aStudentManager = new StudentManager();
        CourseManager aCourseManager = new CourseManager();
        EnrollCourseManager aEnrollCourseManager = new EnrollCourseManager();
        //public ActionResult Index()
        //{
        //    return View();
        //}

        [HttpGet]
        public ActionResult RegisterStudent()
        {
            List<Department> aDepartments = aDepartmentManager.GetAllDepartment();
            ViewBag.Departmentlist = aDepartments;
            return View();
        }
        [HttpPost]
        public ActionResult RegisterStudent(Student aStudent)
        {
            List<Department> aDepartments = aDepartmentManager.GetAllDepartment();
            ViewBag.Departmentlist = aDepartments;
            string departmentCode = aDepartmentManager.GetDepartmentCodeByID(aStudent.DepartmentId);
            aStudent.Code = departmentCode;

            string regno = departmentCode + "-";
            regno += aStudent.Date.Year.ToString();
            regno += "-";
            int regNoId = aStudentManager.GetRowCount(regno);
            //string s = (regNoId + 1).ToString("000");
            if (regNoId == 0)
            {
                regno += "00" + 1;
            }
            else
            {
                if (regNoId >= 1 && regNoId <= 9)
                {
                    int temp = regNoId + 1;
                    regno += "00" + temp;
                }
                else if (regNoId >= 10 && regNoId <= 99)
                {
                    int temp = regNoId + 1;
                    regno += "0" + temp;

                }
                else
                {
                    regno += "" + regNoId + 1;

                }


            }
            aStudent.Registration_Number = regno;



            string saveStudent = aStudentManager.SaveStudent(aStudent);
            ViewBag.message = saveStudent;
            return View();
        }

        [HttpGet]
        public ActionResult EnrollStudentInCourse()
        {
            List<Student> aStudents = aStudentManager.GetAllStudent();
            ViewBag.StudentList = aStudents;

            return View();
        }
        [HttpPost]
        public ActionResult EnrollStudentInCourse(EnrollCourse aEnrollCourse)
        {
            List<Student> aStudents = aStudentManager.GetAllStudent();

            ViewBag.StudentList = aStudents;
            int deptId = aDepartmentManager.GetDepatmentIdByCode(aEnrollCourse.Code);
            aEnrollCourse.DepartmentId = deptId;
            string message = aEnrollCourseManager.EnrollCourse(aEnrollCourse);
            ViewBag.message = message;

            return View();
        }


        public JsonResult GetStudentById(int studentId)
        {
            var student = aStudentManager.GetAllStudent();
            var studentList = student.Where(a => a.Id == studentId).ToList();
            return Json(studentList, JsonRequestBehavior.AllowGet);

        }
        public JsonResult GetCourseById(int departmentId)
        {
            var course = aCourseManager.GetAllCourse();
            var courseList = course.Where(a => a.Department_Id == departmentId).ToList();
            return Json(courseList, JsonRequestBehavior.AllowGet);

        }


    }
}