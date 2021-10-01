using Cars.Domain.Entities;
using Cars.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Persistence.CarsRepositories
{
    public class EmployeeRepository
    {
        //private readonly GarageRepository _garageRepository = new GarageRepository();
        private readonly IRepository<Employee> _employeeRepository;
        
        private readonly CarsDbContext _dbContext;


        public EmployeeRepository(IRepository<Employee> repository,
            CarsDbContext dbContext
            )
        {
            _employeeRepository = repository;
           
            _dbContext = dbContext;
        }
        public async Task<bool> Create(Employee employee)
        {
            await _employeeRepository.Create(employee);

            var savedSuccesfully = await _employeeRepository.SaveChangesAsync();

            return savedSuccesfully;

        }

        public async Task<bool> Update(Employee employee)
        {
            _employeeRepository.Update(employee);

            var updatedSuccesful = await _employeeRepository.SaveChangesAsync();
            return updatedSuccesful;
        }

        public async Task<Employee> GetById(int id)
        {
            var result = await _employeeRepository.GetById(id);
            return result;

        }

        public async Task<bool> DeleteEmployee(int id)
        {
            var result = await _employeeRepository.GetById(id);
            result.IsDeleted = true;
            var deletedSuccesful = await _employeeRepository.SaveChangesAsync();
            return deletedSuccesful;
        }

        public async Task<IList<Employee>> GetAll()
        {
            var result = (await _employeeRepository.GetAll()).Where(x => x.IsDeleted == false).ToList();
            return result;
        }
        
    }

}

