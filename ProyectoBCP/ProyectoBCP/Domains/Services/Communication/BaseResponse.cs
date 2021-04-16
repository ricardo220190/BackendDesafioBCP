using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoBCP.Domains.Services.Communication
{
    public class BaseResponse<T>
    {
        protected BaseResponse(T resource)
        {
            Resource = resource;
            Success = true;
            Message = string.Empty;

        }

        public BaseResponse(string message) 
        {
            Message = message;
            Success = false;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
        public T Resource { get; protected set; }
    }
}
