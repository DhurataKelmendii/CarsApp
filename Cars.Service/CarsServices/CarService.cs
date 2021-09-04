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
    public class CarService
    {

        private readonly CarRepository _carRepository;
        //private readonly IRepository<Car> _repository;


        public CarService(IRepository<Car> repository)
        {
            _carRepository = new CarRepository(repository);

        }

        public async Task<bool> Create(Car car)
        {
            var result = await _carRepository.Create(car);

            return result;
        }

        public async Task<bool> Update(Car car)
        {
            var updatedSuccefully = await _carRepository.Update(car);


            return updatedSuccefully; 
        }

        //public async Task<bool> Delete(Car car)
        //{
        //    _carRepository.Delete(car);

        //    var deleted = await _repository.SaveChangesAsync();

        //    return deleted;
        //}

        public async Task<IList<Car>> GetAll()
        {
            var result = await _carRepository.GetAll();

            return result;
        }

        public async Task<Car> GetById(int id)
        {
            var result = await _carRepository.GetById(id);

            return result;

        }

        public async Task<bool> DeleteCar(int id)
        {
            var deleted = await _carRepository.DeleteCar(id);
            return deleted;
        }
    }
}
