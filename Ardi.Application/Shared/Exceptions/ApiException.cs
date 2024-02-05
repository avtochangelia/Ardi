#nullable disable

using System.Net;
using System.Runtime.Serialization;

namespace Ardi.Application.Shared.Exceptions;

[Serializable]
public class ApiException : Exception
{
    public ApiException(string message) : base(message)
    {
        HttpStatusCode = HttpStatusCode.InternalServerError;
        ErrorMessages = new List<string>();
    }

    public ApiException(HttpStatusCode httpStatusCode, string message) : base(message)
    {
        HttpStatusCode = httpStatusCode;
    }

    public HttpStatusCode HttpStatusCode { get; set; }

    public IEnumerable<string> ErrorMessages { get; set; }
}