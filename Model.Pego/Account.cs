using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Pego
{
   public class Account:BaseEntity,IEntity
    {
        public Account():base()
        {
            this.DateCreated = DateTime.Now;
        }
        public DateTime? DateCreated { get; set; }
        [Required]
        [MaxLength(100)]
        public virtual string Name { get; set; }
        [Required]
        [MaxLength(100)]
        public virtual string Number { get; set; }
        public virtual bool Main { get; set; }
        public Guid UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
