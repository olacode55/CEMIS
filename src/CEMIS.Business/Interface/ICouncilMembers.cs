using CEMIS.Data.Entities;
using CEMIS.Utility;
using CEMIS.Utility.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CEMIS.Business.Interface
{
  public  interface ICouncilMembers
    {
        ResponseData<CouncilMemberViewModel> CreateMember(CouncilMemberViewModel member, bool logRequest);
        List<CouncilMemberViewModel> GetAllMember();
        CouncilMemberViewModel GetMemberById(long Id);
        ResponseData<CouncilMemberViewModel> UpdateMember(CouncilMemberViewModel member, bool logRequest);
        bool DeleteMember(long Id, out string message);
    }
}
