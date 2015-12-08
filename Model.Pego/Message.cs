using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Pego
{
   public class Message : BaseEntity, IEntity
    {
        public Message(): base()
        {
            this.DateCreated = DateTime.Now;
        }
        public DateTime? DateCreated { get; set; }

        public Guid ChatId { get; set; }
        [ForeignKey("ChatId")]
        public virtual Chat Chat { get; set; }
        public string Text { get; set; }

        public Guid CreatedById { get; set; }
        [ForeignKey("CreatedById")]
        public virtual User CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
