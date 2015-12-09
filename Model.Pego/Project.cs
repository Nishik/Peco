using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Pego
{
   public class Project: BaseEntity, IEntity
    {
        public Project (): base()
        {
            this.DateCreated = DateTime.Now;
            this.Tags = new HashSet<Tag>(); 
            this.Items = new HashSet<Item>();
            this.UserProjects = new HashSet<UserProject>();
        }

        public DateTime? DateCreated { get; set; }

        public Guid CreatedById { get; set; }
        [ForeignKey("CreatedById")]
        public virtual User CreatedBy { get; set; }
        public virtual DateTime? DateModified { get; set; }
        [MaxLength(250)]
        public virtual string Name { get; set; }
        public virtual int FinalSum { get; set; }
        public virtual int CurrentSum { get; set; }
        public DateTime EndDate { get; set; }
        public virtual string Description { get; set; }
        public Guid ProjectCategoryId { get; set; }
        [ForeignKey("ProjectCategoryId")]
        public virtual ProjectCategory ProjectCategory { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
        public virtual ICollection<Item> Items { get; set; }
        public virtual ICollection<UserProject> UserProjects { get; set; }


    }
}
