using CEMIS.Business.Interface;
using CEMIS.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CEMIS.Business.Repository
{
    public class StaffRankRepostory : IStaffRank
    {
        private IRepository<StaffRank> _StaffRankRepo;

        public StaffRankRepostory(IRepository<StaffRank> StaffRankRepo)
        {
            _StaffRankRepo = StaffRankRepo;

        }

        public bool GetPrincipal(long Id)
        {
            var fetchdate = _StaffRankRepo.Filter(x => x.Id == Id && x.IsPrincipal == true).FirstOrDefault();
            if (fetchdate !=null)
            {
                return true;

            }
            else
            {
                return false;
            }
            
        }

        public List<StaffRank> GetStaffRankById(long Id)
        {
            var fetchdate = _StaffRankRepo.Filter(x => x.StaffCategoryId == Id).ToList();
            return fetchdate;
        }

        public List<StaffRank> GetStaffRankId(long Id)
        {
            var fetchdate = _StaffRankRepo.Filter(x => x.Id == Id).ToList();
            return fetchdate;
        }
    }
}
