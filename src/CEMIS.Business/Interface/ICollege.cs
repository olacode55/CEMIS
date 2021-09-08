using System.Collections.Generic;
using System.Threading.Tasks;
using CEMIS.Data.Entities;
using CEMIS.Data.ViewModel;
using CEMIS.Utility.ViewModel;

namespace CEMIS.Business
{
    public interface ICollege
    {

        List<College> GetAllColleges();
        CollegeViewModel GetCollegeById(long Id);

        CollegeClassRoomDataViewModel GetClassRoomDataById(long Id);
        CollegeClassRoomInfoViewModel GetClassRoomInfoById(long Id);
        List<CollegeClassRoomInfoViewModel> GetClassRoomInfoListById(long Id);

        List<CollegeViewModel> GetCollegeListById(long Id);
        //ResponseData<College> UpdateCollege(College college, bool logRequest);
        bool CreateCollege(CollegeViewModel model, out string message);

        bool UpdateCollege(CollegeViewModel model, out string message);
        //bool CreateCollegeFacility(CollegeFacilityViewModel model, out string message);

        //bool UpdateCollegeFacility(CollegeFacilityViewModel model, out string message);
        bool CreateCollegeClassRoomData(CollegeClassRoomDataViewModel model, out string message);

        bool UpdateCollegeClassRoomData(CollegeClassRoomDataViewModel model, out string message);
        bool CreateCollegeClassRoomInfo(CollegeClassRoomInfoViewModel model, out string message);

        bool UpdateCollegeClassRoomInfo(CollegeClassRoomInfoViewModel model, out string message);

        CollegeFormDataViewModel GetCollegeSummary();

        bool DeleteClassRoomInfo(long Id, out string message, out long CollegeId);

        bool UpdateCollegeIsSynced(long CollegeId);


    }
}
