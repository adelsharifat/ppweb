using ProjectProgress.Domain;
using ProjectProgress.Domain.DTO.Shared;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProjectProgress.Service.Interface
{
    public interface IItemService
    {
        Task<IEnumerable<Item>> GETALL_ASYNC();
        Task<Item> GET_ASYNC(Expression<Func<Item, bool>> expression);
        Task<MutationResult> ADD_ASYNC(Item item);
        Task<MutationResult> UPDATE_ASYNC(Item item);
        Task<MutationResult> DELETE_ASYNC(Item item);
    }
}
