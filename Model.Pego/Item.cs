using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Model.Pego
{
    public class Item: BaseEntity, IEntity
    {
        public Item():base()
        {
            this.DateCreated = DateTime.Now;
        }
        public DateTime? DateCreated { get; set; }

        public Guid CreatedById { get; set; }
        [ForeignKey("CreatedById")]
        public virtual User CreatedBy { get; set; }
        [MaxLength(500)]
        public string Name { get; set; }
        public string Description { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime? EventDate { get; set; }

        public Guid GeoLocationId { get; set; }
        [ForeignKey("GeoLocationId")]
        public virtual GeoLocation GeoLocation { get; set; }
        public string WebSite { get; set; }
        public int Sum { get; set; }
        public bool Voting { get; set; }
        public DateTime? DateModified { get; set; }
        public Guid ModiefiedById { get; set; }
        [ForeignKey("ModiefiedById")]
        public virtual User ModiefiedBy { get; set; }
        public Guid ProjectId { get; set; }
        [ForeignKey("ProjectId")]
        public virtual Project Project{ get; set; }

    }
}
