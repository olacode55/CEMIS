using CEMIS.Business.Central.Interface;
using Hangfire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CEMIS.Web.CentralPortal.Utilities
{
    public class EmailHanfireHandler : IEmailHanfireHandler
    {
        public IMailManagementService _emailService;

        public EmailHanfireHandler(IMailManagementService emailService)
        {
            _emailService = emailService;
        }
        public void Email()
        {
            RecurringJob.RemoveIfExists(nameof(_emailService.SendEmailLog));
            RecurringJob.AddOrUpdate(() => _emailService.SendEmailLog(), "*/3 * * * *");
        }
    }
}
