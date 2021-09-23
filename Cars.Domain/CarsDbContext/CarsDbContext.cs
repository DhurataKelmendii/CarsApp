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
        public virtual DbSet<ApplicationUser> ApplicationUser { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<Place> Place { get; set; }
        public virtual DbSet<BusGarage> BusGarage { get; set; }
        public virtual DbSet<Reservation> Reservation { get; set; }

    }
}

