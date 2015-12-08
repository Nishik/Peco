using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Pego
{
    public class UserSettings : BaseEntity, IEntity
    {
        public UserSettings():base()
        {
            DateCreated = DateTime.Now;       
        }

        public DateTime? DateCreated { get; set; }
            public Guid UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
