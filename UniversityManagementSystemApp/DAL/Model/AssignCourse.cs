using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementSystemApp.DAL.Model
{
    public class AssignCourse
    {
        public int Id { get; set; }
        public int Department_Id { get; set; }
        public int Teacher_Id { get; set; }
        public int Course_Id { get; set; }
        public decimal Creditremain { get; set; }
        public decimal Credit { get; set; }

        public int Status_Id { get; set; }
        

    }
}