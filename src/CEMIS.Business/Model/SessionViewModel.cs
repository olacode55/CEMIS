using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using CEMIS.Data.Entities;
using CEMIS.Utility;

namespace CEMIS.Business.Model
{
    public class SessionViewModel
    {
        public long Id { get; set; }
        [Required]
        public string SessionName { get; set; }
        [Required]
        public string StartDate { get; set; }
        [Required]
        public string EndDate { get; set; }
        public long SessionId { get; set; }
        public bool IsActive { get; set; }
        public string MembershipName { get; set; }
        public Postion  MembershipPosition { get; set; }
        public List<Sessionque> Session { get; set; }
        public static SessionViewModel EntityToModels(Session dbmodel)
        {
            return dbmodel == null
                ? null
                : new SessionViewModel
                {
                    Id = dbmodel.Id,
                    SessionName = dbmodel.SessionName,
                    IsActive = dbmodel.IsActive,
                    StartDate = dbmodel.StartDate,
                    EndDate = dbmodel.EndDate,
                    MembershipName = dbmodel.MembershipName,
                    MembershipPosition = dbmodel.PositionName

                };
        }

        public static SessionViewModel EntityToModel(Session dbmodel)
        {
            return dbmodel == null
                ? null
                : new SessionViewModel
                {
                    Id = dbmodel.Id,
                    SessionName = dbmodel.SessionName,


                };
        }

    }

    public class Sessionque
    {
        public long Id { get; set; }
        public string SessionName { get; set; }
        public static Sessionque EntityToModels(Session dbmodel)
        {
            return dbmodel == null
                ? null
                : new Sessionque
                {
                    Id = dbmodel.Id,
                    SessionName = dbmodel.SessionName,


                };
        }

    }
}
