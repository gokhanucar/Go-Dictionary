using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoDictionary.DAL.ORM.Entity
{
    public class WebUser : BaseEntity
    {
        [Required(ErrorMessage = "Lütfen kullanıcı adı giriniz.")]
        [Column(Order = 2)]
        [MaxLength(20, ErrorMessage = "Kullanıcı adı 20 karakterden fazla olamaz.")]
        [Index("UserName_IX", IsUnique = true, Order = 1)]
        public string UserName { get; set; }

        [Column(Order = 3)]
        [Required(ErrorMessage = "Lütfen adınızı giriniz.")]
        [MaxLength(20)]
        public string FirstName { get; set; }

        [Column(Order = 4)]
        [Required(ErrorMessage = "Lütfen soy adınızı giriniz.")]
        [MaxLength(20)]
        public string LastName { get; set; }

        [Column(Order = 5)]
        [MaxLength(100)]
        [Required(ErrorMessage = "Lütfen mail adresinizi giriniz.")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Mail adresinizi hatalı girdiniz")]
        [Index("Email_IX", IsUnique = true, Order = 2)]
        public string Email { get; set; }

        [MaxLength(15)]
        [Column(Order = 6)]
        [Required(ErrorMessage = "Lütfen şifrenizi giriniz.")]
        public string Password { get; set; }

        [MaxLength(10)]
        public string Role { get; set; }

        public virtual ICollection<EntryPost> EntryPosts { get; set; }
    }
}
