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
    public class EmployeeRepository
    {
        #region Properties

        private readonly IRepository<Employee> _employeeRepository;

        public EmployeeRepository(IRepository<Employee> repository)
        {
            _employeeRepository = repository;

        }
        #endregion

        #region Actions

        public async Task<bool> Create(Employee model)
        {
            await _employeeRepository.Create(model);

            var savedSuccessful = await _employeeRepository.SaveChangesAsync();

            return savedSuccessful;
        }

        public async Task<IList<Employee>> GetAll()
        {
            var result = (await _employeeRepository.GetAll()).Where(x => x.IsDeleted == false).ToList();
            return result;
        }


        public async Task<Employee> GetById(int id)
        {
            var employee = await _employeeRepository.GetById(id);
            return employee;
        }

        public async Task<bool> Update(Employee model)
        {
            _employeeRepository.Update(model);
            var updatedSuccesful = await _employeeRepository.SaveChangesAsync();
            return updatedSuccesful;
        }

        public void Delete(Employee model)
        {
            _employeeRepository.Delete(model);

        }

        public async Task<bool> DeleteEmployee(int id)
        {
            var result = await _employeeRepository.GetById(id);
            result.IsDeleted = true;
            var deletedSuccesful = await _employeeRepository.SaveChangesAsync();
            return deletedSuccesful;
        }
        #endregion
    }
}
