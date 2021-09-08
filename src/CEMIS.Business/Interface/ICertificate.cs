using CEMIS.Data.Entities;
using CEMIS.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace CEMIS.Business.Interface
{
  public interface  ICertificate
    {
        List<Certificate> GetAllCertificate();
        ResponseData<Certificate> CreateCertificate(Certificate teachingStaff, bool LogRequest);
        List<Certificate> GetCertificateById(long StaffId);
       // Certificate GetCertificateById(string staffno);

        ResponseData<Certificate> UpdateCertificate(Certificate teachingStaff, bool LogRequest);
        ResponseData<Certificate> DeleteCertificate(long Id);
    }
}
