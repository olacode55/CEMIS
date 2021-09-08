using CEMIS.Utility.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cemis.Business.Central.Interface
{
    public interface ICouncilSession
    {
        List<KeyValuePairModel> GetCouncilSessionByCollegeId(long collegeId);
    }
}
