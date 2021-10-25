using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectProgress.Domain.DTO.Shared
{
    public class MutationResult
    {
        public MutationResult(bool successed = false, string error = null)
        {
            this.Successed = successed;
            this.Error = error;
        }
        public bool Successed { get; set; }
        public string Error { get; set; }
    }
}
