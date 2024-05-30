using System.Net;
using System.Runtime.Serialization;

namespace Shop_Api
{
    [Serializable]
    public class HttpException : Exception
    {
        public HttpStatusCode Status { get; set; }
        public HttpException(HttpStatusCode status)
        {
            this.Status = status;
        }

        public HttpException(string? message, HttpStatusCode status) : base(message)
        {
            this.Status = status;
        }

        public HttpException(string? message, Exception? innerException, HttpStatusCode status) : base(message, innerException)
        {
            this.Status = status;
        }

        protected HttpException(SerializationInfo info, StreamingContext context, HttpStatusCode status) : base(info, context)
        {
            this.Status = status;
        }
    }
}