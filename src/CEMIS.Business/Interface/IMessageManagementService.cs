using CEMIS.Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CEMIS.Business.Interface
{

    public interface IMessageManagementService
    {
        #region Email Template
        Task<EmailTemplateViewModel> GetEmailTemplate(long id);
        Task<EmailTemplateViewModel> CreateEmailTemplate(EmailTemplateDTO obj);
        Task<bool> UpdateEmailTemplate(EmailTemplateDTO obj, int id);
        Task DeleteEmailTemplate(int id);
        #endregion

  
    }
}


