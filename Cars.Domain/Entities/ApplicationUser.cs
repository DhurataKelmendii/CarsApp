using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public int UserId { get; set; }
        public bool IsActive { get; set; }
        public bool isDeleted { get; set; }
    }
}
