using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Pego
{
    public class Email:BaseEntity,IEntity
    {
        public Email():base()
        {
            this.DateCreated = DateTime.Now;
        }
        public DateTime? DateCreated { get; set; }
        [MaxLength(150)]
        public string Name { get; set; }
        public bool Main { get; set; }
        public Guid UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        public Guid EmailTypeId { get; set; }
        [ForeignKey("EmailTypeId")]
        public virtual EmailType EmailType { get; set; }
    }
}
