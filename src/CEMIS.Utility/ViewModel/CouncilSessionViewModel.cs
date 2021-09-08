using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CEMIS.Utility.ViewModel
{
    public class CouncilSessionViewModel
    {
        public CouncilSessionViewModel()
        {
            this.startDate = DateTime.Today;
            this.endDate = DateTime.Today;

        }

        public long Id { get; set; }

        [Required(ErrorMessage = "Name is required"), MaxLength(50)]
        public string name { get; set; }
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Start Date is required")]
        public DateTime startDate { get; set; }
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "End Date is required")]
        public DateTime endDate { get; set; }
        public string IsActive { get; set; }
        public bool IsActiveSyn { get; set; }
        public bool IsSynched { get; set; }
        public bool IsDeleted { get; set; }
        public long CreatedBy { get; set; }
        public long? UpdatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
    }
}
