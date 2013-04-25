using System;
using Twilio;
using ScannerDarkly.Helpers;

namespace ScannerDarkly.Models
{
    public class TwilioRepository
    {
        TwilioRestClient twilio;

        public TwilioRepository()
        {
            dynamic settings = ConfigurationSettings.TwilioSettings();

            // todo - validate

            twilio = new TwilioRestClient(settings.AccountSid, settings.AuthToken);
        }

        public SMSMessage SendSms(string from, string to, string body)
        {
            // todo - validate

            SMSMessage sms = null;

            try
            {
                sms = twilio.SendSmsMessage(from, to, body, ConfigurationSettings.Domain() + "/sms");
            }
            catch (Exception ex)
            {
                Utils.LogException(ex);
            }

            return sms;
        }
    }
}
