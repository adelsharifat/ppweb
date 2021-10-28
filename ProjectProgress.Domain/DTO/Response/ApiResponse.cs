using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectProgress.Domain.DTO.Response
{
    public class ApiResponse
    {
        public ApiResponse()
        {

        }

        public ApiResponse(int statusCode,object payload)
        {
            this.StatusCode = statusCode;
            this.Payload = payload;
        }

        public ApiResponse(int statusCode, params string[] errors)
        {
            this.Error = new List<string>();
            foreach (string error in errors)
            {
                this.Error.Add(error);
            }
            this.StatusCode = statusCode;
        }

        public int StatusCode { get; set; } = 500;
        public object Payload { get; set; } = null;
        public List<string> Error { get; set; } = null;
    }
}
