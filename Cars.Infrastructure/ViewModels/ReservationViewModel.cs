using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Infrastructure.ViewModels
{
    public class ReservationViewModel
    {
		public int Id { get; set; }
		public string RezervationName { get; set; }
		public string RezervationStartDate { get; set; }
		public string RezervationEndDate { get; set; }
		public int TotalBill { get; set; }
		public string GarageName { get; set; }
		public int CarsUsing { get; set; }
		public bool IsDeleted { get; set; }

		public List<ReservationViewModel> Reservations { get; set; }
	}
}
