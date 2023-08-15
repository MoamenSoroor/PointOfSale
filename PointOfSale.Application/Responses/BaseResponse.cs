using PointOfSale.Application.Exceptions;
using System.Collections.Generic;

namespace PointOfSale.Application.Responses
{

    public class BaseResponse
    {
        public BaseResponse()
        {
            Success = true;
        }
        public BaseResponse(string message = null)
        {
            Success = true;
            Message = message;
        }

        public BaseResponse(string message, bool success)
        {
            Success = success;
            Message = message;
        }

        public bool Success { get; init; }
        public string Message { get; init; }
        public List<string> ValidationErrors { get; init; }
    }
    public class BaseResponse<T> : BaseResponse
    {
        public T Value { get; set; }
    }
}
