using Cars.Domain.Entities;
using Cars.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Persistence.CarsRepositories
{
    public class RolesRepository
    {
        #region Properties

        private readonly IRepository<Roles> _rolesRepository;

        public RolesRepository(IRepository<Roles> repository)
        {
            _rolesRepository = repository;

        }
        #endregion

        #region Actions

        public async Task<bool> Create(Roles model)
        {
            await _rolesRepository.Create(model);

            var savedSuccessful = await _rolesRepository.SaveChangesAsync();

            return savedSuccessful;
        }

        public async Task<IList<Roles>> GetAll()
        {
            var result = (await _rolesRepository.GetAll()).Where(x => x.IsDeleted == false).ToList();
            return result;
        }


        public async Task<Roles> GetById(int id)
        {
            var user = await _rolesRepository.GetById(id);
            return user;
        }

        public async Task<bool> Update(Roles model)
        {
            _rolesRepository.Update(model);
            var updatedSuccesful = await _rolesRepository.SaveChangesAsync();
            return updatedSuccesful;
        }

        public void Delete(Roles model)
        {
            _rolesRepository.Delete(model);

        }

        public async Task<bool> DeleteRoles(int id)
        {
            var result = await _rolesRepository.GetById(id);
            result.IsDeleted = true;
            var deletedSuccesful = await _rolesRepository.SaveChangesAsync();
            return deletedSuccesful;
        }
        #endregion
    }
}
