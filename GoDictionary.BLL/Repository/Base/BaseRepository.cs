using GoDictionary.DAL.ORM.Context;
using GoDictionary.DAL.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GoDictionary.BLL.Repository.Base
{
    public class BaseRepository<T> where T : BaseEntity
    {
        private ProjectContext context;
        protected DbSet<T> dbSet;

        public BaseRepository()
        {
            context = new ProjectContext();
            dbSet = context.Set<T>();
        }

        public int Save()
        {
            return context.SaveChanges();
        }

        public virtual int Insert(T entity)
        {
            try
            {
                entity.IsActive = true;
                entity.IsDeleted = false;
                entity.InsertDate = DateTime.Now;
                dbSet.Add(entity);
                return this.Save();
            }
            catch
            {
                return 0;
            }
        }

        public virtual int InsertMany(ICollection<T> entities)
        {
            try
            {
                foreach(var entity in entities)
                {
                    entity.IsActive = true;
                    entity.IsDeleted = false;
                    entity.InsertDate = DateTime.Now;
                    dbSet.Add(entity);
                }
                return this.Save();
            }
            catch
            {
                return 0;
            }
        }

        public virtual int Update(T updatedEntity)
        {
            if (updatedEntity.ID == 0)
                return 0;

            try
            {
                T oldEntity = dbSet.Find(updatedEntity.ID);
                if (oldEntity.ID == 0)
                    return 0;

                updatedEntity.UpdateDate = DateTime.Now;
                updatedEntity.InsertDate = oldEntity.InsertDate;
                updatedEntity.DeleteDate = oldEntity.DeleteDate;
                updatedEntity.IsActive = oldEntity.IsActive;
                updatedEntity.IsDeleted = oldEntity.IsDeleted;

                context.Entry(oldEntity).CurrentValues.SetValues(updatedEntity);
                return this.Save();
            }
            catch
            {
                return 0;
            }
        }

        public virtual int Delete(int? ID)
        {
            T entity = dbSet.Find(ID);
            entity.DeleteDate = DateTime.Now;
            entity.IsActive = false;
            entity.IsDeleted = true;

            return this.Save();
        }

        public virtual int SuperDelete(int? ID)
        {
            T entity = dbSet.Find(ID);
            dbSet.Remove(entity);

            return this.Save();
        }

        public virtual int Revert(int? ID)
        {
            T entity = dbSet.Find(ID);

            entity.IsActive = true;
            entity.IsDeleted = false;

            return this.Save();
        }

        public List<T> SelectAll()
        {
            return dbSet.ToList();
        }

        public List<T> SelectByState(bool activeState, bool? deleteState = false)
        {
            return dbSet.Where(entity => entity.IsActive == activeState && entity.IsDeleted == deleteState).ToList();
        }

        public List<T> SelectByCondition(Expression<Func<T, bool>> predicate)
        {
            return dbSet.Where(entity => entity.IsActive == true && entity.IsDeleted == false).Where(predicate).ToList();
        }

        public List<T> SelectByCondition(Expression<Func<T, bool>> predicate, bool? activeState = true, bool? deleteState = false)
        {
            if (activeState == true && deleteState == false)
            {
                return this.SelectByCondition(predicate);
            }

            return dbSet.Where(entity => entity.IsActive == activeState && entity.IsDeleted == deleteState)
                .Where(predicate).ToList();
        }

        public List<T> SelectAsTransferable(int ID)
        {
            return dbSet.Where(entity => entity.ID == ID).ToList();
        }

        public T SelectFirst(Expression<Func<T, bool>> predicate)
        {
            return dbSet.FirstOrDefault(predicate);
        }
    }
}
