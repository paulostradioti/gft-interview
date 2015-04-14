using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    class InvalidTimeOfDayException : Exception
    {
        private const string DefaultInvalidTimeOfDayErrorMessage =
            "The Time of Day must be either morning or night. Please, check your entry and try again.";
        public InvalidTimeOfDayException()
            : base(DefaultInvalidTimeOfDayErrorMessage)
        {
        }

        public InvalidTimeOfDayException(string message)
            : base(message)
        {

        }

        public InvalidTimeOfDayException(string message, Exception innerException)
            : base(message, innerException)
        {

        }

    }
}
