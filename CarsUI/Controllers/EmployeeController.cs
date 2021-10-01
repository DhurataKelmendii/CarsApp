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
    public class EmployeeController : Controller
    {
        private readonly EmployeeService employeeService;


        public EmployeeController(IRepository<Employee> repository, CarsDbContext context)
        {
            employeeService = new EmployeeService(repository,context);
        }



        [HttpGet]
        [Route("EmployeesList")]
        public async Task<IActionResult> EmployeesList()
        {
            var model = new EmployeeViewModel();
            var result = (await employeeService.GetAll()).Select(x => new EmployeeViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Gender = x.Gender,
                Email = x.Email,
                IsDeleted = x.IsDeleted
            }).ToList();

            model.Employees = result;
            //return View(model);
            return Ok(model);
        }

        [HttpPost]
        [Route("CreateEmployee")]
        public async Task<IActionResult> CreateEmployee(EmployeeViewModel employeeViewModel)
        {
            if (employeeViewModel != null)
            {
                var model = new Employee()
                {
                    Id = employeeViewModel.Id,
                    Name = employeeViewModel.Name,
                    Email = employeeViewModel.Email,
                    Gender = employeeViewModel.Gender,
                   
                    IsDeleted = employeeViewModel.IsDeleted,
                };
                var saveSuccessful = await employeeService.Create(model);

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
        //    var employeeModel = await employeeService.GetById(id);

        //    var employeeViewModel = new EmployeeViewModel()
        //    {
        //        Id = employeeModel.Id,
        //        Name = employeeModel.Name,
        //        Country = employeeModel.Country,
        //        City = employeeModel.City,
        //        Street = employeeModel.Street,
        //        CapacityOfCars = employeeModel.CapacityOfCars,
        //        CarsUsing = employeeModel.CarsUsing,
        //        PricePerDay = employeeModel.PricePerDay,
        //        IsDeleted = employeeModel.IsDeleted
        //    };
        //    //return View(employeeViewModel);
        //    return Ok(employeeViewModel);
        //}

        [HttpPost]
        [Route("UpdateEmployee")]
        public async Task<IActionResult> UpdateEmployee(EmployeeViewModel employeeViewModel)
        {
            if (employeeViewModel != null)
            {
                var model = new Employee()
                {
                    Id = employeeViewModel.Id,
                    Name = employeeViewModel.Name,
                    Email = employeeViewModel.Email,
                    Gender = employeeViewModel.Gender,
                    IsDeleted = employeeViewModel.IsDeleted
                };
                var saveSuccessful = await employeeService.Update(model);

                if (saveSuccessful)
                {
                    var viewModel = new EmployeeViewModel();
                    var result = (await employeeService.GetAll()).Select(x => new EmployeeViewModel
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Email=x.Email,
                        Gender = x.Gender,
                        IsDeleted = x.IsDeleted
                    }).ToList();

                    viewModel.Employees = result;

                    //return RedirectToAction(nameof(EmployeesList), viewModel);
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
        [Route("GetEmployeeById/{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            if (id > 0)
            {
                var result = await employeeService.GetById(id);
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }


        [HttpPost]
        [Route("DeleteEmployee/{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {

            var result = await employeeService.DeleteEmployee(id);

            var viewModel = new EmployeeViewModel();
            var resultList = (await employeeService.GetAll()).Select(x => new EmployeeViewModel
            {
                Name = x.Name,
                Email = x.Email,
                Gender = x.Gender,
                IsDeleted = x.IsDeleted
            }).ToList();

            viewModel.Employees = resultList;
            //return RedirectToAction(nameof(EmployeesList), viewModel);
            return Ok(viewModel);

        }



    }
}
