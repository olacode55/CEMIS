using CEMIS.Business.Interface;
using CEMIS.Data.Entities;
using CEMIS.Utility;
using CEMIS.Utility.ViewModel;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace CEMIS.Business.Repository
{
  public  class CouncilMembersRepository: ICouncilMembers
    {
        private readonly IRepository<CouncilMember> _councilMemberRepo;
        private IRepository<APIRequestLog> _apiRequestRepo;
        private IRepository<CouncilSession> _academicRepo;
        private IConfiguration _configration;
        private readonly IAuthUser _authUser;


        public CouncilMembersRepository(IRepository<CouncilMember> CouncilMemberRepo,  IAuthUser authUser,IRepository<APIRequestLog> apiRequestRepo, IRepository<CouncilSession> academicRepo, IConfiguration configration)
        {
            _councilMemberRepo = CouncilMemberRepo;
            _apiRequestRepo = apiRequestRepo;
            _academicRepo = academicRepo;
            _configration = configration;
            _authUser = authUser;
        }

        public ResponseData<CouncilMemberViewModel> CreateMember(CouncilMemberViewModel member, bool logRequest)
        {
            ResponseData<CouncilMemberViewModel> resp;

            using (var transaction = new TransactionScope())
            {
                try
                {
                    if (string.IsNullOrEmpty(member.councilMemberName))
                    {
                        return new ResponseData<CouncilMemberViewModel>
                        {
                            Message = "Unit cannot be empty",
                            RespCode = "04",
                            IsSuccessful = false
                        };
                    }

                    if (checkNameexist(member.councilMemberName))
                    {
                        return new ResponseData<CouncilMemberViewModel>
                        {
                            Message = "Unit already exist",
                            RespCode = "04",
                            IsSuccessful = false
                        };
                    }
                    var session = _academicRepo.Find(member.sessionId);
                    var councilMember = new CouncilMember
                    {
                        CouncilMemberName = member.councilMemberName,
                        CouncilMemberPosition = member.councilMemberPosition,
                        SessionName = session.Name,
                        SessionId = member.sessionId,
                        IsDeleted = false,
                        IsActive = true,
                        CreatedBy = long.Parse(_authUser.UserId ),
                         DateCreated = DateTime.Now,
                        UpdatedBy = null


                    };


                    if (logRequest)
                    {
                        var data = Newtonsoft.Json.JsonConvert.SerializeObject(member);
                        string url = _configration.GetSection("BaseAPIURl").Value + "Unit";
                        var apiRequestLog = new APIRequestLog
                        {
                            Data = data,
                            RequestType = HTTPRequestType.Post,
                            Synched = false,
                            Url = url
                        };
                        _apiRequestRepo.Create(apiRequestLog);
                    }

                    _councilMemberRepo.Create(councilMember);

                    transaction.Complete();

                    resp = new ResponseData<CouncilMemberViewModel>
                    {
                        Message = "Member created successfully",
                        RespCode = "00",
                        IsSuccessful = true
                    };

                    return resp;
                }
                catch (Exception ex)
                {
                    return new ResponseData<CouncilMemberViewModel>
                    {
                        Message = "Operation failed",
                        RespCode = "04",
                        IsSuccessful = false
                    };


                }
            }

        }

        public bool DeleteMember(long Id, out string message)
        {
            throw new NotImplementedException();
        }

        public List<CouncilMemberViewModel> GetAllMember()
        {
            var fecthdata = new List<CouncilMemberViewModel>();
            var item = _councilMemberRepo.All().Where(m => m.IsDeleted == false && m.IsActive == true).ToList();

            fecthdata = ((from x in item
                          select new CouncilMemberViewModel
                          {
                              Id = x.Id,
                              councilMemberName = x.CouncilMemberName,
                              councilMemberPosition = x.CouncilMemberPosition,
                              sessionName =x.SessionName,
                              sessionId = x.SessionId,
                             
                          }).ToList());

            return fecthdata;
        }

        public bool checkNameexist(string name)
        {
            return _councilMemberRepo.All().Any(slt => slt.CouncilMemberName.Trim().ToLower() == name.Trim().ToLower() && slt.IsActive == true);

        }

        public bool checkUpdateNameexist(CouncilMemberViewModel unit)

        {
            return _councilMemberRepo.All().Any(slt => slt.CouncilMemberName.Trim().ToLower() == unit.councilMemberName.Trim().ToLower() && slt.Id != unit.Id && slt.IsActive == true);

        }
        public CouncilMemberViewModel GetMemberById(long Id)
        {
            var councilMember = _councilMemberRepo.Find(Id);
            if (councilMember != null)
            {
                return new CouncilMemberViewModel
                {
                    councilMemberName = councilMember.CouncilMemberName,
                    councilMemberPosition = councilMember.CouncilMemberPosition,
                    sessionName = councilMember.SessionName,
                    sessionId = councilMember.SessionId,
                };
            }
            return null;
        }

        public ResponseData<CouncilMemberViewModel> UpdateMember(CouncilMemberViewModel member, bool logRequest)
        {
            ResponseData<CouncilMemberViewModel> resp;

            using (var transaction = new TransactionScope())
            {
                try
                {
                    if (checkUpdateNameexist(member))
                    {
                        return new ResponseData<CouncilMemberViewModel>
                        {
                            Message = "Unit already exist",
                            RespCode = "04",
                            IsSuccessful = false
                        };
                    }

                    if (logRequest)
                    {
                        var data = Newtonsoft.Json.JsonConvert.SerializeObject(member);
                        string url = _configration.GetSection("BaseAPIURl").Value + "Unit";
                        var apiRequestLog = new APIRequestLog
                        {
                            Data = data,
                            RequestType = HTTPRequestType.Put,
                            Synched = false,
                            Url = url
                        };
                        _apiRequestRepo.Create(apiRequestLog);
                    }

                    var councilMember = _councilMemberRepo.Find(member.Id);

                    councilMember.CouncilMemberName = member.councilMemberName;
                    councilMember.CouncilMemberPosition = member.councilMemberPosition;
                    councilMember.SessionName = member.sessionName;
                    councilMember.IsActive = true;
                    councilMember.IsDeleted = false;
                    councilMember.CreatedBy = long.Parse(_authUser.UserId);
                    councilMember.UpdatedBy = long.Parse(_authUser.UserId);
                    councilMember.SessionId = member.sessionId;

           
                    councilMember.DateUpdated = DateTime.Now;

                    _councilMemberRepo.Update(councilMember);

                    transaction.Complete();



                    resp = new ResponseData<CouncilMemberViewModel>
                    {
                        Message = "Unit Updated successfully",
                        RespCode = "00",
                        IsSuccessful = true
                    };

                    return resp;
                }
                catch (Exception ex)
                {
                    return new ResponseData<CouncilMemberViewModel>
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
