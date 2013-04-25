using System;
using System.Configuration;

namespace ScannerDarkly.Helpers
{
    public class ConfigurationSettings
    {
        public static dynamic AdminSettings()
        {
            dynamic settings = new { 
                Contact = new {
                    Email = ConfigurationManager.AppSettings["Admin.Contact.Email"],
                    Phone = ConfigurationManager.AppSettings["Admin.Contact.Phone"],
                },
                Session = new  {
                    Timeout = ConfigurationManager.AppSettings["Admin.Session.Timeout"],
                    Version = ConfigurationManager.AppSettings["Admin.Session.Version"],
                    Domain = ConfigurationManager.AppSettings["Admin.Session.Domain"],
                    Secure = ConfigurationManager.AppSettings["Admin.Session.Secure"]
                }
            };

            return settings;
        }

        public static string Domain()
        {
            return ConfigurationManager.AppSettings["Domain"];
        }

        public static dynamic MandrillSettings()
        {
            dynamic settings = new
            {
                ApiKey = ConfigurationManager.AppSettings["Mandrill.ApiKey"],
                FromEmail = ConfigurationManager.AppSettings["Mandrill.FromEmail"],
                FromName = ConfigurationManager.AppSettings["Mandrill.FromName"]
            };

            return settings;
        }

        public static dynamic TwilioSettings()
        {
            dynamic settings = new
            {
                AccountSid = ConfigurationManager.AppSettings["Twilio.AccountSid"],
                AuthToken = ConfigurationManager.AppSettings["Twilio.AuthToken"]
            };

            return settings;
        }

        public static dynamic TwitterSettings()
        {
            dynamic settings = new
            {
                ConsumerKey = ConfigurationManager.AppSettings["Twitter.ConsumerKey"],
                ConsumerSecret = ConfigurationManager.AppSettings["Twitter.ConsumerSecret"],
                OAuthToken = ConfigurationManager.AppSettings["Twitter.OAuthToken"],
                AccessToken = ConfigurationManager.AppSettings["Twitter.AccessToken"],
                Screenname = ConfigurationManager.AppSettings["Twitter.Screenname"]
            };

            return settings;
        }

        public static dynamic UserMailerSettings()
        {
            dynamic settings = new
            {
                FromEmail = ConfigurationManager.AppSettings["Mailer.User.FromEmail"],
                FromName = ConfigurationManager.AppSettings["Mailer.User.FromName"]
            };

            return settings;
        }
    }
}