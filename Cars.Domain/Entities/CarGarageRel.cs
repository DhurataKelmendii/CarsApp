using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Domain.Entities
{
    public class CarGarageRel
    {
        [Key]
        public int Id { get; set; }
     
        //public Garage Garage { get; set; }
        [ForeignKey("Garage")]
        public int? GarageId { get; set; }

        //public Car Car { get; set; }
        [ForeignKey("Car")]
        public int? CarId { get; set; }
        public bool IsDeleted { get; set; }

    }
}
