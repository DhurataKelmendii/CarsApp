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
    public class UserService
    {
        private readonly UserRepository _userRepository;
        private readonly IRepository<User> _repository;
        private readonly IRepository<Car> _carRepository;


        public UserService(IRepository<User> userRepository,
            IRepository<Car> carRepository, 
            IRepository<UserCarRel> carUserRepository, 
            CarsDbContext context,
            IRepository<Garage> garageRepository,
            IRepository<CarGarageRel> carGarageRelRepository
            )
        {
            _userRepository = new UserRepository(userRepository, carRepository, carUserRepository, context, garageRepository, carGarageRelRepository);

        }

        public async Task<bool> Create(User user)
        {
            var result = await _userRepository.Create(user);

            return result;
        }

        public async Task<bool> Update(User user)
        {
            var updatedSuccefully = await _userRepository.Update(user);


            return updatedSuccefully;
        }


        public async Task<IList<User>> GetAll()
        {
            var result = await _userRepository.GetAll();

            return result;
        }

        public async Task<User> GetById(int id)
        {
            var result = await _userRepository.GetById(id);

            return result;

        }

        public async Task<bool> DeleteUser(int id)
        {
            var deleted = await _userRepository.DeleteUser(id);
            return deleted;
        }


     
        // User Car Rel
        public List<Car> GetUserCarByUserId(int id)
        {
            var result = _userRepository.GetUserCarsByUserId(id);

            return result;
        }
          public List<UserCarRelViewModel> GetUserCarsListByUserId()
        {
            var result = _userRepository.GetUserCarsListByUserId();

            return result;
        }

        public List<Car> GetUserCars()
        {
            var result = _userRepository.GetUserCars();

            return result;
        }


        public async Task<bool> AddUserForCarFromUser(int carId, int userId)
        {
            var result = await _userRepository.AddUserForCarFromUser(carId, userId);

            return result;
        }

        //Delete User Car//
        public async Task<bool> DeleteCarFromUser(int carId, int userId)
        {
            var deleted = await _userRepository.DeleteUserCar(carId, userId);
            return deleted;
        }



        //Car Garage Rel
        public async Task<bool> AddCarToGarage(int carId, int garageId)
        {
            var result = await _userRepository.AddCarToGarage(carId, garageId);

            return result;
        }

        public List<Car> GetCarFromGarageByUserId(int id)
        {
            var result = _userRepository.GetUserCarsByUserId(id);

            return result;
        }
       


        public async Task<bool> DeleteCarGarage(int carId, int garageId)
        {
            var deleted = await _userRepository.DeleteCarGarage(carId, garageId);
            return deleted;
        }

        public List<CarGarageRelViewModel> GetCarGarageRelation()
        {
            var result =  _userRepository.GetCarGarageRelation();
            return result;
        }
    }
}
