using ProjectProgress.Domain;
using ProjectProgress.Domain.DTO.Shared;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProjectProgress.Service.Interface
{
    public interface IUserManager
    {
        Task<MutationResult> CreateUserAsync(AppUser user);
        Task<MutationResult> UpdateUserAsync(AppUser user);
        Task<MutationResult> DeleteUserAsync(AppUser user);
        Task<MutationResult> DeleteUserByIdAsync(int id);
        Task<AppUser> FindUserAsync(Expression<Func<AppUser, bool>> expression);
    }
}
