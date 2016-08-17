using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystemApp.DAL.Model;

namespace UniversityManagementSystemApp.DAL.Gateway
{
    public class EnrollCourseGateway:Gateway
    {
        public bool IsCourseEnrolledByStudent(int courseId, int studentId)
        {
            Query = "SELECT * From EnrollCourse WHERE CourseId='" + courseId + "' and StudentId='"+studentId+"'";
            Connection.Open();
            Command = new SqlCommand(Query, Connection);
            Reader = Command.ExecuteReader();
            bool isexixt;
            if (Reader.HasRows)
            {
                isexixt = false;
            }
            else
            {
                isexixt = true;
            }
            Reader.Close();
            Connection.Close();
            return isexixt;


        }

        public int EnrollCourse(EnrollCourse aEnrollCourse)
        {
            Query = "INSERT INTO EnrollCourse(Name,Email,DepartmentId,CourseId,StudentId,EnrollDate)VALUES('"+aEnrollCourse.StudentName+"','"+aEnrollCourse.StudentEmail+"','"+aEnrollCourse.DepartmentId+"','"+aEnrollCourse.CourseId+"','"+aEnrollCourse.StudentId+"','"+aEnrollCourse.EnrollDate+"') ";
            Command = new SqlCommand(Query,Connection);
            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }

        public List<ViewEnrollCourse> GetAllEnrolledCourse()
        {
            Query = "SELECT * FROM EnrollCourseView";
            Command = new SqlCommand(Query,Connection);
            Connection.Open();
            List<ViewEnrollCourse> aViewEnrollCourses = new List<ViewEnrollCourse>();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                ViewEnrollCourse aEnrollCourse = new ViewEnrollCourse()
                {
                    CourseName = Reader["CourseName"].ToString(),
                    CourseId = (int) Reader["CourseId"],
                    StudentId = (int) Reader["StudentId"]
                };
                aViewEnrollCourses.Add(aEnrollCourse);
            }
            Reader.Close();
            Connection.Close();
            return aViewEnrollCourses;


        }
    }
}