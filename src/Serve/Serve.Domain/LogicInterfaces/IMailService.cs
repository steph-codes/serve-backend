using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serve.Domain.LogicInterfaces
{
    public interface IMailService
    {

        Task SendEmailAsync(string toEmail, string subject, string content);
    }

    public class SendGridEmailService : IMailService
    {
        private IConfiguration _configuration;

        public SendGridEmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task SendEmailAsync(string toEmail, string subject, string content)
        {
            var Key = "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";
            var apiKey = Key;
            //_configuration["SendGridAPIKey"];
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("ogundele370@gmail.com", "Tech-Haven");
            //var subject = "Team Invite";itohanoomoruyi@yahoo.com
            var to = new EmailAddress(toEmail);
            //var plainTextContent = "Team Invite";
            //var htmlContent = EmailFormatter.TeamMemberInvitation();
            var htmlContent = content;
            var msg = MailHelper.CreateSingleEmail(from, to, subject, content, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }

    }


}


