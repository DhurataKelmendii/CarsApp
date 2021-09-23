using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Cars.Domain.Entities;

namespace Cars.Persistence
{
    public interface ICarsDbContext
    {
        DbSet<User> User { get; set; }
        DbSet<Employee> Employee { get; set; }
        DbSet<Car> Car { get; set; }
        DbSet<Garage> Garage { get; set; }
        DbSet<UserCarRel> UserCarRel { get; set; }
        DbSet<CarGarageRel> CarGarageRel { get; set; }
        DbSet<ApplicationUser> ApplicationUser { get; set; }
        DbSet<Roles> Roles { get; set; }
        DbSet<Category> Category { get; set; }
        DbSet<Bus> Bus { get; set; }
        DbSet<Admin> Admin { get; set; }
        DbSet<Place> Place { get; set; }
        DbSet<BusGarage> BusGarage { get; set; }
        DbSet<Reservation> Reservation { get; set; }

    }
}


