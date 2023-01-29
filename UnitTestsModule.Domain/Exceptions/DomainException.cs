using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitTestsModule.Domain.Exceptions
{
    public class DomainException : Exception
    {
        public DomainException(string message, params ErrorMessage[] errorMessages) : base(message)
        {
            this.ErrorMessages = errorMessages.ToList();
        }

        public List<ErrorMessage> ErrorMessages { get; set; }
    }
}
