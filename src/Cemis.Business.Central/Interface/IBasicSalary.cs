
using Cemis.Data.Central.Entities;
using CEMIS.Utility;
using CEMIS.Utility.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CEMIS.Business.Central.Interface
{
  public  interface IBasicSalary
    {
        ResponseData<BasicSalaryViewModel> CreateBasicSalary(BasicSalaryViewModel basicSalary, long user);
        List<BasicSalaryViewModel> GetAllBasicSalary();
        ResponseData<List<BasicSalaryViewModel>> GetAllBasicSalaryAPI();
        BasicSalaryViewModel GetBasicSalaryById(long Id);
        BasicSalary GetBasicSalarysById(int Gradelevel, int Step);
        ResponseData<BasicSalaryViewModel> UpdateBasicSalary(BasicSalaryViewModel basicSalary, long user);
        bool DeleteBasicSalary(long Id, out string message);
    }
}
