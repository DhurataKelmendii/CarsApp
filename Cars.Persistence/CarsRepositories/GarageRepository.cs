using Cars.Domain.Entities;
using Cars.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Persistence.CarsRepositories
{
    public class GarageRepository
    {
        private readonly IRepository<Garage> _garageRepository;
        private readonly IRepository<Car> _carRepository;
        private readonly IRepository<CarGarageRel> _carGarageRepository;
        private readonly CarsDbContext _dbContext;
       


        public GarageRepository(IRepository<Garage> repository,
            IRepository<Car> carRepository,
            IRepository<CarGarageRel> carGarageRepository,
            CarsDbContext dbContext
            )
        {
            _garageRepository = repository;
            _carRepository = carRepository;
            _carGarageRepository = carGarageRepository;
            _dbContext = dbContext;
        }


        public async Task<bool> Create(Garage garage)
        {
            await _garageRepository.Create(garage);

            var savedSuccesfully = await _garageRepository.SaveChangesAsync();

            return savedSuccesfully;

        }

        public async Task<bool> Update(Garage garage)
        {
            _garageRepository.Update(garage);

            var updatedSuccesful = await _garageRepository.SaveChangesAsync();
            return updatedSuccesful;
        }

        public async Task<Garage> GetById(int id)
        {
            var result = await _garageRepository.GetById(id);
            return result;

        }

        public async Task<bool> DeleteGarage(int id)
        {
            var result = await _garageRepository.GetById(id);
            result.IsDeleted = true;
            var deletedSuccesful = await _garageRepository.SaveChangesAsync();
            return deletedSuccesful;
        }

        public async Task<IList<Garage>> GetAll()
        {
            var result = (await _garageRepository.GetAll()).Where(x => x.IsDeleted == false).ToList();
            return result;
        }



        // Cars in Garage
        public async Task<bool> AddCarAtGarage(int carId, int garageId)
        {
            var carModel = await _garageRepository.GetById(carId);//get gar form db

            //await _garageRepository.SaveChangesAsync();

            var carGarageRel = new CarGarageRel();
            carGarageRel.CarId = carModel.Id;
            carGarageRel.GarageId = garageId;
            carGarageRel.IsDeleted = false;

            await _carGarageRepository.Create(carGarageRel);

            var savedSuccessful = await _garageRepository.SaveChangesAsync();

            return savedSuccessful;

        }

        public List<Car> GetCarsOfGarageByGarageId(int id)
        {
            var result = (from carGarage in _dbContext.CarGarageRel
                          join car in _dbContext.Car
                          on carGarage.CarId equals car.Id
                          join garage in _dbContext.Garage
                          on carGarage.GarageId equals garage.Id
                          where garage.Id == id && car.IsDeleted == false && carGarage.IsDeleted == false
                          select car).ToList();

            return result;
        }

        public async Task<bool> DeleteCarInGarage(int garageId)
        {
            var cars = GetGarageRelCarsInGarageById(garageId);

            var result = await UpdateRange(cars);

            return result;
        }

        public async Task<bool> UpdateRange(List<CarGarageRel> list)
        {
            var saveAll = new List<bool>();
            foreach (var item in list)
            {
                item.IsDeleted = true;
                _carGarageRepository.Update(item);

                var updateSuccessful = await _carGarageRepository.SaveChangesAsync();
                saveAll.Add(updateSuccessful);
            }
            if (saveAll.Contains(false))
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        public List<CarGarageRel> GetGarageRelCarsInGarageById(int id)
        {
            var result = (from carGarage in _dbContext.CarGarageRel
                          join car in _dbContext.Car
                          on carGarage.CarId equals car.Id
                          join garage in _dbContext.Garage
                          on carGarage.GarageId equals garage.Id
                          where garage.Id == id && car.IsDeleted == false
                          select carGarage).ToList();

            return result;
           

        }

        public bool CheckIfExistsById(int carId, int garageId)
        {

            var result = (from carGarage in _dbContext.CarGarageRel
                          join car in _dbContext.Car
                          on carGarage.CarId equals car.Id
                          join garage in _dbContext.Garage
                          on carGarage.GarageId equals garage.Id
                          where garage.Id == garageId && car.Id == carId && carGarage.IsDeleted == false
                          select carGarage).ToList().Count;

            return result == 0 ? true : false;
        }

        public bool CheckIfUserCarExists(int carId, int userId)
        {

            var result = (from carUser in _dbContext.UserCarRel
                          join car in _dbContext.Car
                          on carUser.CarId equals car.Id
                          join user in _dbContext.User
                          on carUser.UserId equals user.Id
                          where user.Id == userId && car.Id == carId && carUser.IsDeleted == false
                          select carUser).ToList().Count;

            return result == 0 ? false : true;
        }
    }

}

