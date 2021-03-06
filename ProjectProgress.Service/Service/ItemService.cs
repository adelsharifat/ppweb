using ProjectProgress.Data.Interface;
using ProjectProgress.Domain;
using ProjectProgress.Domain.DTO.Shared;
using ProjectProgress.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProjectProgress.Service.Service
{
    public class ItemService : IItemService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ItemService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Item>> GetAllAsync(Expression<Func<Item, bool>> expression = null)
        {
            try
            {
                if(expression == null) return await _unitOfWork.ItemRepo.FIND_ASYNC(null,"Items","Attachments");
                return await _unitOfWork.ItemRepo.FIND_ASYNC(expression);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Item> GetAsync(Expression<Func<Item, bool>> expression)
        {
            try
            {
                var a = await _unitOfWork.ItemRepo.GET_ASYNC(expression);
                return a;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<MutationResult> AddAsync(Item item)
        {
            try
            {
                await _unitOfWork.ItemRepo.CREATE_ASYNC(item);
                var result = await _unitOfWork.Commit();
                if (result > 0) return new MutationResult(true);
                return new MutationResult(false, "Add item faild");
            }
            catch (Exception ex)
            {
                return new MutationResult(false, ex.Message);
            }
        }

        public async Task<MutationResult> UpdateAsync(Item item)
        {
            try
            {
                await _unitOfWork.ItemRepo.UPDATE_ASYNC(item);
                var result = await _unitOfWork.Commit();
                if (result > 0) return new MutationResult(true);
                return new MutationResult(false, "Update item faild");
            }
            catch (Exception ex)
            {
                return new MutationResult(false, ex.Message);
            }
        }

        public async Task<MutationResult> DeleteAsync(Item item)
        {
            try
            {
                await _unitOfWork.ItemRepo.UPDATE_ASYNC(item);
                var result = await _unitOfWork.Commit();
                if (result > 0) return new MutationResult(true);
                return new MutationResult(false, "Delete item faild");
            }
            catch (Exception ex)
            {
                return new MutationResult(false, ex.Message);
            }
        }

    }
}
