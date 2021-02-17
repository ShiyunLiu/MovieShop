using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace MovieShop.Core.RepositoryInterfaces
{
    public interface IAsyncRepository<T> where T : class // Generic Constraint: restrict T to certain types, here T can only be classes
    {
        //CRUD
        //Reading
        T GetByIdAsync(int Id); // return one record under certain class on corresponding Id
        IEnumerable<T> ListAllAsync(); // return all records under certain class
        IEnumerable<T> ListAsync(Expression<Func<T, bool>> filter); //filter: LINQ - where condition
        int GetCountAsync(Expression<Func<T, bool>> filter=null); //filter=null means default value of filter is null
        bool GetExistingAsync(Expression<Func<T, bool>> filter=null);

        //Creating
        T AddAsync(T entity);

        //Updating
        T UpdateAsync(T entity);

        //Delete
        T DeleteAsync(T entity);
    }
}
