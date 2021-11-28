using ProjectProgress.Data;
using ProjectProgress.Data.Interface;
using ProjectProgress.Domain;
using ProjectProgress.Domain.DTO.Shared;
using ProjectProgress.Service.Interface;
using ProjectProgress.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProjectProgress.Service.Service
{
    public class UserManager : IUserManager
    {
        private readonly IUnitOfWork _uw;

        public UserManager(IUnitOfWork unitOfWork)
        {
            _uw = unitOfWork;
        }

        public async Task<AppUser> FindUserAsync(Expression<Func<AppUser, bool>> expression)
        {
            try
            {
                return await _uw.UserRepo.GET_ASYNC(expression);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<MutationResult> CreateUserAsync(AppUser user)
        {
            try
            {
                await _uw.UserRepo.CREATE_ASYNC(user);
                var result =  await _uw.Commit();
                if (result > 0)
                    return new MutationResult(true);
               
                return new MutationResult(false,"Create user faild!");
            }
            catch (Exception ex)
            {
                return ex.DoMutationResult();
            }
        }

        public async Task<MutationResult> DeleteUserByIdAsync(int id)
        {
            try
            {
                var user = await _uw.UserRepo.GET_ASYNC(x => x.Id == id);
                if (user == null) throw new Exception("User not found!");
                await _uw.UserRepo.UPDATE_ASYNC(user);
                var result = await _uw.Commit();

                if (result > 0)
                    return new MutationResult(true);
                return new MutationResult(false, "Deleted user faild");
            }
            catch (Exception ex)
            {
                return ex.DoMutationResult();
            }
        }

        public async Task<MutationResult> DeleteUserAsync(AppUser user)
        {
            try
            {
                if (user == null) throw new Exception("User not found!");
                await _uw.UserRepo.UPDATE_ASYNC(user);
                var result = await _uw.Commit();

                if (result > 0)
                    return new MutationResult(true);

                return new MutationResult(false, "Delete user faild!");
            }
            catch (Exception ex)
            {
                return ex.DoMutationResult();
            }
        }

        public async Task<MutationResult> UpdateUserAsync(AppUser user)
        {
            try
            {
                if (user == null) throw new Exception("User not found!");
                await _uw.UserRepo.UPDATE_ASYNC(user);
                var result = await _uw.Commit();

                if (result > 0) return new MutationResult(true);
                return new MutationResult(false, "Update user faild!");
            }
            catch (Exception ex)
            {
                return ex.DoMutationResult();
            }
        }  
    }
}
