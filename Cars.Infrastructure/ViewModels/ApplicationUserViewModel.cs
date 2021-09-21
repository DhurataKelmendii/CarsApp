using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Infrastructure.ViewModels
{
    public class ApplicationUserViewModel
    {
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public bool isDeleted { get; set; }
        public bool IsActive { get; set; }
       
    }
}
