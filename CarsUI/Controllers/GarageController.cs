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
    public class GarageController : Controller
    {
        private readonly GarageService garageService;
        private readonly CarService carService;

        public GarageController(IRepository<Garage> _repository, IRepository<Car> _carRepository, IRepository<CarGarageRel> _carGarageRepository, CarsDbContext context)
        {
            garageService = new GarageService(_repository, _carRepository, _carGarageRepository, context);
            carService = new CarService(_carRepository);
        }


        [HttpGet]
        [Route("GaragesList")]
        public async Task<IActionResult> GaragesList()
        {
            var model = new GarageViewModel();
            var result = (await garageService.GetAll()).Select(x => new GarageViewModel
            {
                Name = x.Name,
                CapacityOfCars = x.CapacityOfCars,
                Country = x.Country,
                City = x.City,
                Street = x.Street,
                Id = x.Id,
                CarsUsing = x.CarsUsing,
                PricePerDay = x.PricePerDay,
                IsDeleted = x.IsDeleted
            }).ToList();

            model.Garages = result;
            //return View(model);
            return Ok(model);
        }

        [HttpPost]
        [Route("CreateGarage")]
        public async Task<IActionResult> CreateGarage(GarageViewModel garageViewModel)
        {
            if (garageViewModel != null)
            {
                var model = new Garage()
                {
                    Id = garageViewModel.Id,
                    Name = garageViewModel.Name,
                    Country = garageViewModel.Country,
                    City = garageViewModel.City,
                    Street = garageViewModel.Street,
                    CapacityOfCars = garageViewModel.CapacityOfCars,
                    CarsUsing = garageViewModel.CarsUsing,
                    PricePerDay = garageViewModel.PricePerDay,
                    IsDeleted = garageViewModel.IsDeleted,
                };
                var saveSuccessful = await garageService.Create(model);

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
        //    var garageModel = await garageService.GetById(id);

        //    var garageViewModel = new GarageViewModel()
        //    {
        //        Id = garageModel.Id,
        //        Name = garageModel.Name,
        //        Country = garageModel.Country,
        //        City = garageModel.City,
        //        Street = garageModel.Street,
        //        CapacityOfCars = garageModel.CapacityOfCars,
        //        CarsUsing = garageModel.CarsUsing,
        //        PricePerDay = garageModel.PricePerDay,
        //        IsDeleted = garageModel.IsDeleted
        //    };
        //    //return View(garageViewModel);
        //    return Ok(garageViewModel);
        //}

        [HttpPost]
        [Route("UpdateGarage")]
        public async Task<IActionResult> UpdateGarage(GarageViewModel garageViewModel)
        {
            if (garageViewModel != null)
            {
                var model = new Garage()
                {
                    Id = garageViewModel.Id,
                    Name = garageViewModel.Name,
                    Country = garageViewModel.Country,
                    City = garageViewModel.City,
                    Street = garageViewModel.Street,
                    CapacityOfCars = garageViewModel.CapacityOfCars,
                    CarsUsing = garageViewModel.CarsUsing,
                    PricePerDay = garageViewModel.PricePerDay,
                    IsDeleted = garageViewModel.IsDeleted
                };
                var saveSuccessful = await garageService.Update(model);

                if (saveSuccessful)
                {
                    var viewModel = new GarageViewModel();
                    var result = (await garageService.GetAll()).Select(x => new GarageViewModel
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Country = x.Country,
                        Street = x.Street,
                        City = x.City,
                        CapacityOfCars = x.CapacityOfCars,
                        CarsUsing = x.CarsUsing,
                        PricePerDay = x.PricePerDay,
                        IsDeleted = x.IsDeleted
                    }).ToList();

                    viewModel.Garages = result;

                    //return RedirectToAction(nameof(GaragesList), viewModel);
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
        [Route("GetGarageById/{id}")]
        public async Task<IActionResult> GetGarageById(int id)
        {
            if (id > 0)
            {
                var result = await garageService.GetById(id);
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }


        [HttpPost]
        [Route("DeleteGarage/{id}")]
        public async Task<IActionResult> DeleteGarage(int id)
        {

            var result = await garageService.DeleteGarage(id);

            var viewModel = new GarageViewModel();
            var resultList = (await garageService.GetAll()).Select(x => new GarageViewModel
            {
                Name = x.Name,
                Country = x.Country,
                Street = x.Street,
                City = x.City,
                CapacityOfCars = x.CapacityOfCars,
                CarsUsing = x.CarsUsing,
                PricePerDay = x.PricePerDay,
                IsDeleted = x.IsDeleted
            }).ToList();

            viewModel.Garages = resultList;
            //return RedirectToAction(nameof(GaragesList), viewModel);
            return Ok(viewModel);

        }



    }
}
