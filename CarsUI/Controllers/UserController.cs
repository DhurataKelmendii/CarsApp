using Cars.Domain.Entities;
using Cars.Infrastructure.ViewModels;
using Cars.Persistence;
using Cars.Persistence.Repositories;
using Cars.Service.CarsServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarsUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
     
        private readonly UserService userService;
        private readonly CarService carService;
        private readonly GarageService garageService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public readonly IPasswordHasher<ApplicationUser> _passwordHasher;

        public UserController(IRepository<User> _repository,
            
            IRepository<Car> _carRepository, 
            IRepository<UserCarRel> _carUserRepository,
            CarsDbContext context,
            IRepository<Garage> garageRepository,
            IRepository<CarGarageRel> carGarageRelRepository,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IPasswordHasher<ApplicationUser> passwordHasher)
        {
            userService = new UserService(_repository, _carRepository, _carUserRepository, context, garageRepository, carGarageRelRepository);
            carService = new CarService(_carRepository);
            garageService = new GarageService(garageRepository, _carRepository, carGarageRelRepository, context);
            _userManager = userManager;
            _signInManager = signInManager;
            _passwordHasher = passwordHasher;
  
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("CreateUserApplication")]
        public async Task<IActionResult> CreateUserApplication([FromBody] ApplicationUserViewModel appUser)
        {

            var user = new ApplicationUser()
            {
                UserName = appUser.Email,
                Email = appUser.Email,
                NormalizedEmail = appUser.Email,
                isDeleted = false,
                IsActive = true
            };

            var result = await _userManager.CreateAsync(user, appUser.Password);

            if (result.Succeeded)
            {
                return Ok(true);
            }
            else
            {
                return BadRequest(false);
            }

        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel loginModel)
        {
            var user = await _userManager.FindByEmailAsync(loginModel.Email);


            var loginSuccessful = await _userManager.CheckPasswordAsync(user, loginModel.Password);

            if (loginSuccessful)
            {
                return Ok(true);
            }
            else
            {
                return BadRequest(false);
            }
        }

        [HttpGet]
        [Route("UsersList")]
        public async Task<IActionResult> UsersList()
        {
            var model = new ApplicationUserViewModel();
            var result = (await userService.GetAll()).Select(x => new ApplicationUserViewModel
            {
                Email = x.Email,
         
              
            }).ToList();

            model.Users = result;
            return Ok(model);
        }


        [HttpPost]
        [Route("AddNewUser")]
        public async Task<IActionResult> AddNewUser(User user)
        {
            if (user != null)
            {

                var saveSuccessful = await userService.Create(user);

                if (saveSuccessful)
                {
                    return Ok();
                }

                return BadRequest();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("UpdateUser")]
        public async Task<IActionResult> UpdateUser(User user)
        {
            if (user != null)
            {
                var updated = await userService.Update(user);

                if (updated)
                {
                    return Ok();
                }
                return BadRequest();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("GetUserById/{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            if (id > 0)
            {
                var result = await userService.GetById(id);
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var result = await userService.GetAll();
            return Ok(result);

        }

        [HttpPost]
        [Route("DeleteUser/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {

            var result = await userService.DeleteUser(id);
            return Ok(result);
        }

      
        // User Car Rel
        [HttpGet]
        [Route("UserCarsList")]
        public async Task<IActionResult> UserCarsList()
        {
            var result = userService.GetUserCarsListByUserId();
            return Ok(result);

        }

        [HttpGet]
        [Route("AddCarForUser")]
        public async Task<IActionResult> AddCarForUser()
        {
            var carListResult = (await carService.GetAll()).ToList();

            var userList = (await userService.GetAll()).ToList();

            var carUserRelModel = new UserCarViewModel()
            {
                CarList = carListResult,
                UserList = userList
            };
            return Ok(carUserRelModel);
            
        }
        [HttpPost]
        [Route("AddCarForUser/{carId,userId}")]
        public async Task<ActionResult> AddCarForUser(int carId, int userId)
        {

            var result = await userService.AddUserForCarFromUser(carId, userId);

            if (result)
            {
                var carListResult = (await carService.GetAll()).ToList();

                var userList = (await userService.GetAll()).ToList();

                var userCarRelModel = new UserCarViewModel()
                {
                    CarList = carListResult,
                    UserList = userList
                };
                return Ok(userCarRelModel);
            }

            //return RedirectToAction(nameof(NotFound), "Canot added car for User!");
            return BadRequest();
        }

        //[HttpGet]
        //[Route("GetAllCarsForUserByUserId/{id}")]
        //public async Task<IActionResult> GetAllCarsForUserByUserId(int id)
        //{
        //    var result = userService.GetUserCarByUserId(id);
        //    return Ok(result);

        //}

        //[HttpGet]
        //[Route("GetAllCarsForUsers")]
        //public async Task<IActionResult> GetAllCarsForUsers()
        //{
        //    var result = userService.GetUserCars();
        //    return Ok(result);

        //}
        [HttpPost]
        [Route("DeleteUserCar/{carId}/{userId}")]
        public async Task<IActionResult> DeleteUserCar(int carId, int userId)
        {

            var result = await userService.DeleteCarFromUser(carId, userId);

            var carList = userService.GetUserCarsListByUserId();

            //return RedirectToAction(nameof(UserCarsList), result);
            return Ok(result);
        }



        // Cars To Garage

        [HttpGet]
        [Route("AddCarToGarage")]
        public async Task<IActionResult> AddCarToGarage()
        {
            var carListResult = (await carService.GetAll()).ToList();

            var garageList = (await garageService.GetAll()).ToList();

            var carGarageModel = new CarGarageViewModel()
            {
                CarList = carListResult,
                GarageList = garageList
            };
            return Ok(carGarageModel);

        }


        [HttpPost]
        [Route("AddCarToGarage/{carId}/{garageId}")]
        public async Task<ActionResult> AddCarToGarage(int garageId, int carId)
        {

            var result = await userService.AddCarToGarage(carId, garageId);

            if (result)
            {
                var carListResult = (await carService.GetAll()).ToList();

                var garageList = (await garageService.GetAll()).ToList();

                var carGarageViewModel = new CarGarageViewModel()
                {
                    CarList = carListResult,
                    GarageList = garageList
                };
                return Ok(carGarageViewModel);
            }
            return BadRequest();
            //return RedirectToAction(nameof(NotFound), "Canot added car to Garage!");
        }
     
      

        [HttpGet]
        [Route("CarsGarageList")]
        public async Task<IActionResult> CarsGarageList()
        {

            var result = userService.GetCarGarageRelation();
            return Ok(result);

        }

        [HttpPost]
        [Route("DeleteCarFromGarage/{carId}/{garageId}")]
        public async Task<IActionResult> DeleteCarFromGarage(int carId, int  garageId)
        {
            
            var result = await userService.DeleteCarGarage(carId, garageId);

            var carList = userService.GetCarGarageRelation();

            //return RedirectToAction(nameof(CarsGarageList), result);
            return Ok(result);
        }
    }
}

