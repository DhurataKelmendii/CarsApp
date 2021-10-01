using Cars.Domain.Entities;
using Cars.Infrastructure.ViewModels;
using Cars.Persistence.Repositories;
using Cars.Service.CarsServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarsUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : Controller
    {
        private readonly CarService carService;

        public CarController(IRepository<Car> repository)
        {
            carService = new CarService(repository);
        }

        [HttpGet]
        [Route("CarsList")]
        public async Task<IActionResult> CarsList()
        {
            var model = new CarViewModel();
            var result = (await carService.GetAll()).Select(x => new CarViewModel
            {
                Name = x.Name,
                Brand = x.Brand,
                ChassisNumber = x.ChassisNumber,
                Color = x.Color,
                EngineType = x.EngineType,
                FuelType = x.FuelType,
                Id = x.Id,
                NumberOfSeats = x.NumberOfSeats,
                Price = x.Price,
                YearOfProduction = x.YearOfProduction,
                IsDeleted = x.IsDeleted
            }).ToList();

            model.Cars = result;
            return Ok(model);
            //return View(model);
        }


        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody]CarViewModel carViewModel)
        {
            if (carViewModel != null)
            {
                var model = new Car()
                {
                    Id = carViewModel.Id,
                    Name = carViewModel.Name,
                    Brand = carViewModel.Brand,
                    NumberOfSeats = carViewModel.NumberOfSeats,
                    ChassisNumber = carViewModel.ChassisNumber,
                    Color = carViewModel.Color,
                    EngineType = carViewModel.EngineType,
                    FuelType = carViewModel.FuelType,
                    IsDeleted = carViewModel.IsDeleted,
                    Price = carViewModel.Price,
                    YearOfProduction = carViewModel.YearOfProduction
                };
                var saveSuccessful = await carService.Create(model);

                if (saveSuccessful)
                {
                    //return View();
                    return Ok(true);
                }
                //return NotFound();
                return Ok(false);
            }
            else
            {
                //return NotFound();
                return BadRequest();
            }
        }


        //[HttpGet]
        //public async Task<IActionResult> Update(int id)
        //{
        //    var carModel = await carService.GetById(id);

        //    var carViewModel = new CarViewModel()
        //    {
        //        Id = carModel.Id,
        //        Brand = carModel.Brand,
        //        ChassisNumber = carModel.ChassisNumber,
        //        Color = carModel.Color,
        //        EngineType = carModel.EngineType,
        //        FuelType = carModel.FuelType,
        //        IsDeleted = carModel.IsDeleted,
        //        Name = carModel.Name,
        //        NumberOfSeats = carModel.NumberOfSeats,
        //        Price = carModel.Price,
        //        YearOfProduction = carModel.YearOfProduction
        //    };
        //    return Ok(carViewModel);
        //    //return View(carViewModel);
        //}


        [HttpPost]
        [Route("Update")]
        public async Task<IActionResult> Update(CarViewModel carViewModel)
        {
            if (carViewModel != null)
            {
                var model = new Car()
                {
                    Id = carViewModel.Id,
                    Name = carViewModel.Name,
                    Brand = carViewModel.Brand,
                    NumberOfSeats = carViewModel.NumberOfSeats,
                    ChassisNumber = carViewModel.ChassisNumber,
                    Color = carViewModel.Color,
                    EngineType = carViewModel.EngineType,
                    FuelType = carViewModel.FuelType,
                    IsDeleted = carViewModel.IsDeleted,
                    Price = carViewModel.Price,
                    YearOfProduction = carViewModel.YearOfProduction
                };
                var saveSuccessful = await carService.Update(model);

                if (saveSuccessful)
                {
                    var viewModel = new CarViewModel();
                    var result = (await carService.GetAll()).Select(x => new CarViewModel
                    {
                        Name = x.Name,
                        Brand = x.Brand,
                        ChassisNumber = x.ChassisNumber,
                        Color = x.Color,
                        EngineType = x.EngineType,
                        FuelType = x.FuelType,
                        Id = x.Id,
                        NumberOfSeats = x.NumberOfSeats,
                        Price = x.Price,
                        YearOfProduction = x.YearOfProduction,
                        IsDeleted = x.IsDeleted
                    }).ToList();

                    viewModel.Cars = result;

                    //return RedirectToAction(nameof(CarsList), viewModel);
                    return Ok(true);
                }
                //return NotFound();
                return Ok(false);
            }
            else
            {
                return BadRequest(false);
            }
        }


        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id > 0)
            {
                var result = await carService.GetById(id);
                //return View(result);
                return Ok(result);
            }
            else
            {
                //return NotFound();
                return BadRequest(null);
            }
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {

            var result = await carService.GetAll();
            //return View(result);
            return Ok(result);


        }

        [HttpPost]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            var result = await carService.DeleteCar(id);

            var viewModel = new CarViewModel();
            var resultList = (await carService.GetAll()).Select(x => new CarViewModel
            {
                Name = x.Name,
                Brand = x.Brand,
                ChassisNumber = x.ChassisNumber,
                Color = x.Color,
                EngineType = x.EngineType,
                FuelType = x.FuelType,
                Id = x.Id,
                NumberOfSeats = x.NumberOfSeats,
                Price = x.Price,
                YearOfProduction = x.YearOfProduction,
                IsDeleted = x.IsDeleted
            }).ToList();

            viewModel.Cars = resultList;
            //return RedirectToAction(nameof(CarsList), viewModel);
            //return View(result);
            return Ok(result);

        }


   
    }
}
