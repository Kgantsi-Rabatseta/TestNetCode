using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Model;
using NHibernate;

namespace Data.Repository
{
    public abstract class Repository<T>:IRepository<T> where T:IHasKey
    {
        public void CreateNew(ISession session,T hasKey)
        {
            session.Save(hasKey);
        }

        public T CreateOrModify(ISession session, T entity)
        {
            if (entity.NoKey())
            {
                CreateNew(session, entity);
            }
            else
            {
                Modify(session, entity);
            }
            return ReloadKey(session,entity);
        }

        private T ReloadKey(ISession session,T entity)
        {
            session.Evict(entity);
            return GetByKey(session, entity.Key);
        }

        public T GetByKey(ISession session, Guid key)
        {
            return session.Get<T>(key);
        }

        public void Modify(ISession session, T entity)
        {
            session.Update(entity);
        }

        public IList<T> GetAllKeys(ISession session)
        {
            return session.CreateCriteria(typeof(T)).List<T>();
        }
    }

    public interface IRepository<T>
    {
    }
}
