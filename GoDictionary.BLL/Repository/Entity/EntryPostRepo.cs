using GoDictionary.BLL.Repository.Base;
using GoDictionary.DAL.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoDictionary.BLL.Repository.Entity
{
    public class EntryPostRepo : BaseRepository<EntryPost>
    {
        public override int Insert(EntryPost entity)
        {
            try
            {
                entity.IsActive = true;
                entity.IsDeleted = false;
                entity.InsertDate = DateTime.Now;
                entity.Like = 0;
                entity.Dislike = 0;
                dbSet.Add(entity);
                return this.Save();
            }
            catch
            {
                return 0;
            }
        }

        public int UpdateLikeCount(int id)
        {
            if (id == 0)
                return 0;

            try
            {
                EntryPost oldEntity = dbSet.Find(id);
                if (oldEntity.ID == 0)
                    return 0;

                oldEntity.Like++;
                return base.Update(oldEntity);                                                
            }
            catch
            {
                return 0;
            }
        }

        public int UpdateDislikeCount(int id)
        {
            if (id == 0)
                return 0;

            try
            {
                EntryPost oldEntity = dbSet.Find(id);
                if (oldEntity.ID == 0)
                    return 0;

                oldEntity.Dislike++;
                return base.Update(oldEntity);
            }
            catch
            {
                return 0;
            }
        }
    }
}
