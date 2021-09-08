using CEMIS.Data.Entities;
using CEMIS.Utility;
using CEMIS.Utility.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CEMIS.Business.Interface
{
  public  interface ICommittee
    {
        ResponseData<CommitteViewModel> CreateCommitte(CommitteViewModel committe, bool logRequest);
        List<CommitteViewModel> GetAllCommitte();
        Committee GetCommitteId(string name);
        CommitteViewModel GetCommitteById(long Id);
        ResponseData<CommitteViewModel> UpdateCommitte(CommitteViewModel committe, bool logRequest);
        bool DeleteCommitte(long Id);
    }
}
