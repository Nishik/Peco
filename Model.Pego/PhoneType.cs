﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Pego
{
    public class PhoneType: BaseEntity
    {
        public PhoneType():base()
        {
        }
        [Required]
        [MaxLength(50)]
        public virtual string Name { get; set; }
    }
}
