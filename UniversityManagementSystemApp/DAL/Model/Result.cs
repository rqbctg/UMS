using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UniversityManagementSystemApp.DAL.Model
{
    public class Result
    {
        public int  Id { get; set; }

        //[DisplayName("Select a Student")]
        public int StudentId { get; set; }
       
        //[DisplayName("Select Course")]
        public  int CourseId { get; set; }

        //[DisplayName("Select Grade")]
        public int  GradeId { get; set; }

    }
}