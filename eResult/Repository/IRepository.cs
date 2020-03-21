using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace IIT.EResult.Repository
{
    public interface IRepository<T>
    {
        IQueryable<T> GetAll();
        IQueryable<T> Get(Expression<Func<T, bool>> predicate);
        IEnumerable<T> SaveOrUpdateAll(params T[] entities);
        T SaveOrUpdate(T entity);
        int Delete(T entity);
        
        //NHibernate: Named query [that is for calling stored procedure or custom query]
        IList<T> GetNamedQueryResult(string spName, Dictionary<string, string> spParams);
        IList<T> GetCustomQueryResult(string spName, Dictionary<int, string> spParams);
        IList<object> GetQueryResult(string spName, Dictionary<int, string> spParams);
    }
}
