using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace CEMIS.Utility.ViewModel
{
  public  class CouncilMemberViewModel
    {
        public CouncilMemberViewModel()
        {
            sessionNames = new List<SelectListItem>();
        }
        public long Id { get; set; }
        public string sessionName { get; set; }

        public string councilMemberName { get; set; }

        public Postion councilMemberPosition { get; set; }
        public long sessionId { get; set; }

        public List<SelectListItem> sessionNames { get; set; }
        public string CollegeName { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public long CreatedBy { get; set; }
        public long? UpdatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public DateTime SessionStartDate { get; set; }
        public DateTime SessionEndDate { get; set; }
        
    }
}
