using System.Collections.Generic;
using System;

namespace Test_Shop.Application.Common.Exceptions
{
    public class BadRequestException : Exception
    {
        public IEnumerable<string> Errors { get; set; }

        public BadRequestException()
            : base()
        {
        }

        public BadRequestException(string message)
            : base(message)
        {
        }

        public BadRequestException(IEnumerable<string> errors)
        {
            Errors = errors;
        }

        public BadRequestException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
