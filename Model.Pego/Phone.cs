using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Pego
{
    public class Phone:BaseEntity,IEntity
    {
        public Phone():base()
        {
            this.DateCreated = DateTime.Now;
        }
        public DateTime? DateCreated { get; set; }
        [MaxLength(50)]
        public string Number { get; set; }
        public bool Main { get; set; }
        public Guid PhoneTypeId { get; set; }
        [ForeignKey("PhoneTypeId")]
        public virtual PhoneType PhoneType { get; set; }
        public Guid UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
