using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystemApp.DAL.Gateway;
using UniversityManagementSystemApp.DAL.Model;

namespace UniversityManagementSystemApp.BLL
{
    public class AssignCourseManager
    {
        AssignCourseGateway assignCourseGateway = new AssignCourseGateway();
        TeacherGateway aTeacherGateway = new TeacherGateway();

        public string SaveAssignedCourse(AssignCourse assignCourse)
        {
            if (assignCourseGateway.IsCourseAssigned(assignCourse.Course_Id))
            {
                int rowAfeected = assignCourseGateway.SaveAssignedCourse(assignCourse);
                if (rowAfeected>0)
                {
                    decimal tempCredit = assignCourse.Creditremain - assignCourse.Credit;
                    int rowAfeectedbyUpdate = aTeacherGateway.UpdateCredittoremain(tempCredit,assignCourse.Teacher_Id);
                    if (rowAfeectedbyUpdate > 0)
                    {
                        return "Course Assigend sucessfull"; 
                    }
                    else
                    {
                        return "Credit no updated";

                    }
                    

                }
                else
                {
                    return "Course Assigend not sucessfull";
                }

            }
            else
            {
                return "Course Already Assigned";
            }
        }
    }
}