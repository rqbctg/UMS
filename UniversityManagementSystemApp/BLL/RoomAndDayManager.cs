using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystemApp.DAL.Gateway;
using UniversityManagementSystemApp.DAL.Model;

namespace UniversityManagementSystemApp.BLL
{
    public class RoomAndDayManager
    {
        RoomAndDayGateWay aRoomAndDayGateWay = new RoomAndDayGateWay();

        public List<Day> GetAllDay()
        {

            List<Day> aDays = aRoomAndDayGateWay.GetAllDay();
            return aDays;
        }

        public List<Room> GetAllRoom()
        {

            List<Room> aRooms = aRoomAndDayGateWay.GetAllRoom();
            return aRooms;
        }
    }
}