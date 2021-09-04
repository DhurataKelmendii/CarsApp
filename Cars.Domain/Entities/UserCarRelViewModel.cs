using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Domain.Entities
{
    public class UserCarRelViewModel
    {
        public int Id { get; set; }
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

        public string Username { get; set; }
        public int UserId { get; set; }

    }
}
