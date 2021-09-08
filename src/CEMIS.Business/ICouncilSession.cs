using System.Collections.Generic;
using CEMIS.Data;
using CEMIS.Data.Entities;
using CEMIS.Utility;
using CEMIS.Business.Model;
namespace CEMIS.Business
{
    public interface ISession
    {
        int AddSession(SessionViewModel model);
        List<Session> GetAllSession();
        Session GetSessionById(long Id);
        int UpdateSession(SessionViewModel model);
        Session GetAllexist(string model);
        Session UpdateentityId(long Id);
        bool Checkactivesession();
        int AddMemberInSession(SessionViewModel model);
        List<CouncilMember> GetAllCoucilMember();
        CouncilMember GetCouncilMemberbyId(long Id);
        int UpdateCoucilMember(SessionViewModel mod);
        CouncilMember GetExistMember(string log);
        List<SessionViewModel> Getcouncilmem();

    }
}
