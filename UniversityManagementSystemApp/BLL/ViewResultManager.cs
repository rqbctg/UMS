using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystemApp.DAL.Gateway;
using UniversityManagementSystemApp.DAL.Model;

namespace UniversityManagementSystemApp.BLL
{
    public class ViewResultManager
    {
        ViewResultGateway aViewResultGateway = new ViewResultGateway();

        public List<ViewResultSheet> GetAllEnrollCourse()
        {

            List<ViewResultSheet> aViewResults = aViewResultGateway.GetAllEnrollCourse();
            return aViewResults;
        }
    }
}