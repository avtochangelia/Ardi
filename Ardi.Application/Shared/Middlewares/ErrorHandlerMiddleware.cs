#nullable disable

using Ardi.Application.Shared.Exceptions;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Text.Json;

namespace Ardi.Application.Shared.Middlewares;

public class ErrorHandlerMiddleware(RequestDelegate next)
{
    private readonly RequestDelegate _next = next;

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception error)
        {
            var response = context.Response;
            var errorTypeName = error.GetType().Name;
            response.ContentType = "application/json";

            switch (errorTypeName)
            {
                case nameof(ApiException):
                    await HandleApiException(error as ApiException, response);
                    break;
                case nameof(KeyNotFoundException):
                    await HandleKeyNotFoundException(error as KeyNotFoundException, response);
                    break;
                case nameof(ValidationException):
                    await HandleValidationException(error as ValidationException, response);
                    break;
                default:
                    await HandleUnknownException(error, response);
                    break;
            }
        }
    }

    private static async Task HandleValidationException(ValidationException exception, HttpResponse response)
    {
        await HandleException(response, HttpStatusCode.BadRequest, exception.Failures.SelectMany(failure => failure.Value));
    }

    private static async Task HandleUnknownException(Exception exception, HttpResponse response)
    {
        await HandleException(response, HttpStatusCode.InternalServerError, GetInnerExceptions(exception).Select(e => e.Message));
    }

    private static async Task HandleKeyNotFoundException(KeyNotFoundException exception, HttpResponse response)
    {
        await HandleException(response, HttpStatusCode.NotFound, new List<string> { exception.Message });
    }

    private static async Task HandleApiException(ApiException exception, HttpResponse response)
    {
        await HandleException(response, HttpStatusCode.BadRequest, exception.ErrorMessages);
    }

    private static async Task HandleException(
        HttpResponse response,
        HttpStatusCode httpStatusCode,
        IEnumerable<string> errors)
    {
        var responseModel = new BaseResponse() { Errors = errors.ToList(), HttpStatusCode = httpStatusCode };
        response.StatusCode = (int)httpStatusCode;

        var result = JsonSerializer.Serialize(responseModel);
        await response.WriteAsync(result);
    }

    public static IEnumerable<Exception> GetInnerExceptions(Exception ex)
    {
        ArgumentNullException.ThrowIfNull(ex);

        var innerException = ex;
        do
        {
            yield return innerException;
            innerException = innerException.InnerException;
        }
        while (innerException != null);
    }
}