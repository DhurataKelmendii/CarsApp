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
    public class AdminController : Controller
    {
        private readonly AdminService adminService;


        public AdminController(IRepository<Admin> repository, CarsDbContext context)
        {
            adminService = new AdminService(repository, context);
        }



        [HttpGet]
        [Route("AdminsList")]
        public async Task<IActionResult> AdminsList()
        {
            var model = new AdminViewModel();
            var result = (await adminService.GetAll()).Select(x => new AdminViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Gender = x.Gender,
                Email = x.Email,
                IsDeleted = x.IsDeleted
            }).ToList();

            model.Admins = result;
            //return View(model);
            return Ok(model);
        }

        [HttpPost]
        [Route("CreateAdmin")]
        public async Task<IActionResult> CreateAdmin(AdminViewModel adminViewModel)
        {
            if (adminViewModel != null)
            {
                var model = new Admin()
                {
                    Id = adminViewModel.Id,
                    Name = adminViewModel.Name,
                    Email = adminViewModel.Email,
                    Gender = adminViewModel.Gender,

                    IsDeleted = adminViewModel.IsDeleted,
                };
                var saveSuccessful = await adminService.Create(model);

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
        //    var adminModel = await adminService.GetById(id);

        //    var adminViewModel = new AdminViewModel()
        //    {
        //        Id = adminModel.Id,
        //        Name = adminModel.Name,
        //        Country = adminModel.Country,
        //        City = adminModel.City,
        //        Street = adminModel.Street,
        //        CapacityOfCars = adminModel.CapacityOfCars,
        //        CarsUsing = adminModel.CarsUsing,
        //        PricePerDay = adminModel.PricePerDay,
        //        IsDeleted = adminModel.IsDeleted
        //    };
        //    //return View(adminViewModel);
        //    return Ok(adminViewModel);
        //}

        [HttpPost]
        [Route("UpdateAdmin")]
        public async Task<IActionResult> UpdateAdmin(AdminViewModel adminViewModel)
        {
            if (adminViewModel != null)
            {
                var model = new Admin()
                {
                    Id = adminViewModel.Id,
                    Name = adminViewModel.Name,
                    Email = adminViewModel.Email,
                    Gender = adminViewModel.Gender,
                    IsDeleted = adminViewModel.IsDeleted
                };
                var saveSuccessful = await adminService.Update(model);

                if (saveSuccessful)
                {
                    var viewModel = new AdminViewModel();
                    var result = (await adminService.GetAll()).Select(x => new AdminViewModel
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Email = x.Email,
                        Gender = x.Gender,
                        IsDeleted = x.IsDeleted
                    }).ToList();

                    viewModel.Admins = result;

                    //return RedirectToAction(nameof(AdminsList), viewModel);
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
        [Route("GetAdminById/{id}")]
        public async Task<IActionResult> GetAdminById(int id)
        {
            if (id > 0)
            {
                var result = await adminService.GetById(id);
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }


        [HttpPost]
        [Route("DeleteAdmin/{id}")]
        public async Task<IActionResult> DeleteAdmin(int id)
        {

            var result = await adminService.DeleteAdmin(id);

            var viewModel = new AdminViewModel();
            var resultList = (await adminService.GetAll()).Select(x => new AdminViewModel
            {
                Name = x.Name,
                Email = x.Email,
                Gender = x.Gender,
                IsDeleted = x.IsDeleted
            }).ToList();

            viewModel.Admins = resultList;
            //return RedirectToAction(nameof(AdminsList), viewModel);
            return Ok(viewModel);

        }



    }
}
