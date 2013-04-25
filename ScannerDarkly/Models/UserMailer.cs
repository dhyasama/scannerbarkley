using System;
using System.Collections.Specialized;
using Mvc.Mailer;
using ScannerDarkly.Helpers;

namespace ScannerDarkly.Mailers
{ 
    public class UserMailer : MailerBase, IUserMailer 	
	{
        string defaultFromEmail = string.Empty;
        string defaultFromName = string.Empty;

		public UserMailer()
		{
			//MasterName="_Layout";

            dynamic settings = ConfigurationSettings.UserMailerSettings();

            // todo - validate

            defaultFromEmail = settings.FromEmail;
            defaultFromName = settings.FromName;
		}
		
		public virtual bool Welcome(string email, string firstName)
		{
            // todo - validate

            bool sent = false;

            var msg = AddHeaders(new MvcMailMessage());
            msg.Subject = "Welcome to Scanner Barkley";
            msg.To.Add(email);
            msg.Bcc.Add(defaultFromEmail);
            msg.From = new System.Net.Mail.MailAddress(defaultFromEmail, defaultFromName);

            ViewBag.FirstName = firstName;

            PopulateBody(msg, viewName: "Welcome");

            try
            {
                msg.Send();
                sent = true;
            }
            catch (Exception ex)
            {
                Utils.LogException(ex);
            }

            return sent;
		}

        public virtual bool PasswordReset(string email)
		{
            // todo - validate

            bool sent = false;

            var msg = AddHeaders(new MvcMailMessage());
            msg.Subject = "Your Scanner Barkley password was reset";
            msg.To.Add(email);
            msg.Bcc.Add(defaultFromEmail);
            msg.From = new System.Net.Mail.MailAddress(defaultFromEmail, defaultFromName);

            PopulateBody(msg, viewName: "Welcome");

            try
            {
                msg.Send();
                sent = true;
            }
            catch (Exception ex)
            {
                Utils.LogException(ex);
            }

            return sent;
		}

        public virtual bool Alert(string email, string message)
        {
            // todo - validate

            bool sent = false;

            var msg = AddHeaders(new MvcMailMessage());
            msg.Subject = "Scanner Barkley Alert";
            msg.To.Add(email);
            msg.Bcc.Add(defaultFromEmail);
            msg.From = new System.Net.Mail.MailAddress(defaultFromEmail, defaultFromName);

            ViewBag.Message = message;

            PopulateBody(msg, viewName: "Alert");

            try
            {
                msg.Send();
                sent = true;
            }
            catch (Exception ex)
            {
                Utils.LogException(ex);
            }

            return sent;
        }

        private MvcMailMessage AddHeaders(MvcMailMessage msg)
        {
            msg.Headers.Add("X-MC-Track", "opens,clicks_all");
            msg.Headers.Add("X-MC-Autotext", "1");

            return msg;
        }
 	}
}