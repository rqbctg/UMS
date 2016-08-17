using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystemApp.DAL.Model;

namespace UniversityManagementSystemApp.DAL.Gateway
{
    public class ResultGateWay : Gateway
    {
        public List<Grade> GetAllGrade()
        {

            Query = "SELECT * FROM GradeTable";
            Connection.Open();
            Command = new SqlCommand(Query, Connection);
            List<Grade> aGrades = new List<Grade>();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                Grade aGrade = new Grade()
                {
                    Id = (int) Reader["Id"],
                    Garde = Reader["GradeName"].ToString()


                };
                aGrades.Add(aGrade);
            }
            Reader.Close();
            Connection.Close();
            return aGrades;
            
        }

        public bool IsresultExist(int courseId, int studentId)
        {
            Query = "SELECT * FROM Result WHERE StudentId='" + studentId + "' and CourseId='"+courseId+"'";
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

        public int SaveResult(Result aResult)
        {
            Query = "INSERT INTO Result(StudentId,CourseId,GradeId) Values('"+aResult.StudentId+"','"+aResult.CourseId+"','"+aResult.GradeId+"')";
            Connection.Open();
            Command = new SqlCommand(Query, Connection);
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;

        }
    }
}