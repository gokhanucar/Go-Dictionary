using GoDictionary.BLL.Repository.Base;
using GoDictionary.DAL.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoDictionary.BLL.Repository.Entity
{
    public class WebUserRepo : BaseRepository<WebUser>
    {
        public bool CheckCredential(string userName, string password)
        {
            return dbSet.Any(user => user.UserName == userName && user.Password == password);
        }

        public WebUser FindByEmail(string email)
        {
            return dbSet.FirstOrDefault(user => user.Email == email);
        }

        public bool ExistingUserName(string userName)
        {
            return dbSet.Any(user => user.UserName == userName);
        }

        public bool ExistingEmail(string email)
        {
            return dbSet.Any(user => user.Email == email);
        }

        public string[] GetRolesForUser(int ID)
        {
            var role = dbSet.FirstOrDefault(user => user.ID == ID).Role;

            return new string[] { role };
        }

        public string GetRoleByUserID(int ID)
        {
            return dbSet.FirstOrDefault(user => user.ID == ID).Role;
        }

        public string GetRoleByUserName(string userName)
        {
            return dbSet.FirstOrDefault(user => user.UserName == userName).Role;
        }


        //public List<EntryPost> GetUserEntries(int ID)
        //{
        //    WebUser currentUser = dbSet.Find(ID);

        //    List<EntryPost> userEntries = dbSet.Where(user => user.ID == currentUser.ID).Select(user => new WebUser
        //    {
        //        EntryPosts = user.EntryPosts
        //    }).ToList();          
        //}
    }
}
