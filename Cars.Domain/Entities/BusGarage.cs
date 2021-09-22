using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Domain.Entities
{
	public class BusGarage
	{
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
		public int CapacityOfBuses { get; set; }
		public string Country { get; set; }
		public string City { get; set; }
		public string Street { get; set; }
		public double PricePerDay { get; set; }
		public int BusesUsing { get; set; }
		public bool IsDeleted { get; set; }

	}
}
