using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystemApp.DAL.Gateway;
using UniversityManagementSystemApp.DAL.Model;

namespace UniversityManagementSystemApp.BLL
{
    public class CourseManager
    {
        CourseGateway aCourseGateway = new CourseGateway();
        public string AddCoures(Course aCourse)
        {
            if (aCourse.Code.Length >= 5)
            {
                if (aCourseGateway.IsExixstByCode(aCourse.Code))
                {
                    if (aCourseGateway.IsExixstByName(aCourse.Name))
                    {
                        if (aCourse.Credit >= (decimal) .5)
                        {
                            if (aCourse.Credit <= 5)
                            {
                                int rowAffected = aCourseGateway.AddCourse(aCourse);
                                if (rowAffected > 0)
                                {
                                    return "Course Saved";
                                }
                                else
                                {
                                    return "Course Not Saved";
                                }

                            }
                            else
                            {
                                return "Credit Must Be With in 5";
                            }


                        }
                        else
                        {
                            return "Credit Must Be getter than .5";
                        }


                    }
                    else
                    {
                        return "Course Name Already Exists";
                    }


                }
                else
                {
                    return "Course code already Exists";
                }


            }
            else
            {
                return "Course  Code Must Be Atleast 5 charcter";
                
            }

           

        }

        public List<Course> GetAllCourse()
        {

            List<Course> aCourses = aCourseGateway.GetAllCourse();
            return aCourses;
        }
    }
}