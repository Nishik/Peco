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
            this.Users = new HashSet<User>();
            this.Projects = new HashSet<Project>();
        }
        public virtual DateTime? DateCreated { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
        public Guid ProjectRoleId { get; set; }
        [ForeignKey("ProjectRoleId")]
        public virtual ProjectRole ProjectRole { get; set; }
    }
}
