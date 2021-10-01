using Cars.Domain.Entities;
using Cars.Infrastructure.ViewModels;
using Cars.Persistence;
using Cars.Persistence.CarsRepositories;
using Cars.Persistence.Repositories;
using Cars.Service.CarsServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarsUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusController : Controller
    {
        private readonly BusService busService;


        public BusController(IRepository<Bus> repository)
        {
            busService = new BusService(repository);
        }


        [HttpGet]
        [Route("BusList")]
        public async Task<IActionResult> BusList()
        {
            var model = new BusViewModel();
            var result = (await busService.GetAll()).Select(x => new BusViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Brand = x.Brand,
                ChassisNumber = x.ChassisNumber,
                Color = x.Color,
                EngineType = x.EngineType,
                FuelType = x.FuelType,
                
                NumberOfSeats = x.NumberOfSeats,
                Price = x.Price,
                YearOfProduction = x.YearOfProduction,

                IsDeleted = x.IsDeleted
            }).ToList();

            model.Bus = result;
            //return View(model);
            return Ok(model);
        }

        [HttpPost]
        [Route("CreateBus")]
        public async Task<IActionResult> Create(BusViewModel busViewModel)
        {
            if (busViewModel != null)
            {
                var model = new Bus()
                {
                    Id = busViewModel.Id,
                    Name = busViewModel.Name,
                    Brand = busViewModel.Brand,
                    ChassisNumber = busViewModel.ChassisNumber,
                    Color = busViewModel.Color,
                    EngineType = busViewModel.EngineType,
                    FuelType = busViewModel.FuelType,

                    NumberOfSeats = busViewModel.NumberOfSeats,
                    Price = busViewModel.Price,
                    YearOfProduction = busViewModel.YearOfProduction,

                    IsDeleted = busViewModel.IsDeleted,

                };
                var saveSuccessful = await busService.Create(model);

                if (saveSuccessful)
                {
                    return Ok(true);
                    //return View();
                }

                return Ok(false);
                //return NotFound();
            }
            else
            {
                return BadRequest();
            }
        }

        //[HttpGet]
        //public async Task<IActionResult> Update(int id)
        //{
        //    var busModel = await busService.GetById(id);

        //    var busViewModel = new BusViewModel()
        //    {
        //        Id = busModel.Id,
        //        Name = busModel.Name,
        //        Country = busModel.Country,
        //        City = busModel.City,
        //        Street = busModel.Street,
        //        CapacityOfCars = busModel.CapacityOfCars,
        //        CarsUsing = busModel.CarsUsing,
        //        PricePerDay = busModel.PricePerDay,
        //        IsDeleted = busModel.IsDeleted
        //    };
        //    //return View(busViewModel);
        //    return Ok(busViewModel);
        //}

        [HttpPost]
        [Route("Update")]
        public async Task<IActionResult> Update(BusViewModel busViewModel)
        {
            if (busViewModel != null)
            {
                var model = new Bus()
                {
                    Id = busViewModel.Id,
                    Name = busViewModel.Name,
                    Brand = busViewModel.Brand,
                    ChassisNumber = busViewModel.ChassisNumber,
                    Color = busViewModel.Color,
                    EngineType = busViewModel.EngineType,
                    FuelType = busViewModel.FuelType,

                    NumberOfSeats = busViewModel.NumberOfSeats,
                    Price = busViewModel.Price,
                    YearOfProduction = busViewModel.YearOfProduction,

                    IsDeleted = busViewModel.IsDeleted,
                };
                var saveSuccessful = await busService.Update(model);

                if (saveSuccessful)
                {
                    var viewModel = new BusViewModel();
                    var result = (await busService.GetAll()).Select(x => new BusViewModel
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Brand = x.Brand,
                        ChassisNumber = x.ChassisNumber,
                        Color = x.Color,
                        EngineType = x.EngineType,
                        FuelType = x.FuelType,

                        NumberOfSeats = x.NumberOfSeats,
                        Price = x.Price,
                        YearOfProduction = x.YearOfProduction,

                        IsDeleted = x.IsDeleted
                    }).ToList();

                    viewModel.Bus = result;

                    //return RedirectToAction(nameof(BussList), viewModel);
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
                var result = await busService.GetById(id);
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }


        [HttpPost]
        [Route("Delete/{id}")]
        public async Task<IActionResult> DeleteBus(int id)
        {

            var result = await busService.DeleteBus(id);

            var viewModel = new BusViewModel();
            var resultList = (await busService.GetAll()).Select(x => new BusViewModel
            {
                
                Name = x.Name,
                Brand = x.Brand,
                ChassisNumber = x.ChassisNumber,
                Color = x.Color,
                EngineType = x.EngineType,
                FuelType = x.FuelType,

                NumberOfSeats = x.NumberOfSeats,
                Price = x.Price,
                YearOfProduction = x.YearOfProduction,

                IsDeleted = x.IsDeleted

            }).ToList();

            viewModel.Bus = resultList;
            //return RedirectToAction(nameof(BussList), viewModel);
            return Ok(viewModel);

        }



    }
}
