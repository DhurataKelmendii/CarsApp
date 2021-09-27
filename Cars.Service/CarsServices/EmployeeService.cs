using Cars.Domain.Entities;
using Cars.Persistence.CarsRepositories;
using Cars.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Service.CarsServices
{
    public class EmployeeService
    {

        private readonly EmployeeRepository _employeeRepository;

        public EmployeeService(IRepository<Employee> repository)
        {
            _employeeRepository = new EmployeeRepository(repository);

        }

        public async Task<bool> Create(Employee employee)
        {
            var result = await _employeeRepository.Create(employee);

            return result;
        }

        public async Task<bool> Update(Employee employee)
        {
            var updatedSuccefully = await _employeeRepository.Update(employee);


            return updatedSuccefully;
        }


        public async Task<IList<Employee>> GetAll()
        {
            var result = await _employeeRepository.GetAll();

            return result;
        }

        public async Task<Employee> GetById(int id)
        {
            var result = await _employeeRepository.GetById(id);

            return result;

        }

        public async Task<bool> DeleteEmployee(int id)
        {
            var deleted = await _employeeRepository.DeleteEmployee(id);
            return deleted;
        }
    }
}
