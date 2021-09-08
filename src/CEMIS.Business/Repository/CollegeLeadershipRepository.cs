using CEMIS.Business.Interface;
using CEMIS.Data;
using CEMIS.Data.Entities;
using CEMIS.Utility;
using CEMIS.Utility.ViewModel;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace CEMIS.Business
{
    public class CollegeLeadershipRepository : ICollegeLeadership
    {
        private IRepository<CollegeLeadership> _collegeleadershiprepo;
        private IRepository<APIRequestLog> _apiRequestRepo;
        private IConfiguration _configration;
        private IAuthUser _authUser;
        private ICouncilSession _councilSession;

        public CollegeLeadershipRepository(IRepository<CollegeLeadership> collegeleadershiprepo, IRepository<APIRequestLog> apiRequestRepo, ICouncilSession councilSession, IConfiguration configration,IAuthUser authUser)
        {
            _collegeleadershiprepo = collegeleadershiprepo;
            _apiRequestRepo = apiRequestRepo;
            _configration = configration;
            _authUser = authUser;
            _councilSession = councilSession;
        }

        public List<CollegeLeadershipViewModel> GetAllcollegeLeadership()
        {
            var fecthdata = new List<CollegeLeadershipViewModel>();
            var item = _collegeleadershiprepo.All().Where(m => m.IsDeleted == false && m.IsActive == true).ToList();
           

            fecthdata = ((from x in item
                          select new CollegeLeadershipViewModel
                          {
                              Id = x.Id,
                              Name = x.Name,
                              CouncilMemberSponsor = x.CouncilMemberSponsor,
                              CouncilMemberPhone1 = x.CouncilMemberPhone1,
                              CouncilMemberPostalAddress = x.CouncilMemberPostalAddress,
                              CouncilMemberPhone2   = x.CouncilMemberPhone2,
                              DateAppointed = x.DateAppointed,
                              DateOfBirth = x.DateOfBirth,
                              DateLeft = x.DateLeft,
                              Session = x.Session.ToString(),
                              SessionName = x.SessionName,
                              Role = x.Role,




                          }).ToList());

            return fecthdata;
        }

        public ResponseData<CollegeLeadershipViewModel> CreateCollegeLeadership(CollegeLeadershipViewModel collegeLeadership, bool logRequest)
        {
            ResponseData<CollegeLeadershipViewModel> resp;
            using (var transaction = new TransactionScope())
            {
                try
                {
                    var session = _councilSession.GetById(long.Parse(collegeLeadership.Session));
                    CollegeLeadership leadership = new CollegeLeadership()
                    {
                        Id = collegeLeadership.Id,
                        Name = collegeLeadership.Name,
                        CouncilMemberSponsor = collegeLeadership.CouncilMemberSponsor,
                        CouncilMemberPhone1 = collegeLeadership.CouncilMemberPhone1,
                        CouncilMemberPostalAddress = collegeLeadership.CouncilMemberPostalAddress,
                        CouncilMemberPhone2 = collegeLeadership.CouncilMemberPhone2,
                        DateAppointed = collegeLeadership.DateAppointed,
                        DateOfBirth = collegeLeadership.DateOfBirth,
                        DateLeft = collegeLeadership.DateLeft,
                        Session = Convert.ToInt32(collegeLeadership.Session),
                        Role = collegeLeadership.Role,
                        Gender = collegeLeadership.Gender,
                        CouncilMemberEmail = collegeLeadership.CouncilMemberEmail,
                        SessionName = session.Name,
                        DateCreated = DateTime.Now,
                        DateUpdated = null,
                        CreatedBy = long.Parse(_authUser.UserId),
                        IsDeleted = false,
                        IsActive = true,
                        IsSynched = false,
                        UpdatedBy = null,


                    };
                   

                    if (logRequest)
                    {
                        var data = Newtonsoft.Json.JsonConvert.SerializeObject(collegeLeadership);
                        string url = _configration.GetSection("BaseAPIURl").Value + "Facility";
                        var apiRequestLog = new APIRequestLog
                        {
                            Data = data,
                            RequestType = HTTPRequestType.Post,
                            Synched = false,
                            Url = url
                        };
                        _apiRequestRepo.Create(apiRequestLog);
                    }

                    _collegeleadershiprepo.Create(leadership);

                    transaction.Complete();

                    resp = new ResponseData<CollegeLeadershipViewModel>
                    {
                        Message = "CollegeLeadership created successfully",
                        RespCode = "00",
                        IsSuccessful = true
                    };

                    return resp;
                }
                catch (Exception ex)
                {
                    return new ResponseData<CollegeLeadershipViewModel>
                    {
                        Message = "Operation failed",
                        RespCode = "04",
                        IsSuccessful = false
                    };
                }
            }
        }
        public ResponseData<CollegeLeadershipViewModel> UpdateCollegeLeadership(CollegeLeadershipViewModel collegeLeadership, bool logRequest)
        {
            ResponseData<CollegeLeadershipViewModel> resp;
            using (var transaction = new TransactionScope())
            {
                try
                {
                    var session = _councilSession.GetById(long.Parse(collegeLeadership.Session));
                    if (logRequest)
                    {
                        var data = Newtonsoft.Json.JsonConvert.SerializeObject(collegeLeadership);
                        string url = _configration.GetSection("BaseAPIURl").Value + "Facility";
                        var apiRequestLog = new APIRequestLog
                        {
                            Data = data,
                            RequestType = HTTPRequestType.Put,
                            Synched = false,
                            Url = url
                        };
                        _apiRequestRepo.Create(apiRequestLog);
                    }
                    var getcollegeLeadership = _collegeleadershiprepo.Find(collegeLeadership.Id);

                    getcollegeLeadership.CouncilMemberEmail = collegeLeadership.CouncilMemberEmail;
                    getcollegeLeadership.CouncilMemberPhone1 = collegeLeadership.CouncilMemberPhone1;
                    getcollegeLeadership.CouncilMemberPhone2 = collegeLeadership.CouncilMemberPhone2;
                    getcollegeLeadership.CouncilMemberPostalAddress = collegeLeadership.CouncilMemberPostalAddress;
                    getcollegeLeadership.CouncilMemberSponsor = collegeLeadership.CouncilMemberSponsor;
                    getcollegeLeadership.DateAppointed = collegeLeadership.DateAppointed;
                    getcollegeLeadership.DateLeft = collegeLeadership.DateLeft;
                    getcollegeLeadership.DateOfBirth = collegeLeadership.DateOfBirth;
                    getcollegeLeadership.Gender = collegeLeadership.Gender;
                    getcollegeLeadership.CouncilMember = collegeLeadership.CouncilMember;
                    getcollegeLeadership.SessionName = session.Name;
                    getcollegeLeadership.Name = collegeLeadership.Name;
                    getcollegeLeadership.Role = collegeLeadership.Role;
                    getcollegeLeadership.Session =Convert.ToInt32( collegeLeadership.Session);
                    getcollegeLeadership.IsActive = true;
                    getcollegeLeadership.IsDeleted = false;
                    getcollegeLeadership.CreatedBy = collegeLeadership.CreatedBy;
                    getcollegeLeadership.DateCreated = collegeLeadership.DateCreated;
                    getcollegeLeadership.DateUpdated = DateTime.Now;

                    _collegeleadershiprepo.Update(getcollegeLeadership);

                    transaction.Complete();

                    resp = new ResponseData<CollegeLeadershipViewModel>
                    {
                        Message = "CollegeLeadership Updated successfully",
                        RespCode = "00",
                        IsSuccessful = true
                    };

                    return resp;
                }
                catch (Exception ex)
                {
                    return new ResponseData<CollegeLeadershipViewModel>
                    {
                        Message = "Operation failed",
                        RespCode = "04",
                        IsSuccessful = false
                    };
                }
            }
        }
        public CollegeLeadership GetCollegeLeadershipById(long Id)
        {
            var collegeLeadership = _collegeleadershiprepo.Find(Id);
            if (collegeLeadership != null)
            {
                return collegeLeadership;
            }
            return null;
        }
        public ResponseData<CollegeLeadershipViewModel> DeleteCollegeLeadership(long Id, bool LogRequest)
        {
            ResponseData<CollegeLeadershipViewModel> resp;
            using (var transaction = new TransactionScope())
            {
                try
                {
                    var collegeLeadership = _collegeleadershiprepo.Find(Id);
                    collegeLeadership.IsDeleted = true;
                    collegeLeadership.IsActive = false;

                    _collegeleadershiprepo.Update(collegeLeadership);


                    if (LogRequest)
                    {
                        var data = Newtonsoft.Json.JsonConvert.SerializeObject(collegeLeadership);
                        var apiRequestLog = new APIRequestLog
                        {
                            Data = data,
                            RequestType = HTTPRequestType.Put,
                            Synched = false,
                            Url = _configration.GetSection("BaseAPIURl").Value + "facility"
                        };
                        _apiRequestRepo.Create(apiRequestLog);
                    }
                    transaction.Complete();

                    resp = new ResponseData<CollegeLeadershipViewModel>
                    {
                        Message = "CollegeLeadership created successfully",
                        RespCode = "00",
                        IsSuccessful = true
                    };

                    return resp;
                }
                catch (Exception ex)
                {
                    return new ResponseData<CollegeLeadershipViewModel>
                    {
                        Message = "Operation failed",
                        RespCode = "04",
                        IsSuccessful = false
                    };
                }
            }
        }
    }
}
