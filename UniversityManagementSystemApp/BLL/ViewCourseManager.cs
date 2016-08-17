using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystemApp.DAL.Gateway;
using UniversityManagementSystemApp.DAL.Model;

namespace UniversityManagementSystemApp.BLL
{
    public class ViewCourseManager
    {
        ViewCourseGateway aViewCourseGateway =new ViewCourseGateway();

        public List<ViewCourse> GetAllViewCourse()
        {

            List<ViewCourse> aViewCourses = aViewCourseGateway.GetAllViewCourse();
            return aViewCourses;
        }
    }
}