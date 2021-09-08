using CEMIS.Data.Entities;
using CEMIS.Utility;
using CEMIS.Utility.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CEMIS.Business.Interface
{
  public  interface IBasicSalary
    {
        ResponseData<BasicSalaryViewModel> CreateBasicSalary(BasicSalaryViewModel basicSalary, bool logRequest);
        List<BasicSalaryViewModel> GetAllBasicSalary();
        BasicSalaryViewModel GetBasicSalaryById(long Id);
       BasicSalary GetBasicSalarysById(int Gradelevel, int Step);
        ResponseData<BasicSalaryViewModel> UpdateBasicSalary(BasicSalaryViewModel basicSalary, bool logRequest);
        bool DeleteBasicSalary(long Id, out string message);
    }
}
