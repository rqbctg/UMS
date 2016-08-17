using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystemApp.DAL.Model;

namespace UniversityManagementSystemApp.DAL.Gateway
{
    public class ViewResultGateway :Gateway
    {
        public List<ViewResultSheet> GetAllEnrollCourse()
        {
            Query = "Select * From ResultSheetView";
            Command = new SqlCommand(Query,Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<ViewResultSheet> aViewResults = new List<ViewResultSheet>();
            while (Reader.Read())
            {
                ViewResultSheet aViewResult = new ViewResultSheet()
                {
                    StudentId = (int)Reader["StudentId"],
                    CourseCode = Reader["CourseCode"].ToString(),
                    CourseName = Reader["CourseName"].ToString(),
                    Grdae = Reader["Grade"].ToString()


                };
                aViewResults.Add(aViewResult);
            }
            Reader.Close();
            Connection.Close();

            return aViewResults;

        }
    }
}