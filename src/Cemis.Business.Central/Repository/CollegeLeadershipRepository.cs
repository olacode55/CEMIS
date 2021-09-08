using System;
using System.Collections.Generic;
using System.Text;
using CEMIS.Data.Central;
using CEMIS.Business.Central.Interface;
using Microsoft.Extensions.Configuration;
using CEMIS.Utility;
using System.Linq;
using CEMIS.Utility.ViewModel;
using Cemis.Data.Central.Entities;

namespace CEMIS.Business.Central.Repository
{
    public class CollegeLeadershipRepository : ICollegeLeadership
    {
        private IRepository<CollegeLeadership> _collegeLeadershipRepo;
        private IRepository<TeachingStaffAdminRole> _teachingStaffAdminRole;
        private IRepository<CouncilMember> _councilMemberRepo;
        private IRepository<CouncilSession> _councilSessionRepo;
        private IRepository<CommitteeMembers> _committeMemberRepo;
        private IRepository<Commitee> _commiteeRepo;
        private IConfiguration _configration;

        public CollegeLeadershipRepository(IRepository<CollegeLeadership> collegeLeadershipRepo, IConfiguration configration, IRepository<TeachingStaffAdminRole> teachingStaffAdminRole,
                                           IRepository<CouncilMember> councilMemberRepo, IRepository<CouncilSession> councilSessionRepo , IRepository<Commitee> commiteeRepo,
                                           IRepository<CommitteeMembers> committeMemberRepo)
        {
            _collegeLeadershipRepo = collegeLeadershipRepo;
            _configration = configration;
            _teachingStaffAdminRole = teachingStaffAdminRole;
            _committeMemberRepo = committeMemberRepo;
            _councilMemberRepo = councilMemberRepo;
            _councilSessionRepo = councilSessionRepo;
            _commiteeRepo = commiteeRepo;

        }

        public ResponseData<CouncilMember> PushCollegeCouncilMembers(CouncilMemberViewModel councilMemberVM, long collegeID)
        {
            ResponseData<CouncilMember> resp;
            try
            {

                var memberExist = _councilMemberRepo.All().FirstOrDefault(x => x.SourceID == councilMemberVM.Id && x.CollegeID == collegeID);
                if (memberExist == null)
                {
                    var councilMember = new CouncilMember
                    {
                        CollegeID = collegeID,
                        CreatedBy = councilMemberVM.CreatedBy,
                        DateCreated = councilMemberVM.DateCreated,
                        DateFetched = DateTime.Now,
                        DateUpdated = councilMemberVM.DateUpdated,
                        SourceID = councilMemberVM.Id,
                        IsActive = councilMemberVM.IsActive,
                        IsDeleted = councilMemberVM.IsDeleted,
                        UpdatedBy = councilMemberVM.UpdatedBy,
                        CouncilMemberName = councilMemberVM.councilMemberName,
                        CouncilMemberPosition = councilMemberVM.councilMemberPosition,
                        SessionName = councilMemberVM.sessionName,
                        SessionSourceId = councilMemberVM.sessionId

                    };

                    _councilMemberRepo.Create(councilMember);

                    resp = new ResponseData<CouncilMember>
                    {
                        Message = "Member created successfully",
                        RespCode = "00",
                        IsSuccessful = true
                    };

                    return resp;
                }



                memberExist.DateUpdated = councilMemberVM.DateUpdated;
                memberExist.IsActive = councilMemberVM.IsActive;
                memberExist.IsDeleted = councilMemberVM.IsDeleted;
                memberExist.UpdatedBy = councilMemberVM.UpdatedBy;
                memberExist.CouncilMemberName = councilMemberVM.councilMemberName;
                memberExist.CouncilMemberPosition = councilMemberVM.councilMemberPosition;
                memberExist.SessionName = councilMemberVM.sessionName;
                memberExist.SessionSourceId = councilMemberVM.sessionId;

                _councilMemberRepo.Update(memberExist);

                resp = new ResponseData<CouncilMember>
                {
                    Message = "Memeber updated successfully",
                    RespCode = "00",
                    IsSuccessful = true
                };

                return resp;

            }
            catch (Exception ex)
            {
                ErrorLogManager.Error(ex);
                return new ResponseData<CouncilMember>
                {
                    Message = "Operation failed",
                    RespCode = "04",
                    IsSuccessful = false
                };
            }
        }

