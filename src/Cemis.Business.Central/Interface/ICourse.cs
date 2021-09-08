using CEMIS.Data.Central;
using CEMIS.Utility.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cemis.Business.Central.Interface
{
    public interface ICourse
    {
        List<KeyValuePairModel> GetCoursesByProgramId(long programId, long collegeId);
    }
}
