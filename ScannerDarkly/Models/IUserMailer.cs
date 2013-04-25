using Mvc.Mailer;

namespace ScannerDarkly.Mailers
{ 
    public interface IUserMailer
    {
        bool Welcome(string email, string firstName);
        bool PasswordReset(string email);
        bool Alert(string email, string message);
	}
}