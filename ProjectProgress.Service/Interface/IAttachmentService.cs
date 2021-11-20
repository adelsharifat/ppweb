using ProjectProgress.Domain;
using ProjectProgress.Domain.DTO.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProjectProgress.Service.Interface
{
    public interface IAttachmentService
    {
        Task<IEnumerable<Attachment>> GETALL_ASYNC();
        Task<IEnumerable<Attachment>> Find_ASYNC(Expression<Func<Attachment, bool>> expression);
        Task<Attachment> GET_ASYNC(Expression<Func<Attachment, bool>> expression);
        Task<MutationResult> ADD_ASYNC(Attachment attachment);
        Task<MutationResult> UPDATE_ASYNC(Attachment attachment);
        Task<MutationResult> DELETE_ASYNC(Attachment attachment);
        Task SaveAttachment(Attachment attachment);
    }
}
