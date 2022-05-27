using System;
using System.Net;
using Microsoft.Extensions.Logging;
using RecruitmentManager.Entities.Utils;

namespace RecruitmentManager.Core.Core.ErrorsHandler
{
    public class ErrorHandler<T>
    {
        private readonly ILogger<T> _logger;

        public ErrorHandler(ILogger<T> logger)
        {
            _logger = logger;
        }

        public ResponseService<U> Error<U>(Exception ex, string serviceName, U content)
        {
            string innerException = ex.InnerException == null ? string.Empty : ex.InnerException.Message;
            _logger.LogError(ex, $"Service: {serviceName}, Message: {ex.Message}, InnerMessage: {innerException}");
            return new ResponseService<U>(true, $"Exception: {ex.Message}, InnerMessage: {innerException}", HttpStatusCode.InternalServerError, content);
        }
    }
}
