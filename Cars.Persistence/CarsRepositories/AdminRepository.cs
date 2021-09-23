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
    public class AdminRepository
    {
        #region Properties

        private readonly IRepository<Admin> _adminRepository;

        public AdminRepository(IRepository<Admin> repository)
        {
            _adminRepository = repository;

        }
        #endregion

        #region Actions

        public async Task<bool> Create(Admin model)
        {
            await _adminRepository.Create(model);

            var savedSuccessful = await _adminRepository.SaveChangesAsync();

            return savedSuccessful;
        }

        public async Task<IList<Admin>> GetAll()
        {
            var result = (await _adminRepository.GetAll()).Where(x => x.IsDeleted == false).ToList();
            return result;
        }


        public async Task<Admin> GetById(int id)
        {
            var Admin = await _adminRepository.GetById(id);
            return Admin;
        }

        public async Task<bool> Update(Admin model)
        {
            _adminRepository.Update(model);
            var updatedSuccesful = await _adminRepository.SaveChangesAsync();
            return updatedSuccesful;
        }

        public void Delete(Admin model)
        {
            _adminRepository.Delete(model);

        }

        public async Task<bool> DeleteAdmin(int id)
        {
            var result = await _adminRepository.GetById(id);
            result.IsDeleted = true;
            var deletedSuccesful = await _adminRepository.SaveChangesAsync();
            return deletedSuccesful;
        }
        #endregion
    }
}
