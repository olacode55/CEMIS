using CEMIS.Business.Interface;
using CEMIS.Data;
using CEMIS.Data.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using CEMIS.Utility;
using CEMIS.Utility.ViewModel;
using CEMIS.Business.Model;
using System.Data.SqlClient;

namespace CEMIS.Business.Repository
{
    public class SessionRepository : ISession
    {
       
        private IRepository<Session> _sessionRepo;
        private IRepository<CouncilMember> _sessionRepoMember;
        private readonly IConfiguration _configration;
        private readonly appContext _context;

        public SessionRepository(IRepository<Session> sessionRepo, IRepository<CouncilMember> sessionRepoMem, IConfiguration configration)
        {
            _sessionRepo = sessionRepo;
            _sessionRepoMember = sessionRepoMem;
            _configration = configration;

        }
        public int AddSession(SessionViewModel council)
        {
            try
            {

                Session _cnsession = new Session();
                _cnsession.SessionName = council.SessionName.ToString();
                _cnsession.StartDate = council.StartDate;
                _cnsession.EndDate = council.EndDate;
                _cnsession.MembershipName = council.MembershipName;
                _cnsession.PositionName = council.MembershipPosition;
                _cnsession.IsActive = true;
                _sessionRepo.Create(_cnsession);
                return 1;
            }
            catch (Exception ex)
            {

                ErrorLogManager.Error(ex);
            }
            return 0;
        }

        public Session GetAllexist(string model)
        {
            Session sessionlog = _sessionRepo.Find(mm => mm.SessionName == model);

            return sessionlog;
        }

        public List<Session> GetAllSession()
        {
            try
            {
                List<Session> sessionlog = _sessionRepo.All().ToList();

                if (sessionlog != null)
                {
                    return sessionlog.ToList();
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {

                ErrorLogManager.Error(ex);
            }
            return null;
        }


        public Session GetSessionById(long Id)
        {
            try
            {

                Session _sessionquery = _sessionRepo.Find(nn => nn.Id == Id);
                if (_sessionquery != null)
                {
                    SessionViewModel model = new SessionViewModel();
                    model.SessionName = _sessionquery.SessionName;
                    model.StartDate = _sessionquery.StartDate;
                    model.EndDate = _sessionquery.EndDate;
                    model.MembershipName = _sessionquery.MembershipName;
                    model.MembershipPosition = _sessionquery.PositionName;
                    return _sessionquery;
                }
            }
            catch (Exception ex)
            {

                ErrorLogManager.Error(ex);
            }
            return null;
        }

        public int UpdateSession(SessionViewModel Session)
        {
            try
            {
                int retVal = 1;
                var _queryId = _sessionRepo.Find(nn => nn.Id == Session.Id);
                if (_queryId != null)
                {
                    Session _session = new Session();
                    Session.SessionName = _queryId.SessionName.ToString();
                    Session.StartDate = _queryId.StartDate;
                    Session.EndDate = _queryId.EndDate;
                    Session.MembershipName = _queryId.MembershipName;
                    Session.MembershipPosition = _queryId.PositionName;
                    _sessionRepo.Update(_queryId);
                    if (_queryId.Id > 0)
                    {
                        return retVal;
                    }
                }
            }
            catch (Exception ex)
            {

                ErrorLogManager.Error(ex);
            }

            return 0;
        }
        public Session UpdateentityId(long Id)
        {
            Session cns = _sessionRepo.Find(nn => nn.Id == Id);

            cns.IsActive = false;
            _sessionRepo.Update(cns);
            return cns;
        }
        public bool Checkactivesession()
        {
            var cns = _sessionRepo.All().Where(nn => nn.IsActive == true).Any();
            if (cns == true)
            {
                return true;
            }

            return false;
        }

        public int AddMemberInSession(SessionViewModel model)
        {
            try
            {
                CouncilMember _cnsessionModel = new CouncilMember();
                _cnsessionModel.SessionName = model.SessionName.ToString();
                _cnsessionModel.CouncilMemberName = model.MembershipName.ToString();
                _cnsessionModel.CouncilMemberPosition = model.MembershipPosition;
                _cnsessionModel.IsActive = true;
                _sessionRepoMember.Create(_cnsessionModel);
                return 1;
            }
            catch (Exception ex)
            {

                ErrorLogManager.Error(ex);
            }
            return 0;
        }



        public List<CouncilMember> GetAllCoucilMember()
        {
            try
            {
                var model = _sessionRepoMember.All().ToList();
                if (model != null)
                {
                    return model;
                }


            }
            catch (Exception)
            {

                throw;
            }
            return null;
        }
        public CouncilMember GetCouncilMemberbyId(long Id)
        {
            try
            {
                var getMemberId = _sessionRepoMember.Find(nn => nn.Id == Id);
                if (getMemberId != null)
                {
                    return getMemberId;
                }

            }
            catch (Exception)
            {

                throw;
            }

            return null;
        }

        public int UpdateCoucilMember(SessionViewModel mod)
        {
            try
            {

                var _getmemberid = _sessionRepoMember.Find(nn => nn.Id == mod.Id);
                if (_getmemberid != null)
                {
                    _getmemberid.SessionName = mod.SessionName.ToString();
                    _getmemberid.CouncilMemberName = mod.MembershipName.ToString();
                    _getmemberid.IsActive = true;
                    _getmemberid.CouncilMemberPosition = mod.MembershipPosition;
                    _sessionRepoMember.Update(_getmemberid);
                    return 1;
                }
            }
            catch (Exception)
            {

                throw;
            }

            return 0;
        }

        public CouncilMember GetExistMember(string log)
        {
            try
            {
                CouncilMember mem = _sessionRepoMember.Find(log);
                if (mem != null)
                {
                    return mem;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return null;
        }

        public List<SessionViewModel> Getcouncilmem()
        {
            try
            {


                var query = _sessionRepo.All().Select(n =>
                new SessionViewModel()
                {
                    Id = n.Id,
                    SessionName = n.SessionName
                });

            }
            catch (Exception)
            {

                throw;
            }
            return null;
        }
    }
}
