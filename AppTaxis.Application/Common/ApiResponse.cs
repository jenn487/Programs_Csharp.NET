using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTaxis.Application.Common
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public List<string> Errors { get; set; } = new List<string>();

        public ApiResponse()
        {
        }

        public ApiResponse(T data, string message = null)
        {
            Success = true;
            Data = data;
            Message = message ?? "Operación exitosa";
        }

        public ApiResponse(string message, List<string> errors = null)
        {
            Success = false;
            Message = message;
            Errors = errors ?? new List<string>();
        }
    }

    public class ApiResponse : ApiResponse<object>
    {
        public ApiResponse() : base()
        {
        }

        public ApiResponse(string message, List<string> errors = null) : base(message, errors)
        {
        }
    }
}