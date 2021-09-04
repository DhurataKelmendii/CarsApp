using Cars.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Infrastructure.ViewModels
{
    public  class UserCarViewModel
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? CarId { get; set; }
        public List<Car> CarList { get; set; }
        public List<User> UserList { get; set; }

    }
}
