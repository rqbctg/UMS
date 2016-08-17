using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystemApp.DAL.Gateway;
using UniversityManagementSystemApp.DAL.Model;

namespace UniversityManagementSystemApp.BLL
{
    public class ResultManager
    {
        ResultGateWay aResultGateWay = new ResultGateWay();

        public List<Grade> GetAllGrade()
        {
            List<Grade> aGrades = aResultGateWay.GetAllGrade();
            return aGrades;

        }

        public string SaveResult(Result aResult)
        {
            if (aResultGateWay.IsresultExist(aResult.CourseId,aResult.StudentId))
            {
                int rowAffected = aResultGateWay.SaveResult(aResult);
                if (rowAffected > 0)
                {
                    return "Graded Sucessfull";
                }
                else
                {
                    return "Graded not sucessfull";
   
                }

            }
            else
            {
                return "This Course already Graded For This Student";
            }
        }
    }
}