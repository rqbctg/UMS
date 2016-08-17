using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystemApp.DAL.Gateway;
using UniversityManagementSystemApp.DAL.Model;

namespace UniversityManagementSystemApp.BLL
{
    public class StudentManager
    {
      StudentGateway aStudentGateway = new StudentGateway();
        public string SaveStudent(Student aStudent)
        {
            if (aStudentGateway.IsEmailExixt(aStudent.Email))
            {
               int rowAfeected  = aStudentGateway.SaveStudent(aStudent);
                if (rowAfeected>0)
                {
                    return aStudent.Registration_Number+"    Student Saved";

                }
                else
                {
                    return "Student not Saved";
                }


            }
            else
            {
                return "Email Aready Saved";
            }
            
            

        }

        public int GetRowCount(string regno)
        {
            int count = aStudentGateway.GetRowCount(regno);
            return count;
        }

        public List<Student> GetAllStudent()
        {
            List<Student> aStudents = aStudentGateway.GetAllStudent();
            return aStudents;

        }
    }
}