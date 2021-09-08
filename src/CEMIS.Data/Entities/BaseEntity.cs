using System;
using System.Collections.Generic;
using System.Text;

namespace CEMIS.Data.Entities
{
    public class BaseEntity
    {
        public long Id { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public long CreatedBy { get; set; }
        public long? UpdatedBy{ get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public long CollegeID { get; set; }
        public string API_Key { get; set; }
      
        
    }
}
