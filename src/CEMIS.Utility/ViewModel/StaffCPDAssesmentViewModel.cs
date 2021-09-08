using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CEMIS.Utility.ViewModel
{
    public class StaffCPDAssesmentViewModel
    {
        public long Id { get; set; }
        public IFormFile File { get; set; }
        public Int64 StaffId { get; set; }
        public string Filename { get; set; }
        public string Fullname { get; set; }
        public long SessionId { get; set; }

        public string Session { get; set; }
        public CPDFORMTYPE FormType { get; set; }
        public Semester Semester { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public StaffCPDAssesmentViewModel()
        {
            this.Date = DateTime.Now.Date;
        }
    }
}
