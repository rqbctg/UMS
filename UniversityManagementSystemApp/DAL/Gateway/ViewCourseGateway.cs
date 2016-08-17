
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystemApp.DAL.Model;

namespace UniversityManagementSystemApp.DAL.Gateway
{
    public class ViewCourseGateway:Gateway
    {
        public List<ViewCourse> GetAllViewCourse()
        {

            Query = "SELECT * From AssigendCourseview";
            Command = new SqlCommand(Query,Connection);
            List<ViewCourse> aViewCourses = new List<ViewCourse>();
            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                ViewCourse aViewCourse =new ViewCourse()
                {
                    Department_Id = (int) Reader["deptId"],
                    Course_Id = (int) Reader["CourseId"],
                    CourseCode = Reader["CourseCode"].ToString(),
                    CourseName = Reader["CourseName"].ToString(),
                    CourseSemester = Reader["Semester"].ToString(),
                    TeacherName = Reader["TeacherName"].ToString()
                };
                aViewCourses.Add(aViewCourse);
            }
            Reader.Close();
            Connection.Close();
            return aViewCourses;


        }
    }
}