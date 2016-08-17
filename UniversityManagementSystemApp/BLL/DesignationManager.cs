using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystemApp.DAL.Gateway;
using UniversityManagementSystemApp.DAL.Model;

namespace UniversityManagementSystemApp.BLL
{
    public class DesignationManager
    {
         DesignationGateway aDesignationGateway = new DesignationGateway();

        public List<Designation> GetAllDesignation()
        {
            List<Designation> aDesignations = aDesignationGateway.GetAllDesignation();
            return aDesignations;
        }
    }
}