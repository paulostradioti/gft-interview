using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    /// <summary>
    /// Should be raised when the user inserts invalid data in the selection part of the input
    /// </summary>
    class InvalidSelectionException : Exception
    {
        private const string DefaultInvalidSelectionErrorMessage =
           ;
        public InvalidSelectionException()
            : base(DefaultInvalidSelectionErrorMessage)
        {
        }

        public InvalidSelectionException(string message)
            : base(message)
        {

        }

        public InvalidSelectionException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}
