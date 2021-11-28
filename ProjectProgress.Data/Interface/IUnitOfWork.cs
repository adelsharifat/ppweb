using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjectProgress.Data.Interface
{
    public interface IUnitOfWork
    {
        IUserRepo UserRepo { get; }
        ITokenRepo TokenRepo { get; }
        IItemRepo ItemRepo { get; }
        IAttachmentRepo AttachmentRepo { get; }
        Task<int> Commit();

    }
}
