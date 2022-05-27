using System.Net;

namespace RecruitmentManager.Entities.Utils
{
    public class ResponseService<T>
    {
        public bool HasError { get; set; }
        public string Message { get; set; }
        public HttpStatusCode StatusHttp { get; set; } = HttpStatusCode.OK;
        public T Content { get; set; }

        public ResponseService(bool hasError, string message, HttpStatusCode statusCode, T content)
        {
            this.HasError = hasError;
            this.Message = message;
            this.StatusHttp = statusCode;
            this.Content = content;
        }
    }
}
