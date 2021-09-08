using CEMIS.Data.Entities;
using CEMIS.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace CEMIS.Business.Interface
{
    public interface IFacilityType
    {
        ResponseData<FacilityType> CreateFacilityType(FacilityType facilityType, bool logRequest);
       // ResponseData<FacilityType> CreateFacilityType(long Id, bool LogRequest);
        List<FacilityType> GetAllFacilityType();
        FacilityType GetFacilityTypeById(long Id);
        ResponseData<FacilityType> UpdateFacilityType(FacilityType facilityType, bool logRequest);
        //    ResponseData<FacilityType> DeleteFacilityType(long Id, bool LogRequest);
        bool DeleteFacilityType(long Id, out string message);
    }
}
