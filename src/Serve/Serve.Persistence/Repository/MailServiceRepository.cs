using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using Serve.Domain.LogicInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serve.Persistence.Repository
{
    public class MailServiceRepository: IMailService
    {
   
        private IConfiguration _configuration;

        public MailServiceRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task SendEmailAsync(string toEmail, string subject, string content)
        {
            var Key = "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";
            var apiKey = Key;
            //_configuration["SendGridAPIKey"];
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("ogundele370@gmail.com", "Serve");
            //var subject = "Team Invite";itohanoomoruyi@yahoo.com
            var to = new EmailAddress(toEmail);
            //var plainTextContent = "Team Invite";
            //var htmlContent = EmailFormatter.TeamMemberInvitation();
            var htmlContent = content;
            var msg = MailHelper.CreateSingleEmail(from, to, subject, content, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }

        public async Task SendMailAsync(string toEmail, string subject, string content)
        {
            //var Key = "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";
            var apiKey = _configuration["SendGridAPIKey"];
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("ogundele370@gmail.com", "Tech-Haven");
            //var subject = "Team Invite";itohanoomoruyi@yahoo.com
            var to = new EmailAddress("tunde.o@novajii.com", "Tunde ogundele");
            //var to = new EmailAddress(toEmail);
            //var plainTextContent = "Team Invite";
            //var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
            var htmlContent = "";
            //EmailFormatter.CompleteUserRegistration();

            var msg = MailHelper.CreateSingleEmail(from, to, subject, content, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
    
    }
}
