using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Pego
{
    public class VoteType: BaseEntity
    {
        public VoteType() : base() { }
        [Required]
        [MaxLength(25)]
        public virtual string Name { get; set; }

    }
}
