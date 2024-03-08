using System.ComponentModel.DataAnnotations;
using System.Net;
using Livre.exceptions;
using Livre.models;
using Microsoft.AspNetCore.Diagnostics;

namespace Livre.configurations {

    public class GlobalExceptionHandler : IExceptionHandler
    {
        /// <summary>
        /// Catches an exception and handles it by returning an ErrorDetails object to the consumer.
        /// </summary>
        /// <param name="httpContext">Holds information about our current HTTP request.</param>
        /// <param name="exception">The exception that has occurred that needs to be handled.</param>
        /// <param name="cancellationToken">In simple terms, a cancellation token is like a way to politely ask your task to stop
        ///  working if something else comes up. It's a handy tool for making your programs more responsive and flexible.</param>
        /// <returns>True if the exception was successfully handled.</returns>
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            // Create our ErrorDetails. For now we are just creating a very generic 500 error with a generic message
            // as an example.
            ErrorDetails errorDetails = new ErrorDetails();

            if (exception is EntityNotFoundException) {
                errorDetails.StatusCode = (int) HttpStatusCode.NotFound;
                errorDetails.Message = "Entity was not found.";
                errorDetails.ExceptionMessage = exception.Message;
            } else if (exception is UserUnauthorizedException) {
                errorDetails.StatusCode = (int) HttpStatusCode.Unauthorized;
                errorDetails.Message = "User is not authorized for the requested resource.";
                errorDetails.ExceptionMessage = exception.Message;
            } else if (exception is ValidationException) {
                errorDetails.StatusCode = (int) HttpStatusCode.BadRequest;
                errorDetails.Message = "Validation errors have occurred.";
                errorDetails.ExceptionMessage = exception.Message;
            } else {
                errorDetails.StatusCode = (int) HttpStatusCode.InternalServerError;
                errorDetails.Message = "Something went wrong.";
                errorDetails.ExceptionMessage = exception.Message;
            }

            // Set the status code of the HTTP Response and the Content Type of the HTTP Response.
            httpContext.Response.StatusCode = errorDetails.StatusCode;
            httpContext.Response.ContentType = "application/json";
            
            // Write our error details as JSON for the response body.
            await httpContext.Response.WriteAsJsonAsync(errorDetails, cancellationToken);

            // Return true as we have successfully handled our exception.
            return true;
        }
    }

}