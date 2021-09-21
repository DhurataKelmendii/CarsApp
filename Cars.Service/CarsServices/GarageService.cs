using Cars.Domain.Entities;
using Cars.Persistence;
using Cars.Persistence.CarsRepositories;
using Cars.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Service.CarsServices
{
    public class GarageService
    {
        private readonly GarageRepository _garageRepository;

        public GarageService(IRepository<Garage> repository,
            IRepository<Car> carRepository,
            IRepository<CarGarageRel> _carGarageRepository,
            CarsDbContext context)
        {
            _garageRepository = new GarageRepository(repository, carRepository, _carGarageRepository, context);

        }

        public async Task<bool> Create(Garage garage)
        {
            var result = await _garageRepository.Create(garage);

            return result;
        }

        public async Task<bool> Update(Garage garage)
        {
            var updatedSuccefully = await _garageRepository.Update(garage);


            return updatedSuccefully;
        }


        public async Task<IList<Garage>> GetAll()
        {
            var result = await _garageRepository.GetAll();

            return result;
        }

        public async Task<Garage> GetById(int id)
        {
            var result = await _garageRepository.GetById(id);

            return result;

        }

        public async Task<bool> DeleteGarage(int id)
        {
            var deleted = await _garageRepository.DeleteGarage(id);
            return deleted;
        }


    }
}

