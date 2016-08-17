using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementSystemApp.DAL.Model
{
    public class ViewAllocatedClassRoom
    {
        public int Id { get; set; }
        public  int DepartmentId { get; set; }
        public string CourseCode { get; set; }
        public  string CourseName { get; set; }
        public string ClassRoomName { get; set; }
        public string DayN { get; set; }
        public string STartTime { get; set; }
        public string EndTime { get; set; }

    }
}