        public ResponseData<CollegeLeadership> PushCollegeLeadership(CollegeLeadershipViewModel collegeLeadershipVM, long collegeID)
        {
            ResponseData<CollegeLeadership> resp;
            var staffDetails = _collegeLeadershipRepo.All().FirstOrDefault(x => x.SourceID == collegeLeadershipVM.Id && x.CollegeID == collegeID);
            //var role = _teachingStaffAdminRole.All().FirstOrDefault(x => x.Code == collegeLeadershipVM.RoleCode);

            //long roleID = role == null ? 0 : role.Id;
            try
            {
                if (staffDetails == null)
                {

                    var collegeLeadership = new CollegeLeadership
                    {
                        CollegeID = collegeID,
                        SourceID = collegeLeadershipVM.Id,
                        CouncilMember = collegeLeadershipVM.CouncilMember,
                        CouncilMemberEmail = collegeLeadershipVM.CouncilMemberEmail,
                        CouncilMemberPhone1 = collegeLeadershipVM.CouncilMemberPhone1,
                        CouncilMemberPhone2 = collegeLeadershipVM.CouncilMemberPhone2,
                        CouncilMemberPostalAddress = collegeLeadershipVM.CouncilMemberPostalAddress,

                        CouncilMemberSponsor = collegeLeadershipVM.CouncilMemberSponsor,
                        CreatedBy = collegeLeadershipVM.CreatedBy,
                        DateCreated = collegeLeadershipVM.DateCreated,
                        DateAppointed = collegeLeadershipVM.DateAppointed,
                        DateLeft = collegeLeadershipVM.DateLeft,
                        DateOfBirth = collegeLeadershipVM.DateOfBirth,
                        DateUpdated = collegeLeadershipVM.DateUpdated,
                        UpdatedBy = collegeLeadershipVM.UpdatedBy,
                        Gender = collegeLeadershipVM.Gender,
                        Name = collegeLeadershipVM.Name,
                        Role = collegeLeadershipVM.Role,
                        IsActive = collegeLeadershipVM.IsActive,
                        IsDeleted = collegeLeadershipVM.IsDeleted,
                        SessionName = collegeLeadershipVM.SessionName,
                        SessionSourceID = collegeLeadershipVM.SessionId,
                        DateFetched = DateTime.Now
                        

                    };

                    _collegeLeadershipRepo.Create(collegeLeadership);

                    resp = new ResponseData<CollegeLeadership>
                    {
                        Message = "Data created successfully",
                        RespCode = "00",
                        IsSuccessful = true
                    };

                    return resp;
                }
                staffDetails.CouncilMember = collegeLeadershipVM.CouncilMember;
                staffDetails.CouncilMemberEmail = collegeLeadershipVM.CouncilMemberEmail;
                staffDetails.CouncilMemberPhone1 = collegeLeadershipVM.CouncilMemberPhone1;
                staffDetails.CouncilMemberPhone2 = collegeLeadershipVM.CouncilMemberPhone2;
                staffDetails.CouncilMemberPostalAddress = collegeLeadershipVM.CouncilMemberPostalAddress;
                staffDetails.CouncilMemberSponsor = collegeLeadershipVM.CouncilMemberSponsor;
                staffDetails.DateAppointed = collegeLeadershipVM.DateAppointed;
                staffDetails.DateLeft = collegeLeadershipVM.DateLeft;
                staffDetails.DateOfBirth = collegeLeadershipVM.DateOfBirth;
                staffDetails.DateUpdated = collegeLeadershipVM.DateUpdated;
                staffDetails.Gender = collegeLeadershipVM.Gender;
                staffDetails.IsActive = collegeLeadershipVM.IsActive;
                staffDetails.IsDeleted = collegeLeadershipVM.IsDeleted;
                staffDetails.Name = collegeLeadershipVM.Name;
                staffDetails.Role = collegeLeadershipVM.Role;
                staffDetails.SessionName = collegeLeadershipVM.SessionName;
                staffDetails.SessionSourceID = collegeLeadershipVM.SessionId;
                staffDetails.DateFetched = DateTime.Now;


                _collegeLeadershipRepo.Update(staffDetails);

                resp = new ResponseData<CollegeLeadership>
                {
                    Message = "Data Updated successfully",
                    RespCode = "00",
                    IsSuccessful = true
                };
                return resp;

            }
            catch (Exception ex)
            {
                ErrorLogManager.Error(ex);
                return new ResponseData<CollegeLeadership>
                {
                    Message = "Operation failed",
                    RespCode = "04",
                    IsSuccessful = false
                };
            }

        }

