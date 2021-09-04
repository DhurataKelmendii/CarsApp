using Cars.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Infrastructure.ViewModels
{
    public class CarGarageViewModel
    {
        public int Id { get; set; }
        public int? CarId { get; set; }
        public int? GarageId { get; set; }
        public bool IsDeleted { get; set; }
        public List<Car> CarList { get; set; }
        public List<Garage> GarageList { get; set; }

        //public List<CarGarageRel> CarGarageList { get; set; }
    }
}
