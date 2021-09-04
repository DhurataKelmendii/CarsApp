using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Infrastructure.ViewModels
{
    public class CarViewModel
    {

        public int Id { get; set; }
        //[Required]
        public string Name { get; set; }
        public string Brand { get; set; }
        public int YearOfProduction { get; set; }
        public double Price { get; set; }
        public double NumberOfSeats { get; set; }
        public string EngineType { get; set; }
        public string FuelType { get; set; }
        public string ChassisNumber { get; set; }
        public string Color { get; set; }
        public bool IsDeleted { get; set; }
        public List<CarViewModel> Cars { get; set; }

    }
}
