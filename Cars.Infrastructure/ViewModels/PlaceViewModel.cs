using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Domain.Entities
{
    public class PlaceViewModel
    {
        public int Id { get; set; }
        public string NamePlace { get; set; }

        public bool IsDeleted { get; set; }

    }
}
