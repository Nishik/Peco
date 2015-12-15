using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// НУЖНО ДОБАВИТЬ IDENTITY

namespace Model.Pego
{
    public class SysRole:BaseEntity, IRole<Guid>
    {
        public SysRole() : base() { }
        [Required]
        [MaxLength(50)]
        public virtual string Name { get; set; }
    }
}
