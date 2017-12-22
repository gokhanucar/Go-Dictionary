using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoDictionary.DAL.ORM.Entity;

namespace GoDictionary.DAL.ORM.Context
{
    public class ProjectContext : DbContext
    {
        public ProjectContext() : base("GoDictionaryContext")
        {
        }

        public DbSet<WebUser> WebUser { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<EntryPost> EntryPost { get; set; }
    }
}
