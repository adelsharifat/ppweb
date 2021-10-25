using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectProgress.Domain.DTO.Response
{
    public class ApiResponse
    {
        public int StatusCode { get; set; } = 500;
        public object Payload { get; set; } = null;
        public List<string> Error { get; set; } = null;
    }
}
