using System.Collections.Generic;
using CEMIS.Data;
using CEMIS.Data.Entities;
using CEMIS.Utility;
using CEMIS.Utility.ViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CEMIS.Business
{
    public interface IFacility
    {
        //ResponseData<CollegeFacility> CreateFacility(CollegeFacility facility, bool logRequest);
        //ResponseData<CollegeFacility> DeleteFacility(long Id, bool LogRequest);
        bool CreateFacility(CollegeFacilityViewModel model, out string message);
        bool UpdateFacility(CollegeFacilityViewModel model, out string message);
        bool DeleteFacility(long Id, out string message);
        List<CollegeFacilityViewModel> GetAllFacilities();
        CollegeFacilityViewModel GetFacilityById(long Id);
        IEnumerable<SelectListItem> GetFacilityTypeList();
        //ResponseData<CollegeFacility> UpdateFacility(CollegeFacility facility, bool logRequest);
    }
}