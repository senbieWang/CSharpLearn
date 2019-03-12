using System;

namespace aspnetcoreLearn
{
    internal class ApiResponse<T>
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public Exception Result { get; set; }
    }
}