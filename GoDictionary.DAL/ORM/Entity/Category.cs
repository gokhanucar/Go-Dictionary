using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoDictionary.DAL.ORM.Entity
{
    public class Category : BaseEntity
    {
        [Required(ErrorMessage = "Kategori için lütfen başlık giriniz.")]
        [MaxLength(50, ErrorMessage = "Kategori başlığı için en fazla 50 karakter giriniz.")]
        [Column(Order = 2)]
        public string Title { get; set; }

        [Column(Order = 3)]
        [MaxLength(300)]
        public string Description { get; set; }

        public virtual ICollection<EntryPost> EntryPosts { get; set; }
    }
}
