using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoDictionary.DAL.ORM.Entity
{
    public class BaseEntity
    {
        [Key]
        [Column(Order = 1)]
        public int ID { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? InsertDate { get; set ; }

        [Column(TypeName = "datetime2")]
        public DateTime? UpdateDate { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? DeleteDate { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }
    }
}
