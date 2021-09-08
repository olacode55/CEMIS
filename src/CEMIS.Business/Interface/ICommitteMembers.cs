using CEMIS.Data.Entities;
using CEMIS.Utility;
using CEMIS.Utility.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CEMIS.Business.Interface
{
  public  interface ICommitteMembers
    {
        ResponseData<CommitteMemberViewModel> CreateCommitteMember(CommitteMemberViewModel committeMember, bool logRequest);
        List<CommitteMemberViewModel> GetAllCommitteMember();
        CommitteMemberViewModel GetCommitteMemberById(long Id);
        ResponseData<CommitteMemberViewModel> UpdateCommitteMember(CommitteMemberViewModel committeMember, bool logRequest);
        bool DeleteCommitteMember(long Id, out string message);
    }
}
