using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using UniversityManagementSystemApp.DAL.Model;

namespace UniversityManagementSystemApp.DAL.Gateway
{
    public class ViewAllocatedClassRoomGateway :Gateway
    {
        public List<ViewAllocatedClassRoom> GetAllViewAllocatedClassRoom()
        {
            Query = "SELECT * From AllocateClassRoomView";
            Command = new SqlCommand(Query, Connection);
            List<ViewAllocatedClassRoom> aViewAllocatedClassRooms = new List<ViewAllocatedClassRoom>();
            Connection.Open();
            Reader = Command.ExecuteReader();
           
            while (Reader.Read())
            {
                ViewAllocatedClassRoom aViewClassRoom = new ViewAllocatedClassRoom();
                aViewClassRoom.DepartmentId = (int) Reader["DepartmentId"];
                aViewClassRoom.CourseCode = Reader["CourseCode"].ToString();
                aViewClassRoom.CourseName = Reader["CourseName"].ToString();
                aViewClassRoom.ClassRoomName = Reader["RoomName"].ToString();
                aViewClassRoom.DayN = Reader["DayN"].ToString();
                string strtime;
                string endtime;
                if (Reader["StartFrom"]==DBNull.Value)
                {
                    strtime = "";

                }
                else
                {
                    strtime = Convert.ToDateTime(Reader["StartFrom"]).ToString("HH:mm  tt");
                    
                }
                if (Reader["Endto"]==DBNull.Value)
                {
                    endtime = "";
                }
                else
                {
                    DateTime EndTime = Convert.ToDateTime(Reader["Endto"]).AddMinutes(+1);
                    endtime = EndTime.ToString("HH:mm tt");

                }
                aViewClassRoom.STartTime = strtime;
                

                aViewClassRoom.EndTime = endtime;

            
                //aViewClassRoom.STartTime =(Reader["StartFrom"]).ToString();
                //aViewClassRoom.EndTime =  (Reader["Endto"]).ToString();
                aViewAllocatedClassRooms.Add(aViewClassRoom);
            }
            Reader.Close();
            Connection.Close();
            return aViewAllocatedClassRooms;
            

        }
    }
}