        public ResponseData<CommitteMemberViewModel> PushComiteeMembers(CommitteMemberViewModel committeeMemberVM, long collegeID)
        {

            ResponseData<CommitteMemberViewModel> resp;
            var committeMemberDetails = _committeMemberRepo.All().FirstOrDefault(x => x.SourceID == committeeMemberVM.Id && x.CollegeID == collegeID);
            try
            {
                if (committeMemberDetails == null)
                {

                    var committeMember = new CommitteeMembers
                    {
                        CommitteMemberName = committeeMemberVM.committeMemberName,
                        CommitteMemberPosition = committeeMemberVM.committeMemberPosition,
                        CollegeID = collegeID,
                        CommitteName = committeeMemberVM.committeName,
                        CommitteSourceId = committeeMemberVM.committeId,
                        SourceID = committeeMemberVM.Id,
                        SessionName = committeeMemberVM.sessionName,
                        SessionSourceId = committeeMemberVM.sessionId,
                        CreatedBy = committeeMemberVM.CreatedBy,
                        DateCreated = committeeMemberVM.DateCreated,
                        DateFetched = DateTime.Now,
                        DateUpdated = committeeMemberVM.DateUpdated,
                        IsActive = committeeMemberVM.IsActive,
                        IsDeleted = committeeMemberVM.IsDeleted,
                        UpdatedBy = committeeMemberVM.UpdatedBy,
                    };
                    _committeMemberRepo.Create(committeMember);

                    resp = new ResponseData<CommitteMemberViewModel>
                    {
                        Message = "Data created successfully",
                        RespCode = "00",
                        IsSuccessful = true
                    };

                    return resp;
                }

                committeMemberDetails.CommitteMemberName = committeeMemberVM.committeMemberName;
                committeMemberDetails.CommitteMemberPosition = committeeMemberVM.committeMemberPosition;
                committeMemberDetails.CollegeID = collegeID;
                committeMemberDetails.CommitteName = committeeMemberVM.committeName;
                committeMemberDetails.CommitteSourceId = committeeMemberVM.committeId;
                committeMemberDetails.SourceID = committeeMemberVM.Id;
                committeMemberDetails.SessionName = committeeMemberVM.sessionName;
                committeMemberDetails.SessionSourceId = committeeMemberVM.sessionId;
                

                _committeMemberRepo.Update(committeMemberDetails);

                resp = new ResponseData<CommitteMemberViewModel>
                {
                    Message = "Data Updated successfully",
                    RespCode = "00",
                    IsSuccessful = true
                };
                return resp;

            }
            catch (Exception ex)
            {
                ErrorLogManager.Error(ex);
                return new ResponseData<CommitteMemberViewModel>
                {
                    Message = "Operation failed",
                    RespCode = "04",
                    IsSuccessful = false
                };
            }
        }

        
        public ResponseData<CommitteViewModel> PushCommitee(CommitteViewModel CommiteeVM, long collegeID)
        {
            
             ResponseData<CommitteViewModel> resp;
            var commiteeDetail = _commiteeRepo.All().FirstOrDefault(x => x.SourceID == CommiteeVM.Id && x.CollegeID == collegeID);
            try
            {
                if (commiteeDetail == null)
                {
                    var commitee = new Commitee
                    {
                        CollegeID = collegeID,
                        SourceID = CommiteeVM.Id,
                        CreatedBy = CommiteeVM.CreatedBy,
                        DateCreated = CommiteeVM.DateCreated,
                        DateFetched = DateTime.Now,
                        DateUpdated = CommiteeVM.DateUpdated,
                        Name = CommiteeVM.name,
                        IsActive = CommiteeVM.IsActive,
                        IsDeleted = CommiteeVM.IsDeleted,
                        UpdatedBy = CommiteeVM.UpdatedBy
                    };
                    _commiteeRepo.Create(commitee);

                    resp = new ResponseData<CommitteViewModel>
                    {
                        Message = "Data created successfully",
                        RespCode = "00",
                        IsSuccessful = true
                    };

                    return resp;
                }

                commiteeDetail.Name = CommiteeVM.name;
                commiteeDetail.IsActive = CommiteeVM.IsActive;
                commiteeDetail.IsDeleted = CommiteeVM.IsDeleted;
                commiteeDetail.UpdatedBy = CommiteeVM.UpdatedBy;
                // CouncilDetail.DateUpdateFetched = DateTime.Now;

                _commiteeRepo.Update(commiteeDetail);

                resp = new ResponseData<CommitteViewModel>
                {
                    Message = "Data Updated successfully",
                    RespCode = "00",
                    IsSuccessful = true
                };
                return resp;
            }
            catch (Exception ex)
            {
                ErrorLogManager.Error(ex);
                return new ResponseData<CommitteViewModel>
                {
                    Message = "Operation failed",
                    RespCode = "04",
                    IsSuccessful = false
                };
            }
        }


