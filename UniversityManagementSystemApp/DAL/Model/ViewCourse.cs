using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementSystemApp.DAL.Model
{
    public class ViewCourse
    {
        public int Department_Id { get; set; }
        public  int  Course_Id { get; set; }
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public string CourseSemester { get; set; }
        public string TeacherName { get; set; }
    }
}