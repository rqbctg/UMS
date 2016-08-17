using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace UniversityManagementSystemApp.DAL.Gateway
{
    public class OtherGateWay:Gateway
    {
        public int UnassignCourse()
        {
            Query = "Update AssignedCourse Set Status_Id=0";
            Command = new SqlCommand(Query,Connection);
            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;

        }

        public int UnAllocateClassRoom()
        {
            Query = "Update AllocateClassRoom Set StatusId=0";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
            
        }
    }
}