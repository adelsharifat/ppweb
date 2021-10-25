using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjectProgress.Data.Interface
{
    public interface IUnitOfWork:IDisposable
    {
        IUserRepo UserRepo { get; }
        IRoleRepo RoleRepo { get; }
        IUserRoleRepo UserRoleRepo { get; }
        ITokenRepo TokenRepo { get; }
        Task<int> Commit();

    }
}
