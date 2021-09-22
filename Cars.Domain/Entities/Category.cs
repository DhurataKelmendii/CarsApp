using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Domain.Entities
{
    public class Category
    {

        [Key]
        public int Id { get; set; }
        public string CategoryName { get; set; }
       
        public bool IsDeleted { get; set; }

    }
}
