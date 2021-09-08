using CEMIS.Business.Interface;
using CEMIS.Data.Entities;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace CEMIS.Business.Repository
{
    public class StaffCategoryRepository : IStaffCategory
    {
        private IRepository<StaffCategory> _StaffcategoryRepo;

        public StaffCategoryRepository(IRepository<StaffCategory> StaffcategoryRepo)
        {
            _StaffcategoryRepo = StaffcategoryRepo;

        }

        public StaffCategory GetStaffCategory(long Id)
        {
            var fetchdata = _StaffcategoryRepo.Find(Id);
            return fetchdata;
        }

        public List <StaffCategory> GetStaffCategoryById(long stafftypeid)
        {
            var fetchdate = _StaffcategoryRepo.Filter(x => x.StaffTypeId == stafftypeid).ToList();

            return fetchdate;
        }

        public List<StaffCategory> GetStaffCategoryId(long Id)
        {
            var fetchdata = _StaffcategoryRepo.Filter(x => x.Id == Id).ToList();
            return fetchdata;
        }
    }
}
