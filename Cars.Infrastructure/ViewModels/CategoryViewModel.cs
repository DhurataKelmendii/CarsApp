using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Domain.Entities
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }

        public bool IsDeleted { get; set; }
        public List<CategoryViewModel> Categories { get; set; }

    }
}
