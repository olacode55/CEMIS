using Cemis.Business.Central.Interface;
using Cemis.Data.Central.Entities;
using CEMIS.Business.Central.Interface;
using CEMIS.Utility.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cemis.Business.Central.Repository
{
    public class CouncilSessionRepository : ICouncilSession
    {
        private IRepository<CouncilSession> _councilSessionRepo;

        public CouncilSessionRepository(IRepository<CouncilSession> councilSessionRepo)
        {
            _councilSessionRepo = councilSessionRepo;
        }
        List<KeyValuePairModel> ICouncilSession.GetCouncilSessionByCollegeId(long collegeId)
        {
            var councilSession = _councilSessionRepo.All().Where(x => x.CollegeID == collegeId && x.IsDeleted == false && x.IsActive == true).ToList();

            if (councilSession != null && councilSession.Count > 0)
            {
                return councilSession.Select(x => new KeyValuePairModel
                {
                    key = int.Parse(x.SourceID.ToString()),
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
