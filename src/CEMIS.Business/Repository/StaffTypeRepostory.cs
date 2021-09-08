using CEMIS.Business.Interface;
using CEMIS.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CEMIS.Business.Repository
{
    public class StaffTypeRepostory : IStaffType
    {
        private IRepository<StaffType> _StafftypeRepo;

        public StaffTypeRepostory(IRepository<StaffType> StafftypeRepo)
        {
            _StafftypeRepo = StafftypeRepo;
        }
        public List<StaffType> GetAllStaffType()
        {
            return _StafftypeRepo.All().Where(m => m.IsActive == true && m.IsDeleted == false).ToList();
        }
    }
}
