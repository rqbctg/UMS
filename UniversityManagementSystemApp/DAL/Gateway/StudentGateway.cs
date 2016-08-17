using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystemApp.DAL.Model;

namespace UniversityManagementSystemApp.DAL.Gateway
{
    public class StudentGateway : Gateway
    {
        public bool IsEmailExixt(string email)
        {
            

            Query = "SELECT * FROM Student WHERE Email='" + email + "'";
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

        public int SaveStudent(Student aStudent)
        {
            Query = "INSERT INTO Student(Name,Email,Contactno,Date,Address,DepartmentID,Registrationno,Code)Values('" + aStudent.Name + "','" + aStudent.Email + "','" +aStudent.Contactno+ "','" + aStudent.Date + "','" + aStudent.Address + "','" + aStudent.DepartmentId + "','"+aStudent.Registration_Number+"','"+aStudent.Code+"')";

            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }

        public int GetRowCount(string regno)
        {
            Query = "Select count(*) from Student where Registrationno  LIKE '%"+regno+"%'";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            int rowAffected = (int) Command.ExecuteScalar();
            Connection.Close();
            return rowAffected;
        }

        public List<Student> GetAllStudent()
        {
            Query = "SELECT * FROM Student";
            Command = new SqlCommand(Query,Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Student>  aStudents = new List<Student>();
            while (Reader.Read())
            {
                Student aStudent = new Student()
                {
                    Id = (int) Reader["Id"],
                    Name = Reader["Name"].ToString(),
                    Email = Reader["Email"].ToString(),
                    Contactno = Reader["Contactno"].ToString(),
                    Code = Reader["Code"].ToString(),
                    DepartmentId = (int) Reader["DepartmentId"],
                    Registration_Number = Reader["Registrationno"].ToString()

                };
                aStudents.Add(aStudent);
            }
            Reader.Close();
            Connection.Close();
            return aStudents;


        }
    }
    }
