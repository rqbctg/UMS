using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystemApp.DAL.Model;

namespace UniversityManagementSystemApp.DAL.Gateway
{
    public class DesignationGateway : Gateway
    {
        public List<Designation> GetAllDesignation()
        {
            Query = "SELECT * From Designation";
            Connection.Open();
            Command = new SqlCommand(Query,Connection);
            List<Designation> aDesignations = new List<Designation>();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                Designation aDesignation =new Designation()
                {
                    Id = (int)Reader["Id"],
                    Name = Reader["Name"].ToString()
                };
                aDesignations.Add(aDesignation);
            }
            Reader.Close();
            Connection.Close();

            return aDesignations;
        }
    }
}