using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Pego
{
   public class Tag: BaseEntity, IEntity
    {
        public Tag():base()
        {
            DateCreated = DateTime.Now;
            this.Projects = new HashSet<Project>();
        }
        public DateTime? DateCreated { get; set; }
        [Required]
        [MaxLength(25)]
        public virtual string Name { get; set; }
        public virtual ICollection<Project> Projects { get; set; }

    }
}
