using CEMIS.Business.Central.Interface;
using CEMIS.Data.Central;
using CEMIS.Data.ViewModel;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEMIS.Business.Central.Services
{
  public  class MessageManagementService : IMessageManagementService
    {
        private readonly appContextCentral _context;
        private readonly IDataProtector _protector;
        private readonly ILogger<MessageManagementService> _logger;
        private readonly IRepository<EmailTemplate> _emailtemplateRepository;

        public MessageManagementService(appContextCentral context, IDataProtectionProvider dataProtectionProvider, ILogger<MessageManagementService> logger, IRepository<EmailTemplate> emailtemplateRepository)
        {
            _context = context;
           
            _protector = dataProtectionProvider.CreateProtector(GetType().FullName);
           
            _logger = logger;
            _emailtemplateRepository = emailtemplateRepository;


        }

        #region Email Template

        public async Task<EmailTemplateViewModel> GetEmailTemplate(long id)
        {
            try
            {
               // var merchantid = Convert.ToInt64(_authUser.MerchantId);
                //Check the Protected Id validity and try parsing it to long/bigint
               // bool success = long.TryParse(_protector.Unprotect(id), out long unprotId);
                var fetchData = await _context.emailTemplates.FirstOrDefaultAsync(x => x.etemplate_id == id );

                if ( fetchData != null)
                {
                    return new EmailTemplateViewModel
                    {
                        templateid = _protector.Protect(fetchData.etemplate_id.ToString()),
                        code = fetchData.code,
                        name = fetchData.name,
                        subject = fetchData.subject,
                        body = fetchData.body,
                    };
                }
                else
                {
                    //_logger.LogError(string.Format(ResponseErrorMessageUtility.NotValidProtectedId, "TemplateId"));
                    //throw new ExceptionHandlerHelper(ResponseErrorMessageUtility.NotValidProtectedId, "TemplateId");
                    return null;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                //await _bus.RaiseEvent(new DomainNotification("Error", string.Format(ResponseErrorMessageUtility.NotValidProtectedId, "TemplateId")));
                throw;
            }
        }

       

        public async Task<EmailTemplateViewModel> CreateEmailTemplate(EmailTemplateDTO obj)
        {
            try
            {
                EmailTemplate email = new EmailTemplate
                {    code = obj.code,
                    name = obj.name,
                    subject = obj.subject,
                    body = obj.body,
                };
          var result= await  _emailtemplateRepository.CreateAsync(email);


                if (result != null)
                {
                    return new EmailTemplateViewModel
                    {
                        templateid = _protector.Protect(result.etemplate_id.ToString()),
                        code = result.code,
                        name = result.name,
                        subject = result.subject,
                        body = result.body,
                    };
                }
                else
                {
                    return null;
                    //throw new ExceptionHandlerHelper(ResponseErrorMessageUtility.RecordNotSaved);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                //await _bus.RaiseEvent(new DomainNotification("Error", string.Format(ResponseErrorMessageUtility.RecordNotSaved)));
                throw;
            }
        }

        public async Task<bool> UpdateEmailTemplate(EmailTemplateDTO obj, int id)
        {
            try
            {
                //Check the Protected Id validity and try parsing it to long/bigint
                //bool success = long.TryParse(_protector.Unprotect(id), out long unprotId);
                var fetchData = await _context.emailTemplates.FirstOrDefaultAsync(x => x.etemplate_id == id);
                if (fetchData != null)
                {

                    fetchData.etemplate_id = id;
                    fetchData.subject = obj.subject;
                    fetchData.body = obj.body;

                    await _context.SaveChangesAsync();
                    return true;
                }
                else
                
                    return false;
                
               
                
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;

                //await _bus.RaiseEvent(new DomainNotification("Error", string.Format(ResponseErrorMessageUtility.NotValidProtectedId, "TemplateId")));
            }
        }

        public async Task DeleteEmailTemplate(int id)
        {
            try
            {
                //Check the Protected Id validity and try parsing it to long/bigint
                // bool success = long.TryParse(_protector.Unprotect(id), out long unprotId);
                var fetchData = await _context.emailTemplates.FirstOrDefaultAsync(x => x.etemplate_id == id);
                if (fetchData != null)
                {
                    _context.ChangeTracker.Entries().Where(e => e.State == EntityState.Deleted);
                    _context.emailTemplates.Remove(fetchData);

                }
                
                else
                {
                    //_logger.LogError(string.Format(ResponseErrorMessageUtility.NotValidProtectedId, "TemplateId"));
                    //await _bus.RaiseEvent(new DomainNotification("Error", string.Format(ResponseErrorMessageUtility.NotValidProtectedId, "TemplateId")));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                //await _bus.RaiseEvent(new DomainNotification("Error", string.Format(ResponseErrorMessageUtility.NotValidProtectedId, "TemplateId")));
            }
        }
        #endregion

    }
}
