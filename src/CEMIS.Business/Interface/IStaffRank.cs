using CEMIS.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CEMIS.Business.Interface
{
    public  interface IStaffRank
    {
       List <StaffRank> GetStaffRankById(long Id);
        List<StaffRank> GetStaffRankId(long Id);
        bool GetPrincipal(long Id);


    }
}
