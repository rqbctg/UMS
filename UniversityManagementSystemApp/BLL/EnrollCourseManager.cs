using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystemApp.DAL.Gateway;
using UniversityManagementSystemApp.DAL.Model;

namespace UniversityManagementSystemApp.BLL
{
    public class EnrollCourseManager
    {
        EnrollCourseGateway aEnrollCourseGateway = new EnrollCourseGateway();

        public string EnrollCourse(EnrollCourse aEnrollCourse)
        {
            if (aEnrollCourseGateway.IsCourseEnrolledByStudent(aEnrollCourse.CourseId, aEnrollCourse.StudentId))
            {
                int rowAfeected = aEnrollCourseGateway.EnrollCourse(aEnrollCourse);
                if (rowAfeected > 0)
                {
                    return "Course Enrolled";
                }
                else
                {
                    return "Course not Enrolled";
                }

            }
            else
            {
                return "Student Already Enrolled in The Course";
            }
        }


        public List<ViewEnrollCourse> GetAllEnrolledCourse()
        {

            List<ViewEnrollCourse> aViewEnrollCourses = aEnrollCourseGateway.GetAllEnrolledCourse();
            return aViewEnrollCourses;
        }
    }
}