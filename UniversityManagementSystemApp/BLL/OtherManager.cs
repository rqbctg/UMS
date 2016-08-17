using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystemApp.DAL.Gateway;

namespace UniversityManagementSystemApp.BLL
{
    public class OtherManager
    {
        OtherGateWay aOtherGateWay = new OtherGateWay();
        public string UnassignCourse()
        {
            int rowaffected = aOtherGateWay.UnassignCourse();
            if (rowaffected > 0)
            {
                return "Sucessfull Unassigend all Course";
            }
            else
            {
                return "Something went wrong!";
            }
        }

        public string UnAllocateClassRoom()
        {
            int rowaffected = aOtherGateWay.UnAllocateClassRoom();
            if (rowaffected > 0)
            {
                return "Sucessfull Unallocated all Classroom";
            }
            else
            {
                return "Something went wrong!";
            }
            
        }
    }
}