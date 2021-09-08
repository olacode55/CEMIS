using CEMIS.Business.Interface;
using CEMIS.Data.Entities;
using CEMIS.Utility;
using CEMIS.Utility.ViewModel;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

namespace CEMIS.Business.Repository
{
   public class CommitteRepository : ICommittee
    {
        private readonly IRepository<Committee> _CommitteRepo;
        private readonly IAuthUser _authUser;
        private readonly IRepository<APIRequestLog> _apiRequestRepo;
        private readonly IConfiguration _configration;
        public CommitteRepository(IRepository<Committee> CommitteRepo, IAuthUser authUser, IRepository<APIRequestLog> apiRequestRepo, IConfiguration configration)
        {

            _CommitteRepo = CommitteRepo;
            _authUser = authUser;
            _apiRequestRepo = apiRequestRepo;
            _configration = configration;

        }

        public ResponseData<CommitteViewModel> CreateCommitte(CommitteViewModel committe, bool logRequest)
        {
            ResponseData<CommitteViewModel> resp;

            using (var transaction = new TransactionScope())
            {
                try
                {
                    if (string.IsNullOrEmpty(committe.name))
                    {
                        return new ResponseData<CommitteViewModel>
                        {
                            Message = "Committe cannot be empty",
                            RespCode = "04",
                            IsSuccessful = false
                        };
                    }
                    var Committees = new Committee
                    {
                        Name = committe.name,
                      
                        IsDeleted = false,
                        IsActive = true,
                        CreatedBy = long.Parse(_authUser.UserId),
                        DateCreated = DateTime.Now,
                        UpdatedBy = null


                    };


                    if (logRequest)
                    {
                        var data = Newtonsoft.Json.JsonConvert.SerializeObject(committe);
                        string url = _configration.GetSection("BaseAPIURl").Value + "Committe";
                        var apiRequestLog = new APIRequestLog
                        {
                            Data = data,
                            RequestType = HTTPRequestType.Post,
                            Synched = false,
                            Url = url
                        };
                        _apiRequestRepo.Create(apiRequestLog);
                    }

                    _CommitteRepo.Create(Committees);

                    transaction.Complete();

                    resp = new ResponseData<CommitteViewModel>
                    {
                        Message = "Committee created successfully",
                        RespCode = "00",
                        IsSuccessful = true
                    };

                    return resp;
                }
                catch (Exception ex)
                {
                    return new ResponseData<CommitteViewModel>
                    {
                        Message = "Operation failed",
                        RespCode = "04",
                        IsSuccessful = false
                    };


                }
            }
        }

        public bool DeleteCommitte(long Id)
        {
            try
            {
                var commitee = _CommitteRepo.Find(Id);
                if (commitee != null)
                {
                    commitee.IsDeleted = true;
                    commitee.IsActive = false;
                    _CommitteRepo.Update(commitee);
                    return true;
                }
                else
                {
                    return false;

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<CommitteViewModel> GetAllCommitte()
        {
            var fecthdata = new List<CommitteViewModel>();
            var item = _CommitteRepo.All().Where(m => m.IsDeleted == false && m.IsActive == true).ToList();

            fecthdata = ((from x in item
                          select new CommitteViewModel
                          {
                              Id = x.Id,
                              name = x.Name,
                          }).ToList());

            return fecthdata;
        }
        public CommitteViewModel GetCommitteById(long Id)
        {
            var Committe = _CommitteRepo.Find(Id);
            if (Committe != null)
            {
                return new CommitteViewModel
                {
                    name = Committe.Name,
                };
            }
            return null;
        }

        public Committee GetCommitteId(string name)
        {
            var fecthdata = _CommitteRepo.Filter(x => x.Name.ToLower().Trim() == name.ToLower().Trim()).FirstOrDefault();
            return fecthdata;
        }

        public ResponseData<CommitteViewModel> UpdateCommitte(CommitteViewModel committe, bool logRequest)
        {
            ResponseData<CommitteViewModel> resp;

            using (var transaction = new TransactionScope())
            {
                try
                {
                    if (logRequest)
                    {
                        var data = Newtonsoft.Json.JsonConvert.SerializeObject(committe);
                        string url = _configration.GetSection("BaseAPIURl").Value + "committe";
                        var apiRequestLog = new APIRequestLog
                        {
                            Data = data,
                            RequestType = HTTPRequestType.Put,
                            Synched = false,
                            Url = url
                        };
                        _apiRequestRepo.Create(apiRequestLog);
                    }

                    var Committes = _CommitteRepo.Find(committe.Id);

                    Committes.Name = committe.name;  
                    Committes.IsActive = true;
                    Committes.IsDeleted = false;
                    Committes.CreatedBy = long.Parse(_authUser.UserId);
                    Committes.UpdatedBy = long.Parse(_authUser.UserId);
                    Committes.DateUpdated = DateTime.Now;

                    _CommitteRepo.Update(Committes);

                    transaction.Complete();



                    resp = new ResponseData<CommitteViewModel>
                    {
                        Message = "Allowace Updated successfully",
                        RespCode = "00",
                        IsSuccessful = true
                    };

                    return resp;
                }
                catch (Exception ex)
                {
                    return new ResponseData<CommitteViewModel>
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
