using Cars.Domain.Entities;
using Cars.Persistence.CarsRepositories;
using Cars.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Service.CarsServices
{
    public class EmployeeService
    {

        private readonly EmployeeRepository _employeeRepository;
        //private readonly IRepository<Employee> _repository;


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

        //public async Task<bool> Delete(Employee Employee)
        //{
        //    _EmployeeRepository.Delete(Employee);

        //    var deleted = await _repository.SaveChangesAsync();

        //    return deleted;
        //}

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
