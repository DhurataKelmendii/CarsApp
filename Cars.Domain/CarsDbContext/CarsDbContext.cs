using Microsoft.EntityFrameworkCore;
using Cars.Domain.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace Cars.Persistence
{
    public class CarsDbContext : DbContext
    {
        public CarsDbContext(DbContextOptions<CarsDbContext> options) : base(options)
        {
            //ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Car> Car { get; set; }
        public virtual DbSet<Garage> Garage { get; set; }
        public virtual DbSet<UserCarRel> UserCarRel { get; set; }
        public virtual DbSet<CarGarageRel> CarGarageRel { get; set; }

     
    }
}

