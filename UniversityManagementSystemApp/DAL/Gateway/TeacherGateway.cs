using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystemApp.DAL.Model;

namespace UniversityManagementSystemApp.DAL.Gateway
{
    public class TeacherGateway : Gateway
    {
        public bool IsEmailExist(string email)
        {
            Query = "SELECT * FROM Teacher WHERE Email='" + email + "'";
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

        public int SaveTeacher(Teacher aTeacher)
        {
            Query =
                "INSERT INTO Teacher(Name,Address,Email,Contactno,Designation_Id,Department_Id,CreditToTake,Creditremain) VALUES('" +
                aTeacher.Name + "','" + aTeacher.Address + "','" + aTeacher.Email + "','" + aTeacher.Contactno + "','" +
                aTeacher.Designation_Id + "','" + aTeacher.Department_Id + "','" + aTeacher.CreditToTake + "','" +
                aTeacher.Creditremain + "')";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }

        public List<Teacher> GetAllTeacher()
        {
            Query = "SELECT * FROM Teacher";
            Connection.Open();
            Command = new SqlCommand(Query, Connection);
            List<Teacher> aTeachers = new List<Teacher>();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                Teacher teacher = new Teacher()
                {
                    Id = (int) Reader["Id"],
                    Name = Reader["Name"].ToString(),
                    CreditToTake = (int) Reader["CreditToTake"],
                    Creditremain = Convert.ToDecimal(Reader["Creditremain"]),
                    Department_Id = (int) Reader["Department_Id"]


                };
                aTeachers.Add(teacher);
            }
            Reader.Close();
            Connection.Close();
            return aTeachers;
        }

        public Teacher GetTeacherById(int id)
        {
            Query = "SELECT * FROM Teacher Where Id='" + id + "'";
            Connection.Open();
            Command = new SqlCommand(Query, Connection);
            Teacher aTeacher = new Teacher();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                aTeacher = new Teacher()
                {
                    Id = (int) Reader["Id"],
                    Name = Reader["Name"].ToString(),
                    CreditToTake = (int) Reader["CreditToTake"],
                    Creditremain = (int) Reader["Creditremain"]



                };

            }
            Reader.Close();
            Connection.Close();
            return aTeacher;
        }



        public int UpdateCredittoremain(decimal tempCredit, int teacherId)
        {
            Query = "UPDATE Teacher SET Creditremain='" + tempCredit + "' Where Id='" + teacherId + "' ";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;

        }
    }
}