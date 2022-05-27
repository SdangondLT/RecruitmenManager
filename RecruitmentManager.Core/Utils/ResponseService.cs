using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentManager.Core.Utils
{
    public class ResponseService<T>
    {
        public ResponseService(bool hasError, string message, HttpStatusCode statusCode, T content)
        {
            this.HasError = hasError;
            this.Message = message;
            this.StatusHttp=statusCode;
            this.Content = content;
        }
        public bool HasError { get; set; }
        public string Message { get; set; }
        public HttpStatusCode StatusHttp { get; set; }
        public T Content { get; set; }
    }
}
