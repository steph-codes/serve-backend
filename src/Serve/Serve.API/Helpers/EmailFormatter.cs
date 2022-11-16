namespace Serve.API.Helpers
{
    public class EmailFormatter
    {
        //public static string NewUserEmailConfirmation(string firstName, string companyName, string emailAddress, string User)
        public static string ConfirmUserAppointment(string firstName, string companyName, string emailAddress, string User)
        {
            string emailContent = "";
            string path = Path.GetFullPath(Path.Combine("EmailTemplate", "EmailConfirmation.html"));
            using (StreamReader sr = new StreamReader(path))
            {
                emailContent = sr.ReadToEnd();
            }

            //emailContent = emailContent.Replace("{User}", firstName);
            //emailContent = emailContent.Replace("{Organization}", companyName);
            //emailContent = emailContent.Replace("{ConfirmationUrl}", applicationUrl);
            return emailContent;
        }

        //public static string TeamMemberInvitation(string role, decimal hourlyRate, string inviteeEmail, string teamName, int teamId, bool isUserExisting, string aspNetUserId, string applicationUrl)
        public static string BusinessConfirmAppointment(string email, string teamName)
        {
            string emailContent = "";
            string path = Path.GetFullPath(Path.Combine("EmailTemplate", "TeamMemberInvitation.html"));
            using (StreamReader sr = new StreamReader(path))
            {
                emailContent = sr.ReadToEnd();
            }

            //string token = teamId + "#" + teamName + "#" + inviteeEmail + "#" + aspNetUserId;
            //token = EncryptionUtility.Encrypt(token);

            //UserInvitationDataEncode encodedData = new UserInvitationDataEncode
            //{

            //    InviteeEmail = inviteeEmail,
            //    Token = token,

            //};
            //var serializedObject = JsonConvert.SerializeObject(encodedData);
            //serializedObject = WebUtility.UrlEncode(serializedObject);

            //string url = applicationUrl + "?token=" + serializedObject;
            //i.e Team = name(name)
            emailContent = emailContent.Replace("{email}", email);
            emailContent = emailContent.Replace("{TeamName}", teamName);
            //emailContent = emailContent.Replace("{TeamInvitationUrl}", url);
            return emailContent;
        }

        //public static string CompleteUserRegistration()
        public static string CompleteUserRegistration(string firstName, string loginUrl)
        {
            string emailContent = "";
            string path = Path.GetFullPath(Path.Combine("EmailTemplate", "CompleteUserRegistration.html"));
            using (StreamReader sr = new StreamReader(path))
            {
                emailContent = sr.ReadToEnd();
            }

            emailContent = emailContent.Replace("{FirstName}", firstName);
            //emailContent = emailContent.Replace("{Organization}", companyName);
            emailContent = emailContent.Replace("{LoginUrl}", loginUrl);

            return emailContent;
        }

        //public static string ResetPassword(string firstName, string applicationUrl)
        public static string ResetPassword()
        {
            string emailContent = "";
            string path = Path.GetFullPath(Path.Combine("EmailTemplate", "ForgotPassword.html"));
            using (StreamReader sr = new StreamReader(path))
            {
                emailContent = sr.ReadToEnd();
            }

            //emailContent = emailContent.Replace("{User}", firstName);
            //emailContent = emailContent.Replace("{ResetPasswordUrl}", applicationUrl);
            return emailContent;
        }


        public static string MatterReminderSceduler(string ReasourceType, string Title, DateTime DueDate)
        {
            string emailContent = "";
            string path = Path.GetFullPath(Path.Combine("EmailTemplate", "MatterReminder.html"));
            using (StreamReader sr = new StreamReader(path))
            {
                emailContent = sr.ReadToEnd();
            }

            emailContent = emailContent.Replace("{ResourceName}", ReasourceType);
            emailContent = emailContent.Replace("{DueDate}", DueDate.ToString());
            emailContent = emailContent.Replace("{Title}", Title);
            return emailContent;
        }

        public static string ReminderSceduler(string Title, DateTime DueDate)
        {
            string emailContent = "";
            string path = Path.GetFullPath(Path.Combine("EmailTemplate", "Reminder.html"));
            using (StreamReader sr = new StreamReader(path))
            {
                emailContent = sr.ReadToEnd();
            }

            emailContent = emailContent.Replace("{DueDate}", DueDate.ToString());
            emailContent = emailContent.Replace("{Title}", Title);
            return emailContent;
        }


        public static string DuplicateAccountNotification(string firstName, string companyName)
        {
            string emailContent = "";
            string path = Path.GetFullPath(Path.Combine("EmailTemplate", "DuplicateAccountNotification.html"));
            using (StreamReader sr = new StreamReader(path))
            {
                emailContent = sr.ReadToEnd();
            }

            emailContent = emailContent.Replace("{User}", firstName);
            emailContent = emailContent.Replace("{Organization}", companyName);
            return emailContent;
        }

        public static string UserPermissionsChange(string firstName, string companyName, string loginUrl)
        {
            string emailContent = "";
            string path = Path.GetFullPath(Path.Combine("EmailTemplate", "UserPermissionsChange.html"));
            using (StreamReader sr = new StreamReader(path))
            {
                emailContent = sr.ReadToEnd();
            }

            emailContent = emailContent.Replace("{User}", firstName);
            emailContent = emailContent.Replace("{Organization}", companyName);
            emailContent = emailContent.Replace("{LoginUrl}", loginUrl);
            return emailContent;
        }
    }
}
