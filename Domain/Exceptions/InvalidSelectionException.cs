using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    class InvalidSelectionException : Exception
    {
        private const string DefaultInvalidSelectionErrorMessage =
           "You should select at least one option from the menu.";
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
