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
    public class RolesController : Controller
    {
        private readonly RolesService rolesService;


        public RolesController(IRepository<Roles> repository, CarsDbContext context)
        {
            rolesService = new RolesService(repository, context);
        }



        [HttpGet]
        [Route("RolessList")]
        public async Task<IActionResult> RolessList()
        {
            var model = new RolesViewModel();
            var result = (await rolesService.GetAll()).Select(x => new RolesViewModel
            {
                Id = x.Id,
                RoleName = x.RoleName,
                IsDeleted = x.IsDeleted
            }).ToList();

            model.Roless = result;
            //return View(model);
            return Ok(model);
        }

        [HttpPost]
        [Route("CreateRoles")]
        public async Task<IActionResult> CreateRoles(RolesViewModel rolesViewModel)
        {
            if (rolesViewModel != null)
            {
                var model = new Roles()
                {
                    Id = rolesViewModel.Id,
                    RoleName = rolesViewModel.RoleName,
                   

                    IsDeleted = rolesViewModel.IsDeleted,
                };
                var saveSuccessful = await rolesService.Create(model);

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
        //    var rolesModel = await rolesService.GetById(id);

        //    var rolesViewModel = new RolesViewModel()
        //    {
        //        Id = rolesModel.Id,
        //        Name = rolesModel.Name,
        //        Country = rolesModel.Country,
        //        City = rolesModel.City,
        //        Street = rolesModel.Street,
        //        CapacityOfCars = rolesModel.CapacityOfCars,
        //        CarsUsing = rolesModel.CarsUsing,
        //        PricePerDay = rolesModel.PricePerDay,
        //        IsDeleted = rolesModel.IsDeleted
        //    };
        //    //return View(rolesViewModel);
        //    return Ok(rolesViewModel);
        //}

        [HttpPost]
        [Route("UpdateRoles")]
        public async Task<IActionResult> UpdateRoles(RolesViewModel rolesViewModel)
        {
            if (rolesViewModel != null)
            {
                var model = new Roles()
                {
                    Id = rolesViewModel.Id,
                    RoleName = rolesViewModel.RoleName,
                   
                    IsDeleted = rolesViewModel.IsDeleted
                };
                var saveSuccessful = await rolesService.Update(model);

                if (saveSuccessful)
                {
                    var viewModel = new RolesViewModel();
                    var result = (await rolesService.GetAll()).Select(x => new RolesViewModel
                    {
                        Id = x.Id,
                        RoleName = x.RoleName,
                        
                        IsDeleted = x.IsDeleted
                    }).ToList();

                    viewModel.Roless = result;

                    //return RedirectToAction(nameof(RolessList), viewModel);
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
        [Route("GetRolesById/{id}")]
        public async Task<IActionResult> GetRolesById(int id)
        {
            if (id > 0)
            {
                var result = await rolesService.GetById(id);
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }


        [HttpPost]
        [Route("DeleteRoles/{id}")]
        public async Task<IActionResult> DeleteRoles(int id)
        {

            var result = await rolesService.DeleteRoles(id);

            var viewModel = new RolesViewModel();
            var resultList = (await rolesService.GetAll()).Select(x => new RolesViewModel
            {
                RoleName = x.RoleName,
               
                IsDeleted = x.IsDeleted
            }).ToList();

            viewModel.Roless = resultList;
            //return RedirectToAction(nameof(RolessList), viewModel);
            return Ok(viewModel);

        }



    }
}
