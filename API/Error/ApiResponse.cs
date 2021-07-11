using System;

namespace API.Error
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }

        private string GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "A bad request, you have made",
                401 => "Authoried, your are not",
                404 => "Resource found, it was not",
                500 => "Errors in the present, I see",
                _=> null
            };
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }
    }
}