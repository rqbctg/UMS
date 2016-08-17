using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystemApp.DAL.Gateway;
using UniversityManagementSystemApp.DAL.Model;

namespace UniversityManagementSystemApp.BLL
{
    public class TeacherManager
    {
        TeacherGateway aTeacherGateway = new TeacherGateway();

        public string SaveTeacher(Teacher aTeacher)
        {
            if (aTeacher.CreditToTake>0)
            {
                if (aTeacherGateway.IsEmailExist(aTeacher.Email))
                {
                    int rowAffected = aTeacherGateway.SaveTeacher(aTeacher);
                    if (rowAffected>0)
                    {
                        return "Teacher Details  saved";

                    }
                    else
                    {
                        return "Teacher Details  not saved";
                        
                    }


                }
                else
                {
                    return "Email Already Saved";
                }
                
            }
            else
            {
                return "Credit to Be taken Must Be a positive Number";
            }
        }

        public List<Teacher> GetAllTeacher()
        {
            List<Teacher> aTeachers = aTeacherGateway.GetAllTeacher();
            return aTeachers;
        }

        public Teacher GetTeacherById(int id)
        {
            Teacher aTeacher = aTeacherGateway.GetTeacherById(id);
            return aTeacher;

        }
    }
}