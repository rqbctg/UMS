using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace UniversityManagementSystemApp.DAL.Model
{
    public class AllocateClassRoom
    {

        public int Id { get; set; }
        //[Required(ErrorMessage = "Depatment Must Be selectd")]
        //[DisplayName("Department")]
        public int DepartmentId { get; set; }
        //[Required(ErrorMessage = "Course Must Be selectd")]
        //[DisplayName("Course")]
        public int CourseId { get; set; }
        //[Required(ErrorMessage = "Room Must Be selectd")]
        //[DisplayName("Room")]
        public int RoomId { get; set; }
        //[Required(ErrorMessage = "Day Must Be selectd")]
        //[DisplayName("Day")]
        public int DayId { get; set; }
        public DateTime DateTimeFrom { get; set; }
        public DateTime DateTimeTo { get; set; }

    }
}