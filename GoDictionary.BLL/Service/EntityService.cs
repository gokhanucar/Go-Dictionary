using GoDictionary.BLL.Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoDictionary.BLL.Service
{
    public class EntityService
    {
        private WebUserRepo _webUserService;
        private CategoryRepo _categoryService;
        private EntryPostRepo _entryPostService;

        public EntityService()
        {
            _webUserService = new WebUserRepo();
            _categoryService = new CategoryRepo();
            _entryPostService = new EntryPostRepo();
        }

        public WebUserRepo WebUserService
        {
            get { return _webUserService; }
            set { _webUserService = value; }
        }

        public CategoryRepo CategoryService
        {
            get { return _categoryService; }
            set { _categoryService = value; }
        }

        public EntryPostRepo EntryPostService
        {
            get { return _entryPostService; }
            set { _entryPostService = value; }
        }
    }
}
