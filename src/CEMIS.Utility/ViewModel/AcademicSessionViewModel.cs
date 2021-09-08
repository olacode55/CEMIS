using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CEMIS.Utility.ViewModel
{
    public class AcademicSessionViewModel
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Academic Period is required"), MaxLength(50)]
        public string AcademicPeriod { get; set; }

        [DataType(DataType.Date)]
        public DateTime FirstSemesterStartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime FirstSemesterEndDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime SecondSemesterStartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime SecondSemesterEndDate { get; set; }

        public string IsActive { get; set; }
        public bool IsActiveSync { get; set; }
        public bool IsDeleted { get; set; }
        public long CreatedBy { get; set; }
        public long? UpdatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }

        public AcademicSessionViewModel()
        {
            this.FirstSemesterStartDate = DateTime.Now.Date;
            this.FirstSemesterEndDate = DateTime.Now.Date;
            this.SecondSemesterStartDate = DateTime.Now.Date;
            this.SecondSemesterEndDate = DateTime.Now.Date;
        }
    }
}
