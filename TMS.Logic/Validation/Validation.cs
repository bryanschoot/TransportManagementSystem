using System;
using System.Net.Mail;

namespace TMS.Logic.Validation
{
    public class Validation
    {
        public bool IsValid(string email)
        {
            try
            {
                MailAddress e = new MailAddress(email);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}