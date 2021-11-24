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
        Task<IEnumerable<Item>> GetAllAsync(Expression<Func<Item, bool>> expression = null);
        Task<Item> GetAsync(Expression<Func<Item, bool>> expression);
        Task<MutationResult> AddAsync(Item item);
        Task<MutationResult> UpdateAsync(Item item);
        Task<MutationResult> DeleteAsync(Item item);
    }
}
