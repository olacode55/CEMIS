using CEMIS.Data.Entities;
using CEMIS.Utility.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CEMIS.Business.Interface
{
   public interface ICompensationReport
    {
        IEnumerable<CompensationReportViewModel> GetCompensation(string month, string year);

        CompensationReport CheckCompensation(string month, string year);

        void CommitCompensationReport(string month, string year);

    }
}
