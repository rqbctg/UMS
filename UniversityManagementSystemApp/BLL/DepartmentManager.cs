using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystemApp.DAL.Gateway;
using UniversityManagementSystemApp.DAL.Model;

namespace UniversityManagementSystemApp.BLL
{
    public class DepartmentManager
    {
        DepartmentGateway aDepartmentGateway = new DepartmentGateway();

        public string Save(Department aDepartment)
        {
            if (aDepartment.Code.Length>=2 && aDepartment.Code!=null)
            {
                if ( aDepartment.Code.Length<=7)
                {
                    if (aDepartmentGateway.IsExixt(aDepartment.Code))
                    {
                        if (aDepartmentGateway.IsDepartmentNameExixt(aDepartment.Name))
                        {
                            int rowAffected = aDepartmentGateway.Save(aDepartment);
                            if (rowAffected > 0)
                            {
                                return "Deparment Save";
                            }
                            else
                            {
                                return "Department Not Saved";
                            }
                      
                        }
                        else
                        {
                            return "Department Name already Saved";
                        }
                        

                    }
                    else
                    {
                        return "Department Code alreay saved";
                    }
                    
                    
                }
                else
                {
                    return "Code Must be Within 7 Character";
                }
                
            }
            else
            {
                return "Code Must be 2 Charcter Long";
            }
        }

        public List<Department> GetAllDepartment()
        {
            List<Department> aDepartments = aDepartmentGateway.GetAllDepartment();
            return aDepartments;
        }

        public string GetDepartmentCodeByID(int departmentId)
        {
            string departmentCode = aDepartmentGateway.GetDepartmentCodeById(departmentId);

            return departmentCode;
        }

        public int GetDepatmentIdByCode(string code)
        {
            int deptID = aDepartmentGateway.GetDepatmentIdByCode(code);
            return deptID;
        }
    }
}