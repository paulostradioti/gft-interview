using System;
using System.Text;

namespace Domain.Utilities
{
    public static class ExtensionMethos
    {
        /// <summary>
        /// This method goes through all the Inner Exceptions of a given Exception and concatenates their Error message in a sing String that is returned at the end of the loop.
        /// </summary>
        /// <param name="ex">The main exception that might contain a chain of inner exceptions.</param>
        /// <returns></returns>
        public static string DetailedExceptionMessage(this Exception ex)
        {
            var exception = ex;
            var message = new StringBuilder();

            do
            {
                message.AppendLine(exception.Message);
                message.AppendLine(Environment.NewLine);

                exception = ex.InnerException;

            } while (exception != null);

            return message.ToString();
        }
    }
}