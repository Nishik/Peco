using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Pego
{
    public class Reminder: BaseEntity, IEntity
    {
        public Reminder():base()
        {
            DateCreated = DateTime.Now;
            this.Users = new HashSet<User>();
        }
        public DateTime? DateCreated { get; set; }
        public Guid CreatedById { get; set; }
        [ForeignKey("CreatedById")]
        public virtual User GreatedBy { get; set; }
        public Guid ProjectId { get; set; }
        [ForeignKey("ProjectId")]
        public virtual Project Project{ get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        [MaxLength(500)]
        public string Title { get; set; }
        //public ALERT
        public virtual ICollection<User> Users { get; set; }
    }
}
