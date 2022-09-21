using Microsoft.AspNetCore.Mvc;

namespace Proyecto.DTOs
{
    public class ResponseError
    {
        public ResponseError(int StatusCode, string Message)
        {
            this.StatusCode = StatusCode;
            this.Message = Message;
        }

        public int StatusCode { get; set; }

        public string Message { get; set; }

        public ObjectResult GetObjectResult()
        {
            return new ObjectResult(this)
            {
                StatusCode = this.StatusCode,
            };
        }
    }
}
