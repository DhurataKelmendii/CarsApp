using Cars.Domain.Entities;
using Cars.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Persistence.CarsRepositories
{
    public class RolesRepository
    {
        //private readonly GarageRepository _garageRepository = new GarageRepository();
        private readonly IRepository<Roles> _rolesRepository;

        private readonly CarsDbContext _dbContext;


        public RolesRepository(IRepository<Roles> repository,
            CarsDbContext dbContext
            )
        {
            _rolesRepository = repository;

            _dbContext = dbContext;
        }
        public async Task<bool> Create(Roles roles)
        {
            await _rolesRepository.Create(roles);

            var savedSuccesfully = await _rolesRepository.SaveChangesAsync();

            return savedSuccesfully;

        }

        public async Task<bool> Update(Roles roles)
        {
            _rolesRepository.Update(roles);

            var updatedSuccesful = await _rolesRepository.SaveChangesAsync();
            return updatedSuccesful;
        }

        public async Task<Roles> GetById(int id)
        {
            var result = await _rolesRepository.GetById(id);
            return result;

        }

        public async Task<bool> DeleteRoles(int id)
        {
            var result = await _rolesRepository.GetById(id);
            result.IsDeleted = true;
            var deletedSuccesful = await _rolesRepository.SaveChangesAsync();
            return deletedSuccesful;
        }

        public async Task<IList<Roles>> GetAll()
        {
            var result = (await _rolesRepository.GetAll()).Where(x => x.IsDeleted == false).ToList();
            return result;
        }

    }

}

