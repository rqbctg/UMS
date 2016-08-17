using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystemApp.DAL.Gateway;
using UniversityManagementSystemApp.DAL.Model;

namespace UniversityManagementSystemApp.BLL
{
    public class ViewAllocatedClassRoomManager
    {
        ViewAllocatedClassRoomGateway aAllocatedClassRoomGateway = new ViewAllocatedClassRoomGateway();

        public List<ViewAllocatedClassRoom> GetAllViewAllocatedClassRoom()
        {
            List<ViewAllocatedClassRoom> aViewAllocatedClassRooms =
                aAllocatedClassRoomGateway.GetAllViewAllocatedClassRoom();
            return aViewAllocatedClassRooms;
        }
    }
}