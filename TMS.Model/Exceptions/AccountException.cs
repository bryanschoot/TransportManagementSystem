using System;

namespace TMS.Model.Exceptions
{
    public class AccountException : Exception
    {
        public AccountException() { }

        public AccountException(string message) : base(message) { }
    }
}