using ProjectProgress.Domain.DTO.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectProgress.Utils
{
    public static class AppExtentions
    {
        public static MutationResult DoMutationResult(this Exception ex)
        {
            return new MutationResult(false, ex.Message);
        }
    }
}
