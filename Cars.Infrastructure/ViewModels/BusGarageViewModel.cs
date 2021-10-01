using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Infrastructure.ViewModels

{
    public class BusGarageViewModel
    {
		public int Id { get; set; }
		public string Name { get; set; }
		public int CapacityOfBuses { get; set; }
		public string Country { get; set; }
		public string City { get; set; }
		public string Street { get; set; }
		public double PricePerDay { get; set; }
		public int BusesUsing { get; set; }
		public bool IsDeleted { get; set; }
		public List<BusGarageViewModel> BusGarages { get; set; }

    }
}
