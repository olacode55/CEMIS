using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace CEMIS.Data.Entities
{
    public class College : ClientBaseEntity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        public DateTime FirstAccreditationDate { get; set; }
        public DateTime CureentAccreditationDate { get; set; }
        public DateTime NextAccreditationDate { get; set; }

        public string PrincipalName { get; set; }

        public string PrincipalEmail { get; set; }

        public string PrincipalPhone { get; set; }

        public string VicePrincipalName { get; set; }

        public string VicePrincipalEmail { get; set; }

        public string VicePrincipalPhone { get; set; }

        public string ICTSystemName { get; set; }

        public string ICTSystemEmail { get; set; }

        public string ICTSystemPhone { get; set; }

        public string AdminOfficerName { get; set; }

        public string AdminOfficerEmail { get; set; }

        public string AdminOfficerPhone { get; set; }

        public string GIS { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string Email { get; set; }

        public long ServiceOfferedId { get; set; }

        public int SecretaryCount { get; set; }

        public int DriversCount { get; set; }

        public int HandymenCount { get; set; }

        public int SecurityGuardCount { get; set; }

        public int CleanerCount { get; set; }
        public bool IsSynched { get; set; }

    }


}
