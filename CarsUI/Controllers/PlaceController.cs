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
    public class PlaceController : Controller
    {
        private readonly PlaceService placeService;


        public PlaceController(IRepository<Place> repository, CarsDbContext context)
        {
            placeService = new PlaceService(repository, context);
        }



        [HttpGet]
        [Route("PlacesList")]
        public async Task<IActionResult> PlacesList()
        {
            var model = new PlaceViewModel();
            var result = (await placeService.GetAll()).Select(x => new PlaceViewModel
            {
                Id = x.Id,
                NamePlace = x.NamePlace,
                Country = x.Country,
                City = x.City,
                Street = x.Street,
                NumberOfGarages = x.NumberOfGarages,
                IsDeleted = x.IsDeleted
            }).ToList();

            model.Places = result;
            //return View(model);
            return Ok(model);
        }

        [HttpPost]
        [Route("CreatePlace")]
        public async Task<IActionResult> CreatePlace(PlaceViewModel placeViewModel)
        {
            if (placeViewModel != null)
            {
                var model = new Place()
                {
                    Id = placeViewModel.Id,
                    NamePlace = placeViewModel.NamePlace,
                    Country = placeViewModel.Country,
                    City = placeViewModel.City,
                    Street = placeViewModel.Street,
                    NumberOfGarages = placeViewModel.NumberOfGarages,
                    IsDeleted = placeViewModel.IsDeleted,
                };
                var saveSuccessful = await placeService.Create(model);

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

        [HttpPost]
        [Route("UpdatePlace")]
        public async Task<IActionResult> Update(PlaceViewModel placeViewModel)
        {
            if (placeViewModel != null)
            {
                var model = new Place()
                {
                    Id = placeViewModel.Id,
                    NamePlace = placeViewModel.NamePlace,
                    Country = placeViewModel.Country,
                    City = placeViewModel.City,
                    Street = placeViewModel.Street,
                    NumberOfGarages = placeViewModel.NumberOfGarages,
                    IsDeleted = placeViewModel.IsDeleted
                };
                var saveSuccessful = await placeService.Update(model);

                if (saveSuccessful)
                {
                    var viewModel = new PlaceViewModel();
                    var result = (await placeService.GetAll()).Select(x => new PlaceViewModel
                    {
                        Id = x.Id,
                        NamePlace = x.NamePlace,
                        Country = placeViewModel.Country,
                        City = placeViewModel.City,
                        Street = placeViewModel.Street,
                        NumberOfGarages = placeViewModel.NumberOfGarages,
                        IsDeleted = x.IsDeleted
                    }).ToList();

                    viewModel.Places = result;

                    //return RedirectToAction(nameof(PlacesList), viewModel);
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
        [Route("GetPlaceById/{id}")]
        public async Task<IActionResult> GetPlaceById(int id)
        {
            if (id > 0)
            {
                var result = await placeService.GetById(id);
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }


        [HttpPost]
        [Route("DeletePlace/{id}")]
        public async Task<IActionResult> DeletePlace(int id)
        {

            var result = await placeService.DeletePlace(id);

            var viewModel = new PlaceViewModel();
            var resultList = (await placeService.GetAll()).Select(x => new PlaceViewModel
            {
                NamePlace = x.NamePlace,
                Country = x.Country,
                City = x.City,
                Street = x.Street,
                NumberOfGarages = x.NumberOfGarages,
                IsDeleted = x.IsDeleted
            }).ToList();

            viewModel.Places = resultList;
            //return RedirectToAction(nameof(PlacesList), viewModel);
            return Ok(viewModel);

        }



    }
}
