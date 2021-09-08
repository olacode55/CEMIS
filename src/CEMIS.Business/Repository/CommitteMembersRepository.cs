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
  public  class CommitteMembersRepository : ICommitteMembers
    {
        private readonly IRepository<CommitteMembers> _committememberRepo;
        private IRepository<APIRequestLog> _apiRequestRepo;
        private IRepository<CouncilSession> _councilSessionRepo;
        private IConfiguration _configration;
        private readonly IRepository<Committee> _committeRepo;
        private readonly IAuthUser _authUser;


        public CommitteMembersRepository(IRepository<CommitteMembers> committememberRepo,  IAuthUser authUser,IRepository<APIRequestLog> apiRequestRepo, IRepository<CouncilSession> councilSessionRepo,
            IRepository<Committee> committeRepo, IConfiguration configration)
        {
            _committememberRepo = committememberRepo;
            _apiRequestRepo = apiRequestRepo;
            _councilSessionRepo = councilSessionRepo;
            _configration = configration;
            _committeRepo = committeRepo;
            _authUser = authUser;
        }

        public ResponseData<CommitteMemberViewModel> CreateCommitteMember(CommitteMemberViewModel committeMember, bool logRequest)
        {
            ResponseData<CommitteMemberViewModel> resp;

            using (var transaction = new TransactionScope())
            {
                try
                {
                    if (string.IsNullOrEmpty(committeMember.committeMemberName))
                    {
                        return new ResponseData<CommitteMemberViewModel>
                        {
                            Message = "Committe cannot be empty",
                            RespCode = "04",
                            IsSuccessful = false
                        };
                    }

                    if (checkNameexist(committeMember.committeMemberName))
                    {
                        return new ResponseData<CommitteMemberViewModel>
                        {
                            Message = "Unit already exist",
                            RespCode = "04",
                            IsSuccessful = false
                        };
                    }
                    var session = _councilSessionRepo.Find(committeMember.sessionId);
                    var committee = _committeRepo.Find(committeMember.committeId);
                    var committeMembers = new CommitteMembers
                    {
                        CommitteMemberName = committeMember.committeMemberName,
                        CommitteMemberPosition = committeMember.committeMemberPosition,
                        CommitteName = committee.Name,
                        SessionName = session.Name,
                        CommitteId = committeMember.committeId,
                        SessionId = committeMember.sessionId,
                        IsDeleted = false,
                        IsActive = true,
                        CreatedBy = long.Parse(_authUser.UserId ),
                        DateCreated = DateTime.Now,
                        UpdatedBy = null


                    };


                    if (logRequest)
                    {
                        var data = Newtonsoft.Json.JsonConvert.SerializeObject(committeMember);
                        string url = _configration.GetSection("BaseAPIURl").Value + "committe";
                        var apiRequestLog = new APIRequestLog
                        {
                            Data = data,
                            RequestType = HTTPRequestType.Post,
                            Synched = false,
                            Url = url
                        };
                        _apiRequestRepo.Create(apiRequestLog);
                    }

                    _committememberRepo.Create(committeMembers);

                    transaction.Complete();

                    resp = new ResponseData<CommitteMemberViewModel>
                    {
                        Message = "Member created successfully",
                        RespCode = "00",
                        IsSuccessful = true
                    };

                    return resp;
                }
                catch (Exception ex)
                {
                    return new ResponseData<CommitteMemberViewModel>
                    {
                        Message = "Operation failed",
                        RespCode = "04",
                        IsSuccessful = false
                    };


                }
            }

        }

        public bool DeleteCommitteMember(long Id, out string message)
        {
            throw new NotImplementedException();
        }

        public List<CommitteMemberViewModel> GetAllCommitteMember()
        {
            var fecthdata = new List<CommitteMemberViewModel>();
            var item = _committememberRepo.All().Where(m => m.IsDeleted == false && m.IsActive == true).ToList();

            fecthdata = ((from x in item
                          select new CommitteMemberViewModel
                          {
                              Id = x.Id,
                              committeMemberName = x.CommitteMemberName,
                              committeMemberPosition = x.CommitteMemberPosition,
                              committeName = x.CommitteName,
                              committeId = x.CommitteId,
                              sessionName =x.SessionName,
                              sessionId = x.SessionId,
                             
                          }).ToList());

            return fecthdata;
        }

        public bool checkNameexist(string name)
        {
            return _committememberRepo.All().Any(slt => slt.CommitteMemberName.Trim().ToLower() == name.Trim().ToLower() && slt.IsActive == true);

        }

        public bool checkUpdateNameexist(CommitteMemberViewModel memeber)

        {
            return _committememberRepo.All().Any(slt => slt.CommitteMemberName.Trim().ToLower() == memeber.committeMemberName.Trim().ToLower() && slt.Id != memeber.Id && slt.IsActive == true);

        }
        public CommitteMemberViewModel GetCommitteMemberById(long Id)
        {
            var committeMember = _committememberRepo.Find(Id);
            if (committeMember != null)
            {
                return new CommitteMemberViewModel
                {
                    committeMemberName = committeMember.CommitteMemberName,
                    committeMemberPosition = committeMember.CommitteMemberPosition,
                    committeName = committeMember.CommitteName,
                    sessionName = committeMember.SessionName,
                    sessionId = committeMember.SessionId,
                    committeId = committeMember.CommitteId,
                };
            }
            return null;
        }

        public ResponseData<CommitteMemberViewModel> UpdateCommitteMember(CommitteMemberViewModel committeMember, bool logRequest)
        {
            ResponseData<CommitteMemberViewModel> resp;

            using (var transaction = new TransactionScope())
            {
                try
                {
                    if (checkUpdateNameexist(committeMember))
                    {
                        return new ResponseData<CommitteMemberViewModel>
                        {
                            Message = "Committe already exist",
                            RespCode = "04",
                            IsSuccessful = false
                        };
                    }

                    if (logRequest)
                    {
                        var data = Newtonsoft.Json.JsonConvert.SerializeObject(committeMember);
                        string url = _configration.GetSection("BaseAPIURl").Value + "Committe";
                        var apiRequestLog = new APIRequestLog
                        {
                            Data = data,
                            RequestType = HTTPRequestType.Put,
                            Synched = false,
                            Url = url
                        };
                        _apiRequestRepo.Create(apiRequestLog);
                    }

                    var committeMembers = _committememberRepo.Find(committeMember.Id);

                    committeMembers.CommitteMemberName = committeMember.committeMemberName;
                    committeMembers.CommitteMemberPosition = committeMember.committeMemberPosition;
                    committeMembers.SessionName = committeMember.sessionName;
                    committeMembers.CommitteName = committeMember.committeName;
                    committeMembers.IsActive = true;
                    committeMembers.IsDeleted = false;
                    committeMembers.CreatedBy = long.Parse(_authUser.UserId);
                    committeMembers.UpdatedBy = long.Parse(_authUser.UserId);
                    committeMembers.SessionId = committeMember.sessionId;
                    committeMembers.CommitteId = committeMember.committeId;
                    committeMembers.DateUpdated = DateTime.Now;

                    _committememberRepo.Update(committeMembers);

                    transaction.Complete();



                    resp = new ResponseData<CommitteMemberViewModel>
                    {
                        Message = "Unit Updated successfully",
                        RespCode = "00",
                        IsSuccessful = true
                    };

                    return resp;
                }
                catch (Exception ex)
                {
                    return new ResponseData<CommitteMemberViewModel>
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
