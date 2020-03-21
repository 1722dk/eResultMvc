using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using IIT.EResult.Modules;
using NHibernate;
using NHibernate.Linq;
using NHibernate.Transform;

namespace IIT.EResult.Repository
{
    public class Repository<T> : IRepository<T>
    {
        private readonly ISession _session;

        public Repository()
        {
            _session = PersistenceSessionManager.GetCurrentSession();
        }

        public IQueryable<T> GetAll()
        {
            return _session.Query<T>();
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return GetAll().Where(predicate);
        }

        public IEnumerable<T> SaveOrUpdateAll(params T[] entities)
        {
            ITransaction transaction = _session.BeginTransaction();
            //using (var transaction = _Session.BeginTransaction())
            //{
            try
            {
                foreach (var entity in entities)
                {
                    _session.SaveOrUpdate(entity);
                }
                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
            }
            finally
            {
                transaction.Dispose();
                PersistenceSessionManager.DisposeCurrentSession();
            }
            //}
            return entities;
        }

        public T SaveOrUpdate(T entity)
        {
            ITransaction transaction = _session.BeginTransaction();
            //using (var transaction = _Session.BeginTransaction())
            //{
            try
            {
                _session.SaveOrUpdate(entity);

                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
            }
            finally
            {
                transaction.Dispose();
                PersistenceSessionManager.DisposeCurrentSession();
            }
            //}
            return entity;
        }

        //public T IsNew(T entity)
        //{
        //    try
        //    {

        //    }
        //    catch (Exception)
        //    {

        //    }
        //    return entity;
        //}

        public int Delete(T entity)
        {
            ITransaction transaction = _session.BeginTransaction();
            int result = 1;
            //using (var transaction = _Session.BeginTransaction())
            //{
            try
            {
                _session.Delete(entity);

                transaction.Commit();
            }
            catch (Exception)
            {
                result = -1;
                transaction.Rollback();
            }
            finally
            {
                transaction.Dispose();
                PersistenceSessionManager.DisposeCurrentSession();
            }
            //}
            return result;
        }
        
        public IList<object> GetQueryResult(string spName, Dictionary<int, string> spParams)
        {
            var sqlQuery = _session.CreateSQLQuery(spName);
            foreach (var pair in spParams)
            {
                sqlQuery.SetParameter(pair.Key, pair.Value);
            }
            var lists = sqlQuery.List<object>();
            return lists;
        }

        //Exception Details: Error while convertion of Nhibernate query to generic list
        public IList<T> GetCustomQueryResult(string spName, Dictionary<int, string> spParams)
        {
            var sqlQuery = _session.CreateSQLQuery(spName);
            foreach (var pair in spParams)
            {
                sqlQuery.SetParameter(pair.Key, pair.Value);
            }
            //sqlQuery.SetResultTransformer(Transformers.AliasToBean<T>());
            //var lists = sqlQuery.List();

            var lists = sqlQuery.List<T>();
            return lists;

            //var list = _session.CreateSQLQuery("exec GetStudentForResultEntry ?, ?")
            //                   .AddEntity(typeof (T))
            //                   .SetString(0, courseId)
            //                   .SetString(1, batchNo)
            //                   .List<T>();
            //return list;
        }

        //Exception Details: NHibernate.MappingException: Named query not known: GetStudentForResultEntry
        public IList<T> GetNamedQueryResult(string spName, Dictionary<string, string> spParams)
        {
            //Exception: Named query not known??
            IQuery namedQuery = _session.GetNamedQuery(spName);
            foreach (var pair in spParams)
            {
                namedQuery.SetParameter(pair.Key, pair.Value);
            }
            var queryResult = namedQuery.List<T>();
            return queryResult;
        }
    }
}
