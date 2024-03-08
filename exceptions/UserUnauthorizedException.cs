namespace Livre.exceptions
{

    public class UserUnauthorizedException : Exception
    {
        // Constructor with a custom message
        public UserUnauthorizedException(string message) : base(message)
        {
        }

        // Constructor with a custom message and inner exception
        public UserUnauthorizedException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

}