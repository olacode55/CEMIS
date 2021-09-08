using Cemis.Business.Central.Interface;
using Cemis.Data.Central.Migrations;
using CEMIS.Business.Central.Interface;
using CEMIS.Data.Central;
using CEMIS.Utility.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cemis.Business.Central.Repository
{
    public class ProgramRepository : IProgram
    {
        private readonly IRepository<ServiceOffered> _serviceofferedRepo;

        public ProgramRepository(IRepository<ServiceOffered> serviceofferedRepo)
        {
            _serviceofferedRepo = serviceofferedRepo;
        }
        public List<KeyValuePairModel> GetProgramByCollegeId(long CollegeId)
        {
            var programs = _serviceofferedRepo.All().Where(x => x.CollegeID == CollegeId && x.IsDeleted == false).ToList();

            if(programs != null && programs.Count > 0)
            {
                return programs.Select(x => new KeyValuePairModel
                {
                    key = int.Parse(x.SourceID.ToString()), //int.Parse(x.Id.ToString()),
                    Value = x.Name
                }).ToList();
            }
            else
            {
                return new List<KeyValuePairModel>();
            }
        }
    }
}
