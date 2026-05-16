using System.Net;

namespace DataStore.Abstraction.Utilities
{
    public class CustomExceptions
    {
        public class APIException : Exception
        {
            public HttpStatusCode? StatusCode { get; set; }
            public APIException(string message) : base(message) { }
            public APIException(string message, Exception innerException) : base(message, innerException) { }
            public APIException(string message, HttpStatusCode status) : base(message)
            {
                StatusCode = status;
            }
        }
    }
}
