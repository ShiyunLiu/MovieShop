using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MovieShop.Core.RepositoryInterfaces
{
    public interface IAsyncRepository<T> where T : class // Generic Constraint: restrict T to certain types, here T can only be classes
    {
        //CRUD
        //Reading
        Task<T> GetByIdAsync(int Id); // return one record under certain class on corresponding Id
        Task<IEnumerable<T>> ListAllAsync(); // return all records under certain class
        Task<IEnumerable<T>> ListAsync(Expression<Func<T, bool>> filter); //filter: LINQ - where condition
        Task<int> GetCountAsync(Expression<Func<T, bool>> filter = null); //filter=null means default value of filter is null
        Task<bool> GetExistingAsync(Expression<Func<T, bool>> filter = null);

        //Creating
        Task<T> AddAsync(T entity);

        //Updating
        Task<T> UpdateAsync(T entity);

        //Delete
        Task<T> DeleteAsync(T entity);
        
    }
}
