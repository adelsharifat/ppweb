using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectProgress.Domain.DTO.Response
{
    public class AttachResponse
    {
        public byte[] FileStream { get; set; }
        public string FileName { get; set; }
        public string Extention { get; set; }
    }
}
