using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Spatial;
using System.ComponentModel.DataAnnotations;

namespace Model.Pego
{
    public class GeoLocation: BaseEntity
    {
        public GeoLocation():base()
        {
            
        }
        public DbGeography Location { get; set; }
        [MaxLength(500)]
        public string Address { get; set; }
    }
}
