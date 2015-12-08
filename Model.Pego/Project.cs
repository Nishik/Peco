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
            this.Tags = new HashSet<Tag>(); //HASH???
            this.Items = new List<Item>();// HASH???
        }

        public DateTime? DateCreated { get; set; }

        public Guid CreatedById { get; set; }
        [ForeignKey("CreatedById")]
        public virtual User CreatedBy { get; set; }
        public DateTime? DateModified { get; set; }
        [MaxLength(250)]
        public string Name { get; set; }
        public int FinalSum { get; set; }
        public int CurrentSum { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
        public Guid ProjectCategoryId { get; set; }
        [ForeignKey("ProjectCategoryId")]
        public virtual ProjectCategory ProjectCategory { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
        public virtual ICollection<Item> Items { get; set; }


    }
}
