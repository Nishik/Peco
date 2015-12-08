using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Pego
{
    public class UserProject: BaseEntity, IEntity
    {
        public UserProject():base()
        {
            this.DateCreated = DateTime.Now;
        }
        public DateTime? DateCreated { get; set; }
        public Guid UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        public Guid ProjectId { get; set; }
        [ForeignKey("ProjectId")]
        public virtual Project Project { get; set;}
        public Guid ProjectRoleId { get; set; }
        [ForeignKey("ProjectRoleId")]
        public virtual ProjectRole ProjectRole { get; set; }
    }
}
