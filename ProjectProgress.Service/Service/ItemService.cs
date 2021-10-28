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

        public async Task<IEnumerable<Item>> GETALL_ASYNC()
        {
            try
            {
                return await _unitOfWork.ItemRepo.FIND_ASYNC();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Item> GET_ASYNC(Expression<Func<Item, bool>> expression)
        {
            try
            {
                return await _unitOfWork.ItemRepo.GET_ASYNC(expression);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<MutationResult> ADD_ASYNC(Item item)
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

        public async Task<MutationResult> UPDATE_ASYNC(Item item)
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

        public async Task<MutationResult> DELETE_ASYNC(Item item)
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
