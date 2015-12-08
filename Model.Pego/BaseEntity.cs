using System;
using System.ComponentModel.DataAnnotations;

namespace Model.Pego
{
   public abstract class BaseEntity
    {
        public BaseEntity()
        {
            Id = Guid.NewGuid();
        }
        [Key]
        public Guid Id { get; set; }
    }
}
