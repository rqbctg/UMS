using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace UniversityManagementSystemApp.DAL.Model
{
    public class EnrollCourse
    {
        public int Id { get; set; }

        //[Required(ErrorMessage = "Pls select StudentRegNo", AllowEmptyStrings = false)]
        //[DisplayName("Student Reg. No.")]
        public int StudentId { get; set; }

        //[DisplayName("Name")]
        public string StudentName { get; set; }

        //[DisplayName("Email")]
        public string StudentEmail { get; set; }

        //[DisplayName("Department")]
        public string Code { get; set; }
        //[DisplayName("Course")]
        //[Required(ErrorMessage = "Pls select a Course", AllowEmptyStrings = false)]
        public int CourseId { get; set; }
        //[DisplayName("Date")]
        //[Required(ErrorMessage = "Pls select a date", AllowEmptyStrings = false)]
        public DateTime EnrollDate { get; set; }

        public int DepartmentId { get; set; }


    }
}