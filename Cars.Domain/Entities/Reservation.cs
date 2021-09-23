using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Domain.Entities
{
    public class Reservation
    {
		[Key]
		public int Id { get; set; }
		public string RezervationName { get; set; }
		public string RezervationStartDate { get; set; }
		public string RezervationEndDate { get; set; }
		public int TotalBill { get; set; }
		public string GarageName { get; set; }
		public int CarsUsing { get; set; }
		public bool IsDeleted { get; set; }
	}
}
