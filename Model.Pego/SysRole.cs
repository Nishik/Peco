using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Pego
{
    public class SysRole:BaseEntity
    {
        public SysRole() : base() { }
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
