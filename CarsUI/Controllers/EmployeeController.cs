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
    public class EmployeeController : ControllerBase
    {
        private readonly IRepository<Employee> _repository;
        private readonly EmployeeService employeeService;

        public EmployeeController(IRepository<Employee> repository)
        {
            employeeService = new EmployeeService(repository);
        }

        [HttpGet]
        [Route("EmployeeList")]
        public async Task<IActionResult> EmployeeList()
        {
            var model = new EmployeeViewModel();
            var result = (await employeeService.GetAll()).Select(x => new EmployeeViewModel
            {
                Name = x.Name,
                Email = x.Email,
                Gender = x.Gender,
                IsDeleted = x.IsDeleted
            }).ToList();

            model.Employees = result;
            return Ok(model);
            //return View(model);
        }


        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] EmployeeViewModel employeeViewModel)
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
                var saveSuccessful = await employeeService.Create(model);

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

    }
}