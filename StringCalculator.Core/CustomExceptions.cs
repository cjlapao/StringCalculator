using System;

namespace Calculator.Core
{
    public class NegativeNotAllowedException : Exception
    {
        public NegativeNotAllowedException() : base()
        {
        }

        public NegativeNotAllowedException(string message) : base(message)
        {
        }

        public NegativeNotAllowedException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    public class InvalidInputException : Exception
    {
        public InvalidInputException() : base()
        {
        }

        public InvalidInputException(string message) : base(message)
        {
        }

        public InvalidInputException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
