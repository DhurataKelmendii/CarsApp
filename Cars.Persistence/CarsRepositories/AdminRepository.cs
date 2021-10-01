using Cars.Domain.Entities;
using Cars.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Persistence.CarsRepositories
{
    public class AdminRepository
    {
        //private readonly GarageRepository _garageRepository = new GarageRepository();
        private readonly IRepository<Admin> _adminRepository;

        private readonly CarsDbContext _dbContext;


        public AdminRepository(IRepository<Admin> repository,
            CarsDbContext dbContext
            )
        {
            _adminRepository = repository;

            _dbContext = dbContext;
        }
        public async Task<bool> Create(Admin admin)
        {
            await _adminRepository.Create(admin);

            var savedSuccesfully = await _adminRepository.SaveChangesAsync();

            return savedSuccesfully;

        }

        public async Task<bool> Update(Admin admin)
        {
            _adminRepository.Update(admin);

            var updatedSuccesful = await _adminRepository.SaveChangesAsync();
            return updatedSuccesful;
        }

        public async Task<Admin> GetById(int id)
        {
            var result = await _adminRepository.GetById(id);
            return result;

        }

        public async Task<bool> DeleteAdmin(int id)
        {
            var result = await _adminRepository.GetById(id);
            result.IsDeleted = true;
            var deletedSuccesful = await _adminRepository.SaveChangesAsync();
            return deletedSuccesful;
        }

        public async Task<IList<Admin>> GetAll()
        {
            var result = (await _adminRepository.GetAll()).Where(x => x.IsDeleted == false).ToList();
            return result;
        }

    }

}

