using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Domain.Entities
{
    public class RolesViewModel
    {
        public int Id { get; set; }
        public string Role { get; set; }
        public bool IsDeleted { get; set; }
        public List<RolesViewModel> Roles { get; set; }

    }
}
