using System;
using System.Collections.Generic;
using System.Text;
using CEMIS.Utility;
using CEMIS.Data.Central;
using CEMIS.Utility.ViewModel;
using Cemis.Data.Central.Entities;

namespace CEMIS.Business.Central.Interface
{
    public interface ICollegeLeadership
    {
        ResponseData<CollegeLeadership> PushCollegeLeadership(CollegeLeadershipViewModel collegeLeadership, long collegeID);
        ResponseData<CouncilMember> PushCollegeCouncilMembers(CouncilMemberViewModel councilMemberVM, long collegeID);
        ResponseData<CouncilSessionViewModel>  PushCouncilSession(CouncilSessionViewModel councilMemberVM, long collegeID);

        ResponseData<CommitteMemberViewModel> PushComiteeMembers(CommitteMemberViewModel committeeMemeberVM, long collegeID);
        ResponseData<CommitteViewModel> PushCommitee(CommitteViewModel CommiteeVM, long collegeID);

    }
}
