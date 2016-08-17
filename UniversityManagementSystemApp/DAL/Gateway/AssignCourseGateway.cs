using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystemApp.DAL.Model;

namespace UniversityManagementSystemApp.DAL.Gateway
{
    public class AssignCourseGateway : Gateway
    {
        public bool IsCourseAssigned(int courseId)
        {
            int status = 1;
            Query = "SELECT * FROM AssignedCourse WHERE Status_Id ='"+status+"' And Course_Id='" + courseId + "'  ";
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

        public int SaveAssignedCourse(AssignCourse assignCourse)
        {
            Query = "INSERT INTO AssignedCourse(Department_Id,Teacher_Id,Course_Id,Status_Id) Values('"+assignCourse.Department_Id+"','"+assignCourse.Teacher_Id+"','"+assignCourse.Course_Id+"','1')";
            Connection.Open();
            Command = new SqlCommand(Query, Connection);
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }
    }
}