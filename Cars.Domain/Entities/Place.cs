using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Domain.Entities
{
    public class Place
    {

        [Key]
        public int Id { get; set; }
        public string NamePlace { get; set; }
 
        public bool IsDeleted { get; set; }

    }
}
