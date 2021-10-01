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
    public class BusGarageController : Controller
    {
        private readonly BusGarageService busGarageService;
        

        public BusGarageController(IRepository<BusGarage> _repository)
        {
            busGarageService = new BusGarageService(_repository);
            
        }


        [HttpGet]
        [Route("BusGaragesList")]
        public async Task<IActionResult> BusGaragesList()
        {
            var model = new BusGarageViewModel();
            var result = (await busGarageService.GetAll()).Select(x => new BusGarageViewModel
            {
                Name = x.Name,
                CapacityOfBuses = x.CapacityOfBuses,
                Country = x.Country,
                City = x.City,
                Street = x.Street,
                Id = x.Id,
                BusesUsing = x.BusesUsing,
                PricePerDay = x.PricePerDay,
                IsDeleted = x.IsDeleted
            }).ToList();

            model.BusGarages = result;
            //return View(model);
            return Ok(model);
        }

        [HttpPost]
        [Route("CreateBusGarage")]
        public async Task<IActionResult> CreateBusGarage(BusGarageViewModel busGarageViewModel)
        {
            if (busGarageViewModel != null)
            {
                var model = new BusGarage()
                {
                    Id = busGarageViewModel.Id,
                    Name = busGarageViewModel.Name,
                    Country = busGarageViewModel.Country,
                    City = busGarageViewModel.City,
                    Street = busGarageViewModel.Street,
                    CapacityOfBuses = busGarageViewModel.CapacityOfBuses,
                    BusesUsing = busGarageViewModel.BusesUsing,
                    PricePerDay = busGarageViewModel.PricePerDay,
                    IsDeleted = busGarageViewModel.IsDeleted,
                };
                var saveSuccessful = await busGarageService.Create(model);

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
        //    var busGarageModel = await busGarageService.GetById(id);

        //    var busGarageViewModel = new BusGarageViewModel()
        //    {
        //        Id = busGarageModel.Id,
        //        Name = busGarageModel.Name,
        //        Country = busGarageModel.Country,
        //        City = busGarageModel.City,
        //        Street = busGarageModel.Street,
        //        CapacityOfCars = busGarageModel.CapacityOfCars,
        //        CarsUsing = busGarageModel.CarsUsing,
        //        PricePerDay = busGarageModel.PricePerDay,
        //        IsDeleted = busGarageModel.IsDeleted
        //    };
        //    //return View(busGarageViewModel);
        //    return Ok(busGarageViewModel);
        //}

        [HttpPost]
        [Route("UpdateBusGarage")]
        public async Task<IActionResult> UpdateBusGarage(BusGarageViewModel busGarageViewModel)
        {
            if (busGarageViewModel != null)
            {
                var model = new BusGarage()
                {
                    Id = busGarageViewModel.Id,
                    Name = busGarageViewModel.Name,
                    Country = busGarageViewModel.Country,
                    City = busGarageViewModel.City,
                    Street = busGarageViewModel.Street,
                    CapacityOfBuses = busGarageViewModel.CapacityOfBuses,
                    BusesUsing = busGarageViewModel.BusesUsing,
                    PricePerDay = busGarageViewModel.PricePerDay,
                    IsDeleted = busGarageViewModel.IsDeleted
                };
                var saveSuccessful = await busGarageService.Update(model);

                if (saveSuccessful)
                {
                    var viewModel = new BusGarageViewModel();
                    var result = (await busGarageService.GetAll()).Select(x => new BusGarageViewModel
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Country = x.Country,
                        Street = x.Street,
                        City = x.City,
                        CapacityOfBuses = x.CapacityOfBuses,
                        BusesUsing = x.BusesUsing,
                        PricePerDay = x.PricePerDay,
                        IsDeleted = x.IsDeleted
                    }).ToList();

                    viewModel.BusGarages = result;

                    //return RedirectToAction(nameof(BusGaragesList), viewModel);
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
        [Route("GetBusGarageById/{id}")]
        public async Task<IActionResult> GetBusGarageById(int id)
        {
            if (id > 0)
            {
                var result = await busGarageService.GetById(id);
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }


        [HttpPost]
        [Route("DeleteBusGarage/{id}")]
        public async Task<IActionResult> DeleteBusGarage(int id)
        {

            var result = await busGarageService.DeleteBusGarage(id);

            var viewModel = new BusGarageViewModel();
            var resultList = (await busGarageService.GetAll()).Select(x => new BusGarageViewModel
            {
                Name = x.Name,
                Country = x.Country,
                Street = x.Street,
                City = x.City,
                CapacityOfBuses = x.CapacityOfBuses,
                BusesUsing = x.BusesUsing,
                PricePerDay = x.PricePerDay,
                IsDeleted = x.IsDeleted
            }).ToList();

            viewModel.BusGarages = resultList;
            //return RedirectToAction(nameof(BusGaragesList), viewModel);
            return Ok(viewModel);

        }



    }
}
