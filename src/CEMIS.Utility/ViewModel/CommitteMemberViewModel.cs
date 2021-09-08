using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace CEMIS.Utility.ViewModel
{
  public  class CommitteMemberViewModel
    {
        public CommitteMemberViewModel()
        {
            sessionNames = new List<SelectListItem>();
            CommitteNames = new List<SelectListItem>();
        }
        public long Id { get; set; }
        public string sessionName { get; set; }

        public string committeMemberName { get; set; }
        public string committeName { get; set; }
        public Postion committeMemberPosition { get; set; }
        public long sessionId { get; set; }
        public long committeId { get; set; }
        public List<SelectListItem> sessionNames { get; set; }
        public List<SelectListItem> CommitteNames { get; set; }
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
