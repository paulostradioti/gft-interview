using System;

namespace Domain.Exceptions
{
    /// <summary>
    /// Should be raised whenever the user inserts invalid data (time of day, selection id) in the input
    /// </summary>
    public class InvalidInputException : Exception
    {
        public InvalidInputException(string message)
            : base(message)
        {

        }

        public InvalidInputException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}