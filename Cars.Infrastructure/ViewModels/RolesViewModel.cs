using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Cars.Infrastructure.ViewModels
{
    public class RolesViewModel
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
        public bool IsDeleted { get; set; }
        public List<RolesViewModel> Roless { get; set; }

    }
}
