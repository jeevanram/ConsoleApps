using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Database.Repository.Interface
{
    public interface IBaseRepository<T>
    {
        IQueryable<T> GetAll();
        IQueryable<T> FindByCondition(Expression<Func<T,bool>> condition);
        void Create(T  entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
