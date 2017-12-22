using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoDictionary.DAL.ORM.Entity
{
    public class EntryPost : BaseEntity
    {
        [MaxLength(100, ErrorMessage = "Başlığınız 100 karakterden uzun olamaz.")]
        [Column(Order = 2)]
        public string Title { get; set; }

        [MaxLength(3000)]
        [Required(ErrorMessage = "Lütfen entry'nizi boş geçmeyiniz.")]
        public string Content { get; set; }

        [MaxLength(400)]
        public string Summary { get; set; }

        public string ImagePath { get; set; }

        public string Link { get; set; }

        public int Like { get; set; }
        public int Dislike { get; set; }

        [ForeignKey("WebUser")]
        public int WebUserID { get; set; }
        public virtual WebUser WebUser { get; set; }

        [ForeignKey("Category")]
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
    }
}
