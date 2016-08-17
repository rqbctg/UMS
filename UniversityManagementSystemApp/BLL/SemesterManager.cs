using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystemApp.DAL.Gateway;
using UniversityManagementSystemApp.DAL.Model;

namespace UniversityManagementSystemApp.BLL
{
    public class SemesterManager
    {
        SemesterGateway aSemesterGateway = new SemesterGateway();

        public List<Semester> GetAllSemester()
        {
            List<Semester> aSemesters = aSemesterGateway.GetAllSemester();
            return aSemesters;
        }
    }
}