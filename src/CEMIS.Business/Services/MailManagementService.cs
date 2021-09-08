using CEMIS.Business.Interface;
using CEMIS.Data;
using CEMIS.Data.Entities;
using CEMIS.Data.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace CEMIS.Business.Services
{
  public  class MailManagementService: IMailManagementService
    {
        private readonly IConfiguration _config;
        private readonly IServiceScopeFactory _serviceScope;
        private readonly ILogger<MailManagementService> _logger;
        private readonly IAuthUser _authuser;
        
        public MailManagementService(IConfiguration config, IServiceScopeFactory serviceScope, ILogger<MailManagementService> logger,
            IAuthUser authuser)
        {
            _config = config;
            _serviceScope = serviceScope;
            _logger = logger;
            _authuser = authuser;
        }

        #region Generic Message Sender
        public async Task<int> SendMail(string emailadd, string subject, string body, string name)
        {
            var cred = GetEmailCredentials();
            try
            {
                MailMessage NewEmail = new MailMessage(cred.SenderEmail, emailadd, subject, body)
                {
                    IsBodyHtml = true,
                    Priority = MailPriority.High,
                    From = new MailAddress(cred.SenderEmail, cred.SenderName)
                };       
                using (SmtpClient smtpMail = new SmtpClient())
                {
                    smtpMail.Host = cred.SMTPHost;
                    smtpMail.Port = cred.SMTPPort;
                    smtpMail.EnableSsl = cred.EnableSsl;
                    smtpMail.Credentials = new NetworkCredential(cred.SenderEmail, cred.Password);
                    //var x = (!string.IsNullOrEmpty(cred.CC)) ? NewEmail.CC.Add(cred.CC) : null;
                    await smtpMail.SendMailAsync(NewEmail);
                    EmailLog newrec = new EmailLog
                    {
                        Sendimmediately = true,
                        Datetosend = DateTime.Now,
                        CanSend = true,
                        Name = name,
                        From = cred.SenderEmail,
                        Sent = true,
                        To = emailadd,
                        Subject = subject,
                        Body = body,
                        EmailCc = cred.CC,
                        EmailBcc = cred.BCC,
                        Createdby = "System",
                    };
                    await LogEmail(newrec);
                }
            }
            catch (Exception ex)
            {
                EmailLog newrec = new EmailLog
                {
                    Sendimmediately = true,
                    Datetosend = DateTime.Now,
                    CanSend = true,
                    Name = name,
                    From = cred.SenderEmail,
                    FailedSending = true,
                    LastFailed = DateTime.Now,
                    Sent = false,
                    To = emailadd,
                    Subject = subject,
                    Body = body,
                    EmailCc = cred.CC,
                    EmailBcc = cred.BCC,
                    Createdby = "System",
                };
                await LogEmail(newrec);
                _logger.LogError(ex.Message);
                return 1001;
            }
            return 0;
        }

        public async Task<bool> SendMailAsync(EmailLog emailLog)
        {
            try
            {
                MailMessage mMessage = new MailMessage();
                var cred = GetEmailCredentials();
                mMessage.To.Add(emailLog.To);
                mMessage.Subject = emailLog.Subject;
                if (emailLog.From.Contains(">"))
                {
                    mMessage.From = new MailAddress(emailLog.From);
                }
                else
                {
                    mMessage.From = new MailAddress($"{emailLog.Name} <{emailLog.From}>");
                }
                //Check if it has Carbon Copy
                if (!string.IsNullOrEmpty(emailLog.EmailCc))
                {
                    string[] CCId = emailLog.EmailCc.Split(',');
                    foreach (string CCEmail in CCId)
                    {
                        mMessage.CC.Add(new MailAddress(CCEmail)); //Adding Multiple CC email Id
                    }
                }
                mMessage.Body = emailLog.Body;
                mMessage.Priority = MailPriority.High;
                mMessage.IsBodyHtml = true;
                if (emailLog.HasAttachment)
                {
                    var attachments = emailLog.AttachmentLoc.Split(',');
                    foreach (var attt in attachments)
                    {
                        var leAttachment = Path.Combine(Directory.GetCurrentDirectory(), attt);
                        mMessage.Attachments.Add(new Attachment(leAttachment));
                    }
                }  
                using (SmtpClient smtpMail = new SmtpClient())
                {
                    smtpMail.Host = cred.SMTPHost;
                    smtpMail.Port = Convert.ToInt32(cred.SMTPPort);
                    smtpMail.EnableSsl = true;
                    smtpMail.Credentials = new NetworkCredential(cred.SenderEmail, cred.Password);
                    await smtpMail.SendMailAsync(mMessage);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        #region Email Credentials
        public MailSettings GetEmailCredentials()
        {
            try
            {
                var appSettingsSection = _config.GetSection("MailSettings");
                var appSettings = appSettingsSection.Get<MailSettings>();
                return appSettings;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }
        #endregion
        #region Email Template
        public async Task<EmailTemplate> GetSystemEmailTemplate(string code)
        {
            try
            {
                using (var scope = _serviceScope.CreateScope())
                {
                    var dbcontext = scope.ServiceProvider.GetService<appContext>();
                   var fetchdata = await dbcontext.emailTemplates
                        .Where(x => x.code.ToUpper().Trim() == code.ToUpper().Trim() && x.IsActive == true)
                        .Select(x => new EmailTemplate
                        {
                          
                            subject = x.subject,
                            etemplate_id = x.etemplate_id,
                            body = x.body,
                            code = x.code,
                            name = x.name
                        }).FirstOrDefaultAsync();
                    return fetchdata;
                }
                
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }
        
        #endregion
        #region Mail Logging
        public async Task LogBatchEmail(List<EmailLog> eMailLogs)
        {
            try
            {
                using (var scope = _serviceScope.CreateScope())
                {
                    var dbcontext = scope.ServiceProvider.GetService<appContext>();
                    dbcontext.emailLogs.AddRange(eMailLogs);
                    await dbcontext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }
        public async Task LogEmail(EmailLog emailLog)
        {
            try
            {
                using (var scope = _serviceScope.CreateScope())
                {
                    var dbcontext = scope.ServiceProvider.GetService<appContext>();
                    emailLog.LastFailed = null;
                    emailLog.Lastmodified = null;
                    emailLog.Createddate = DateTime.Now;
                    dbcontext.emailLogs.Add(emailLog);
                    await dbcontext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }
        #endregion
        
        #region Password Reset Mail Service
        public async Task<int> SendPasswordResetEmail(string emailadd, string username, string password)
        {
            //Fetch Subject from DB based on supplied template ID
            var fetchtemplate = await GetSystemEmailTemplate("RST_PWD");
            //Replace placeholder in template with message sent
            //string MessageBody = fetchtemplate.body.Replace("[Username]", username);
            //MessageBody = MessageBody.Replace("[ResetURL]", reseturl);
             string MessageBody = "You just initiated a Password Reset on Cemis System.Username: " + username + "<br/> Password: " + password + ". <br/> CEMIS";

            var cred = GetEmailCredentials();
            try
            {
                MailMessage NewEmail = new MailMessage(cred.SenderEmail, emailadd, fetchtemplate.subject, MessageBody)
                {
                    IsBodyHtml = true,
                    Priority = MailPriority.High,
                    From = new MailAddress(cred.SenderEmail, cred.SenderName)
                };
                // Add a carbon copy recipient.
                //MailAddress copy = new MailAddressCollection(cred.CC,);
                using (SmtpClient smtpMail = new SmtpClient())
                {
                    smtpMail.Host = cred.SMTPHost;
                    smtpMail.Port = cred.SMTPPort;
                    smtpMail.EnableSsl = cred.EnableSsl;
                    smtpMail.Credentials = new NetworkCredential(cred.SenderEmail, cred.Password);
                    await smtpMail.SendMailAsync(NewEmail);
                    EmailLog newrec = new EmailLog
                    {
                        Sendimmediately = true,
                        Datetosend = DateTime.Now,
                        CanSend = true,
                        Name = fetchtemplate.name,
                        From = cred.SenderEmail,
                        Sent = true,
                        To = emailadd,
                        Subject = fetchtemplate.subject,
                        Body = MessageBody,
                        EmailCc = cred.CC,
                        EmailBcc = cred.BCC,
                        Createdby = username,
                    };
                    await LogEmail(newrec);
                }
            }
            catch (Exception ex)
            {
              EmailLog newrec = new EmailLog
                {
                    Sendimmediately = true,
                    Datetosend = DateTime.Now,
                    CanSend = true,
                    Name = fetchtemplate.name,
                    From = cred.SenderEmail,
                    FailedSending = true,
                    LastFailed = DateTime.Now,
                    Sent = false,
                    To = emailadd,
                    Subject = fetchtemplate.subject,
                    Body = MessageBody,
                    EmailCc = cred.CC,
                    EmailBcc = cred.BCC,
                    Createdby = username,
                };
                await LogEmail(newrec);
                _logger.LogError(ex.Message);
                return 1001;
            }
            return 0;
        }
        
        public async Task<int> SendWelcomeEmail(string emailadd, string username, string password, string loginurl)
        {
            //Fetch Subject from DB based on supplied template ID
            var fetchtemplate = await GetSystemEmailTemplate("WLCM_EML");
            //Replace placeholder in template with message sent
            string MsgBody = "Your account has been created on the Cemis System with details; Username: " + username + "<br/> Password: " + password + ". <br/>Please confirm your account by clicking <a href=\"" + loginurl + "\">here</a><br/> Best Regards, <br/> CEMIS";
            
            var guid_string = Guid.NewGuid().ToString();
            var cred = GetEmailCredentials();
            try
            {
                MailMessage NewEmail = new MailMessage(cred.SenderEmail, emailadd, fetchtemplate.subject, MsgBody)
                {
                    IsBodyHtml = true,
                    Priority = MailPriority.High,
                    From = new MailAddress(cred.SenderEmail, cred.SenderName)
                };
                // Add a carbon copy recipient.
                //MailAddress copy = new MailAddressCollection(cred.CC,);
                using (SmtpClient smtpMail = new SmtpClient())
                {
                    smtpMail.Host = cred.SMTPHost;
                    smtpMail.Port = cred.SMTPPort;
                    smtpMail.EnableSsl = cred.EnableSsl;
                    smtpMail.Credentials = new NetworkCredential(cred.SenderEmail, cred.Password);
                    //var x = (!string.IsNullOrEmpty(cred.CC)) ? NewEmail.CC.Add(cred.CC) : null;
                    await smtpMail.SendMailAsync(NewEmail);
                    EmailLog newrec = new EmailLog
                    {
                        Sendimmediately = true,
                        Datetosend = DateTime.Now,
                        CanSend = true,
                        Name = fetchtemplate.name,
                        From = cred.SenderEmail,
                        Sent = true,
                        To = emailadd,
                        Subject = fetchtemplate.subject,
                        Body = MsgBody,
                        EmailCc = cred.CC,
                        EmailBcc = cred.BCC,
                        Createdby = _authuser.Name,
                    };
                    await LogEmail(newrec);
                }
            }
            catch (Exception ex)
            {
                EmailLog newrec = new EmailLog
                {
                    Sendimmediately = true,
                    Datetosend = DateTime.Now,
                    CanSend = true,
                    Name = fetchtemplate.name,
                    From = cred.SenderEmail,
                    FailedSending = true,
                    LastFailed = DateTime.Now,
                    Sent = false,
                    To = emailadd,
                    Subject = fetchtemplate.subject,
                    Body = MsgBody,
                    EmailCc = cred.CC,
                    EmailBcc = cred.BCC,
                    Createdby = _authuser.Name,
                };
                await LogEmail(newrec);
                _logger.LogError(ex.Message);
                return 1001;
            }
           return  0;
        }
        #endregion

        public async Task SendBatchMailAsync()
        {
            try
            {
                using (var scope = _serviceScope.CreateScope())
                {
                    var dbcontext = scope.ServiceProvider.GetService<appContext>();
                    var unsentEmails = await dbcontext.emailLogs.Where(x => x.Sent == false && x.Sendimmediately
                    && (x.Datetosend.Date == DateTime.Now.Date || DateTime.Now.Date > x.Datetosend.Date)).ToListAsync();
                    foreach (var email in unsentEmails)
                    {
                        email.Sent = await SendMailAsync(email);
                        dbcontext.Update(email);
                        await dbcontext.SaveChangesAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }
        public Task<EmailTemplate> GetEmailTemplate(string code)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
 
    
