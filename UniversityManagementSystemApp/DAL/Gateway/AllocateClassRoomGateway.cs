using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystemApp.DAL.Model;

namespace UniversityManagementSystemApp.DAL.Gateway
{
    public class AllocateClassRoomGateway :Gateway
    {
        public int SaveAlocateClassRoom(AllocateClassRoom allocateClassRoom)
        {
            Query = "INSERT INTO AllocateClassRoom(DepartmentId,CourseId,RoomId,DayId,DateFrom,DateTo,StatusId) Values('" +
                    allocateClassRoom.DepartmentId + "','" + allocateClassRoom.CourseId + "','" +
                    allocateClassRoom.RoomId + "','" + allocateClassRoom.DayId + "','" +
                    allocateClassRoom.DateTimeFrom + "','" + allocateClassRoom.DateTimeTo + "','1')";
            Connection.Open();
            Command = new SqlCommand(Query, Connection);
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }

        public int IsRoomFree(int roomId, DateTime dateTimeFrom, DateTime dateTimeTo, int dayId)
        {
            //Query = "select * from AllocateClassRoom  where  DateFrom between'"+dateTimeFrom+"' and '"+dateTimeTo+"' and Dateto between '"+dateTimeFrom+"' and '"+dateTimeTo+"' and DayId='"+dayId+"' and RoomId='"+roomId+"'";
            
            //Query = "select COUNT(*) from AllocateClassRoom as a where a.DateTo >='" + dateTimeFrom + "' and a.DateTo<='" + dateTimeTo + "' and a.DateFrom >='"+dateTimeFrom+"' and a.DateFrom<='"+dateTimeTo+"'  and DayId ='" + dayId + "' and RoomId= '" + roomId + "'";

            Query = "select COUNT(*) from AllocateClassRoom as a where (a.DateFrom <='" + dateTimeFrom + "' or  a.Dateto <='" + dateTimeFrom + "') and (a.DateFrom>='" + dateTimeTo + "' or a.DateTo>='" + dateTimeTo + "') and DayId ='" + dayId + "' and RoomId= '" + roomId + "' and StatusId='1'";

            
            
            Connection.Open();
            Command = new SqlCommand(Query, Connection);
            int rowCount = (int) Command.ExecuteScalar();
            Connection.Close();
            return rowCount;

        }
    }
}