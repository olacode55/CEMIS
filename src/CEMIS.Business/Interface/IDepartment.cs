using CEMIS.Data.Entities;
using CEMIS.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace CEMIS.Business.Interface
{
    public interface IDepartment
    {
        ResponseData<Department> CreateDepartment(Department department, bool logRequest);
        // ResponseData<FacilityType> CreateFacilityType(long Id, bool LogRequest);
        List<Department> GetAllDepartment();
        Department GetDepartmentById(long Id);
        ResponseData<Department> UpdateDepartment(Department department, bool logRequest);
        bool DeleteDepartment(long Id, out string message);
    }
}
