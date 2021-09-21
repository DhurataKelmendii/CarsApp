using Cars.Domain.Entities;
using Cars.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Persistence.CarsRepositories
{
    public class UserRepository
    {
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Car> _carRepository;
        private readonly IRepository<UserCarRel> _carUserRepository;
        private readonly IRepository<Garage> _garageRepository;
        private readonly IRepository<CarGarageRel> _carGarageRel;
        private readonly CarsDbContext _dbContext;
        private readonly GarageRepository garageRepository;

        public UserRepository(IRepository<User> userRepository,
            IRepository<Car> carRepository,
            IRepository<UserCarRel> carUserRepository,
            CarsDbContext dbContext,
            IRepository<Garage> gRepository,
            IRepository<CarGarageRel> carGarageRel)
        {
            _userRepository = userRepository;
            _carRepository = carRepository;
            _carUserRepository = carUserRepository;
            _dbContext = dbContext;
            _garageRepository = gRepository;
            _carGarageRel = carGarageRel;
            garageRepository = new GarageRepository(gRepository, carRepository, carGarageRel, dbContext);
        }


        public async Task<bool> Create(User user)
        {
            await _userRepository.Create(user);

            var savedSuccesfully = await _userRepository.SaveChangesAsync();

            return savedSuccesfully;

        }

        public async Task<bool> Update(User user)
        {
            _userRepository.Update(user);

            var updatedSuccesful = await _userRepository.SaveChangesAsync();
            return updatedSuccesful;
        }

        public async Task<User> GetById(int id)
        {
            var result = await _userRepository.GetById(id);
            return result;

        }

        public async Task<bool> DeleteUser(int id)
        {
            var result = await _userRepository.GetById(id);
            result.IsDeleted = true;
            var deletedSuccesful = await _userRepository.SaveChangesAsync();
            return deletedSuccesful;
        }

        public async Task<IList<User>> GetAll()
        {
            var result = (await _userRepository.GetAll()).Where(x => x.IsDeleted == false).ToList();
            return result;
        }



        //User Car Rel

        public async Task<bool> AddUserForCarFromUser(int carId, int userId)
        {
            var carModel = await _carRepository.GetById(carId);

            var userModel = await _userRepository.GetById(userId);

            var checkIfExist = garageRepository.CheckIfUserCarExists(carId, userId);
            if (checkIfExist)
            {
                var userCarRel = new UserCarRel()
                {
                    CarId = carModel.Id,
                    UserId = userModel.Id,
                    IsDeleted = false
                };

                await _carUserRepository.Create(userCarRel);

                var savedSuccessful = await _carUserRepository.SaveChangesAsync();

                return savedSuccessful;
            }
            else
            {
                return false;
            }

            return false;
        }


        
        public List<UserCarRelViewModel> GetUserCarsListByUserId()
        {
            var result = (from carUser in _dbContext.UserCarRel
                          join car in _dbContext.Car
                          on carUser.CarId equals car.Id
                          join user in _dbContext.User
                          on carUser.UserId equals user.Id
                          where car.IsDeleted == false && user.IsDeleted == false && carUser.IsDeleted == false
                          select new UserCarRelViewModel
                          {
                              Id = car.Id,
                              Name = car.Name,
                              Brand = car.Brand,
                              YearOfProduction = car.YearOfProduction,
                              Price = car.Price,
                              NumberOfSeats = car.NumberOfSeats,
                              EngineType = car.EngineType,
                              FuelType = car.FuelType,
                              ChassisNumber = car.ChassisNumber,
                              Color = car.Color,
                              IsDeleted = car.IsDeleted,
                              Username = user.Name,
                              UserId = user.Id,

                          }).ToList();

            return result;
        }


        public async Task<bool> DeleteUserCar(int carId, int userid)
        {
            var result = (from carUser in _dbContext.UserCarRel
                          join car in _dbContext.Car
                          on carUser.CarId equals car.Id
                          join user in _dbContext.User
                          on carUser.UserId equals user.Id
                          where user.Id == userid && car.Id == carId && carUser.IsDeleted == false
                          select carUser).FirstOrDefault();
            if (result != null)
            {
                result.IsDeleted = true;
                var deletedSuccesful = await _carUserRepository.SaveChangesAsync();
                return deletedSuccesful;
            }

            return false;
        }


        //Car Garage Rel
        public async Task<bool> AddCarToGarage(int carId, int garageId)
        {
            var carModel = await _carRepository.GetById(carId);

            var garageModel = await _garageRepository.GetById(garageId);

            var checkIfExistInGarage = garageRepository.CheckIfExistsById(carId, garageId);
            if (checkIfExistInGarage)
            {
                var carGarageRel = new CarGarageRel()
                {
                    CarId = carModel.Id,
                    GarageId = garageModel.Id,
                    IsDeleted = false
                };
                await _carGarageRel.Create(carGarageRel);

                var savedSuccessful = await _carGarageRel.SaveChangesAsync();

                return savedSuccessful;
            }
            else
            {
                return false;
            }

            return false;

        }

        public List<Car> GetCarFromGarageByUserId(int id)
        {
            var result = (from carGarage in _dbContext.CarGarageRel
                          join car in _dbContext.Car
                          on carGarage.CarId equals car.Id
                          join garage in _dbContext.Garage
                          on carGarage.GarageId equals garage.Id
                          where garage.Id == id && car.IsDeleted == false
                          select car).ToList();

            return result;
        }
      

        public List<CarGarageRelViewModel> GetCarGarageRelation()
        {
            var result = (from carGarage in _dbContext.CarGarageRel
                          join car in _dbContext.Car
                          on carGarage.CarId equals car.Id
                          join garage in _dbContext.Garage
                          on carGarage.GarageId equals garage.Id
                          where car.IsDeleted == false && garage.IsDeleted == false && carGarage.IsDeleted == false
                          select new CarGarageRelViewModel
                          {
                              Id = car.Id,
                              Name = car.Name,
                              Brand = car.Brand,
                              YearOfProduction = car.YearOfProduction,
                              Price = car.Price,
                              NumberOfSeats = car.NumberOfSeats,
                              EngineType = car.EngineType,
                              FuelType = car.FuelType,
                              ChassisNumber = car.ChassisNumber,
                              Color = car.Color,
                              IsDeleted = car.IsDeleted,
                              GarageName = garage.Name,
                              GarageId = garage.Id,

                          }).ToList();

            return result;
        }
        

        //Delete Car from Garage
     
        public async Task<bool> DeleteCarGarage(int carId, int garageId)
        {
            var result = (from carGarage in _dbContext.CarGarageRel
                          join car in _dbContext.Car
                          on carGarage.CarId equals car.Id
                          join garage in _dbContext.Garage
                          on carGarage.GarageId equals garage.Id
                          where garage.Id == garageId && car.Id == carId && carGarage.IsDeleted == false
                          select carGarage).FirstOrDefault();
            if (result != null)
            {
                result.IsDeleted = true;
                var deletedSuccesful = await _userRepository.SaveChangesAsync();
                return deletedSuccesful;
            }

            return false;
        }

    }
}
