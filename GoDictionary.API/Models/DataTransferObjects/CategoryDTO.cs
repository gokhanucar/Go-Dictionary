using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoDictionary.API.Models.DataTransferObjects
{
    public class CategoryDTO : BaseDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PublishDate { get; set; }
    }
}