using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProjectProgress.Data.Interface
{
    public interface IRepo<TEntity> where TEntity : class
    {
        Task<TEntity> GET_ASYNC(Expression<Func<TEntity, bool>> expression);
        Task<IEnumerable<TEntity>> FIND_ASYNC(Expression<Func<TEntity, bool>> expression = null,params string[] includes);

        Task CREATE_ASYNC(TEntity entity);
        Task CREATES_ASYNC(IEnumerable<TEntity> entities);

        Task UPDATE_ASYNC(TEntity entity);
        Task UPDATES_ASYNC(IEnumerable<TEntity> entities);
    }
}
