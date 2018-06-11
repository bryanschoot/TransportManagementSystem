using System;

namespace TMS.Model.Exceptions
{
    public class OrderException : Exception
    {
        public OrderException() { }
        public OrderException(string message) : base(message) { }
    }
}