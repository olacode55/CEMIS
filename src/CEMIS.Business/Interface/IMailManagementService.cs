using CEMIS.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;
using System.Threading.Tasks;
using CEMIS.Data.ViewModel;

namespace CEMIS.Business.Interface
{
   public interface IMailManagementService
    {
            Task<int> SendWelcomeEmail(string emailadd, string username, string password, string loginurl);
            Task<int> SendPasswordResetEmail(string emailadd, string username, string reseturl);
            Task<EmailTemplate> GetEmailTemplate( string code);
            Task<int> SendMail(string emailadd, string subject, string body, string name);
            Task<bool> SendMailAsync(EmailLog emailLog);
            Task SendBatchMailAsync();
            MailSettings GetEmailCredentials();
            Task LogEmail(EmailLog emailLog);
            Task LogBatchEmail(List<EmailLog> eMailLogs);
        }
    }
 








