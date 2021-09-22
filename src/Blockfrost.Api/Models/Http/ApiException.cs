using System.Collections.Generic;

namespace Blockfrost.Api
{
    public partial class ApiException : System.Exception
    {
        public ApiException(string message, int statusCode, string response, IReadOnlyDictionary<string, IEnumerable<string>> headers, System.Exception innerException)
            : base(message + "\n\nStatus: " + statusCode + "\nResponse: \n" + ((response == null) ? "(null)" : response.Substring(0, response.Length >= 512 ? 512 : response.Length)), innerException)
        {
            StatusCode = statusCode;
            Response = response;
            Headers = headers;
        }

        public IReadOnlyDictionary<string, IEnumerable<string>> Headers { get; private set; }
        public string Response { get; private set; }
        public int StatusCode { get; private set; }

        public override string ToString()
        {
            return $"HTTP Response: \n\n{Response}\n\n{base.ToString()}";
        }
    }

    public partial class ApiException<TResult> : ApiException
    {
        public ApiException(string message, int statusCode, string response, IReadOnlyDictionary<string, IEnumerable<string>> headers, TResult result, System.Exception innerException)
            : base(message, statusCode, response, headers, innerException)
        {
            Result = result;
        }

        public TResult Result { get; private set; }
    }
}

