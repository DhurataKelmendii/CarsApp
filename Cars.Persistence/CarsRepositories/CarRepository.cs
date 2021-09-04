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
    public class CarRepository
    {
        #region Properties

        private readonly IRepository<Car> _carRepository;

        public CarRepository(IRepository<Car> repository)
        {
            _carRepository = repository;

        }
        #endregion

        #region Actions

        public async Task<bool> Create(Car model)
        {
            await _carRepository.Create(model);

            var savedSuccessful = await _carRepository.SaveChangesAsync();

            return savedSuccessful;
        }

        public async Task<IList<Car>> GetAll()
        {
            var result = (await _carRepository.GetAll()).Where(x => x.IsDeleted == false).ToList();
            return result;
        }


        public async Task<Car> GetById(int id)
        {
            var user = await _carRepository.GetById(id);
            return user;
        }

        public async Task<bool> Update(Car model)
        {
             _carRepository.Update(model);
            var updatedSuccesful = await _carRepository.SaveChangesAsync();
            return updatedSuccesful;
        }

        public void Delete(Car model)
        {
            _carRepository.Delete(model);
           
        }

        public async Task<bool> DeleteCar(int id)
        {
            var result = await _carRepository.GetById(id);
            result.IsDeleted = true;
            var deletedSuccesful = await _carRepository.SaveChangesAsync();
            return deletedSuccesful;
        } 
        #endregion
    }
}
