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
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int NumberOfGarages { get; set; }
        public bool IsDeleted { get; set; }

    }
}
