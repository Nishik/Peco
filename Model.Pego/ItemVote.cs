using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Pego
{
   public class ItemVote: BaseEntity, IEntity
    {
        public ItemVote(): base()
        {
            this.DateCreated = DateTime.Now;
        }
        public DateTime? DateCreated { get; set; }
        public Guid ItemId { get; set; }
        [ForeignKey("ItemId")]
        public virtual Item Item { get; set;}
        public Guid VoteTypeId { get; set; }
        [ForeignKey("VoteTypeId")]
        public virtual  VoteType VoteType { get; set; }
        public Guid UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }

    }
}
