using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoDictionary.API.Models.DataTransferObjects
{
    public class EntryPostDTO : BaseDTO
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Summary { get; set; }
        public string ImagePath { get; set; }
        public string Link { get; set; }
        public int Like { get; set; }
        public int Dislike { get; set; }
        public DateTime PostDate { get; set; }

        public int CategoryID { get; set; }
        public int WebUserID { get; set; }
    }
}