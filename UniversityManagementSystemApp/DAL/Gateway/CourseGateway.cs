using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystemApp.DAL.Model;

namespace UniversityManagementSystemApp.DAL.Gateway
{
    public class CourseGateway :Gateway
    {
        public bool IsExixstByCode(string code)
        {
            Query = "SELECT * FROM Course WHERE Code='" + code + "'";
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

        public int AddCourse(Course aCourse)
        {
            Query = "INSERT INTO Course(Code,Name,Credit,Description,Department_Id,Semester_Id)Values('"+aCourse.Code+"','"+aCourse.Name+"','"+aCourse.Credit+"','"+aCourse.Description+"','"+aCourse.Department_Id+"','"+aCourse.Semester_Id+"')";
            
            Command = new SqlCommand(Query, Connection);
            //Command.Parameters.Clear();
            //Command.Parameters.Add("Code", SqlDbType.VarChar);
            //Command.Parameters["Code"].Value = aCourse.Code;
            //Command.Parameters.Add("Name", SqlDbType.VarChar);
            //Command.Parameters["Name"].Value = aCourse.Name;
            //Command.Parameters.Add("Credit", SqlDbType.Variant);
            //Command.Parameters["Credit"].Value = aCourse.Credit;
            //Command.Parameters.Add("Description", SqlDbType.Text);
            //Command.Parameters["Description"].Value = aCourse.Description;
            //Command.Parameters.Add("Departmrnt_Id", SqlDbType.Int);
            //Command.Parameters["Departmrnt_Id"].Value = aCourse.Department_Id;
            //Command.Parameters.Add("Semester_Id", SqlDbType.Int);
            //Command.Parameters["Semester_Id"].Value = aCourse.Semester_Id;
            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;

        }

        public bool IsExixstByName(string name)
        {
            Query = "SELECT * FROM Course WHERE Name='" +name + "'";
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

        public List<Course> GetAllCourse()
        {
            Query = "SELECT * FROM Course";
            Connection.Open();
            Command = new SqlCommand(Query, Connection);
            List<Course> aCourses = new List<Course>();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                Course aCourse = new Course()
                {
                    Id = (int)Reader["Id"],
                    Code = Reader["Code"].ToString(),
                    Name = Reader["Name"].ToString(),
                    Credit =  Convert.ToDecimal(Reader["Credit"]),
                    Department_Id = (int) Reader["Department_Id"]

                };
                aCourses.Add(aCourse);
            }
            Reader.Close();
            Connection.Close();
            return aCourses;
            

        }
    }
}