        public ResponseData<CouncilSessionViewModel> PushCouncilSession(CouncilSessionViewModel councilSessionVM, long collegeID)
        {
            ResponseData<CouncilSessionViewModel> resp;
            var CouncilDetail = _councilSessionRepo.All().FirstOrDefault(x => x.SourceID == councilSessionVM.Id && x.CollegeID == collegeID);
            try
            {
                if (CouncilDetail == null)
                {
                    var councilSession = new CouncilSession
                    {
                        CollegeID = collegeID,
                        SourceID = councilSessionVM.Id,
                        CreatedBy = councilSessionVM.CreatedBy,
                        DateCreated = councilSessionVM.DateCreated,
                        DateFetched = DateTime.Now,
                        DateUpdated = councilSessionVM.DateUpdated,
                        endDate = councilSessionVM.endDate,
                        startDate = councilSessionVM.startDate,
                        Name = councilSessionVM.name,
                        IsActive = councilSessionVM.IsActiveSyn,
                        IsDeleted = councilSessionVM.IsDeleted,
                        UpdatedBy = councilSessionVM.UpdatedBy
                    };
                    _councilSessionRepo.Create(councilSession);

                    resp = new ResponseData<CouncilSessionViewModel>
                    {
                        Message = "Data created successfully",
                        RespCode = "00",
                        IsSuccessful = true
                    };

                    return resp;
                }

                CouncilDetail.DateUpdated = councilSessionVM.DateUpdated;
                CouncilDetail.endDate = councilSessionVM.endDate;
                CouncilDetail.startDate = councilSessionVM.startDate;
                CouncilDetail.Name = councilSessionVM.name;
                CouncilDetail.IsActive = councilSessionVM.IsActiveSyn;
                CouncilDetail.IsDeleted = councilSessionVM.IsDeleted;
                CouncilDetail.UpdatedBy = councilSessionVM.UpdatedBy;
               // CouncilDetail.DateUpdateFetched = DateTime.Now;

                _councilSessionRepo.Update(CouncilDetail);

                resp = new ResponseData<CouncilSessionViewModel>
                {
                    Message = "Data Updated successfully",
                    RespCode = "00",
                    IsSuccessful = true
                };
                return resp;

            }
            catch (Exception ex)
            {
                ErrorLogManager.Error(ex);
                return new ResponseData<CouncilSessionViewModel>
                {
                    Message = "Operation failed",
                    RespCode = "04",
                    IsSuccessful = false
                };
            }
        }

    }
}

