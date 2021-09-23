using Cars.Domain.Entities;
using Cars.Persistence.CarsRepositories;
using Cars.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admins.Service.CarsServices
{
    public class AdminService
    {

        private readonly AdminRepository _adminRepository;

        public AdminService(IRepository<Admin> repository)
        {
            _adminRepository = new AdminRepository(repository);

        }

        public async Task<bool> Create(Admin admin)
        {
            var result = await _adminRepository.Create(admin);

            return result;
        }

        public async Task<bool> Update(Admin admin)
        {
            var updatedSuccefully = await _adminRepository.Update(admin);


            return updatedSuccefully;
        }


        public async Task<IList<Admin>> GetAll()
        {
            var result = await _adminRepository.GetAll();

            return result;
        }

        public async Task<Admin> GetById(int id)
        {
            var result = await _adminRepository.GetById(id);

            return result;

        }

        public async Task<bool> DeleteAdmin(int id)
        {
            var deleted = await _adminRepository.DeleteAdmin(id);
            return deleted;
        }
    }
}
