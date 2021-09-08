using CEMIS.Data.Entities;
using CEMIS.Utility;
using CEMIS.Utility.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CEMIS.Business.Interface
{
   public interface IUnit
    {
        ResponseData<UnitViewModel> CreateUnit(UnitViewModel unit, bool logRequest);
        List<UnitViewModel> GetAllUnit();
        UnitViewModel GetUnitById(long Id);
        ResponseData<UnitViewModel> UpdateUnit(UnitViewModel unit, bool logRequest);
        bool DeleteUnit(long Id, out string message);
    }
}
