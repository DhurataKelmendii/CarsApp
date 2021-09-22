using Cars.Domain.Entities;
using Cars.Persistence.CarsRepositories;
using Cars.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Service.RolesServices
{
    public class RolesService
    {

        private readonly RolesRepository _rolesRepository;
        //private readonly IRepository<Roles> _repository;


        public RolesService(IRepository<Roles> repository)
        {
            _rolesRepository = new RolesRepository(repository);

        }

        public async Task<bool> Create(Roles roles)
        {
            var result = await _rolesRepository.Create(roles);

            return result;
        }

        public async Task<bool> Update(Roles roles)
        {
            var updatedSuccefully = await _rolesRepository.Update(roles);


            return updatedSuccefully;
        }

        //public async Task<bool> Delete(Roles Roles)
        //{
        //    _RolesRepository.Delete(Roles);

        //    var deleted = await _repository.SaveChangesAsync();

        //    return deleted;
        //}

        public async Task<IList<Roles>> GetAll()
        {
            var result = await _rolesRepository.GetAll();

            return result;
        }

        public async Task<Roles> GetById(int id)
        {
            var result = await _rolesRepository.GetById(id);

            return result;

        }

        public async Task<bool> DeleteRoles(int id)
        {
            var deleted = await _rolesRepository.DeleteRoles(id);
            return deleted;
        }
    }
}
