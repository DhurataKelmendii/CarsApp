using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Cars.Domain.Entities;

namespace Cars.Persistence
{
    public interface ICarsDbContext
    {
        DbSet<User> User { get; set; }
        DbSet<Car> Car { get; set; }
        DbSet<Garage> Garage { get; set; }
        DbSet<UserCarRel> UserCarRel { get; set; }
        DbSet<CarGarageRel> CarGarageRel { get; set; }
    
    }
}


