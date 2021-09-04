using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Domain.Entities
{
    public  class UserCarRel
    {
        [Key]
        public int Id { get; set; }

        //public User User { get; set; }
        [ForeignKey("User")]
        public int? UserId { get; set; }

        //public Car Car { get; set; }
        [ForeignKey("Car")]
        public int? CarId { get; set; }

        public bool IsDeleted { get; set; }
    }
}
