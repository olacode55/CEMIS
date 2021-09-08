using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace CEMIS.Utility.ViewModel
{
  public  class CertificateViewModel
    {

        public Int64 Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public Int64 StaffId { get; set; }
        public List<IFormFile> FileUpload { get; set; }
    }
    public class CertificatesViewModel
    {

        public long Id { get; set; }
        public string Name { get; set; }
        //public IFormFile FileUpload { get; set; }
        public string FilePath { get; set; }
    }

  
}
