using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Pego
{
    public class Chat:BaseEntity, IEntity
    {
        public Chat(): base()
        {
            this.DateCreated = DateTime.Now;
            this.Messages = new List<Message> ();
        }

        public DateTime? DateCreated { get; set; }
        public Guid CreatedById { get; set; }
        [ForeignKey("CreatedById")]
        public virtual User CreatedBy { get; set; }
        public Guid ProjectId { get; set; }
        [ForeignKey("ProjectId")]
        public virtual Project Project { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
        [MaxLength(500)]
        public string Title { get; set; }
    }
}
