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
    public class CategoryController : Controller
    {
        private readonly CategoryService categoryService;
       

        public CategoryController(IRepository<Category> repository)
        {
            categoryService = new CategoryService(repository);
        }


        [HttpGet]
        [Route("CategoryList")]
        public async Task<IActionResult> CategoryList()
        {
            var model = new CategoryViewModel();
            var result = (await categoryService.GetAll()).Select(x => new CategoryViewModel
            {   Id=x.Id,
                CategoryName = x.CategoryName,
       
                IsDeleted = x.IsDeleted
            }).ToList();

            model.Categories = result;
            //return View(model);
            return Ok(model);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateCategory(CategoryViewModel categoryViewModel)
        {
            if (categoryViewModel != null)
            {
                var model = new Category()
                {
                    Id = categoryViewModel.Id,
                    CategoryName = categoryViewModel.CategoryName,
                   
                    IsDeleted = categoryViewModel.IsDeleted,
                };
                var saveSuccessful = await categoryService.Create(model);

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
        //    var categoryModel = await categoryService.GetById(id);

        //    var categoryViewModel = new CategoryViewModel()
        //    {
        //        Id = categoryModel.Id,
        //        Name = categoryModel.Name,
        //        Country = categoryModel.Country,
        //        City = categoryModel.City,
        //        Street = categoryModel.Street,
        //        CapacityOfCars = categoryModel.CapacityOfCars,
        //        CarsUsing = categoryModel.CarsUsing,
        //        PricePerDay = categoryModel.PricePerDay,
        //        IsDeleted = categoryModel.IsDeleted
        //    };
        //    //return View(categoryViewModel);
        //    return Ok(categoryViewModel);
        //}

        [HttpPost]
        [Route("Update")]
        public async Task<IActionResult> UpdateCategory(CategoryViewModel categoryViewModel)
        {
            if (categoryViewModel != null)
            {
                var model = new Category()
                {
                    Id = categoryViewModel.Id,
                    CategoryName = categoryViewModel.CategoryName,
                    
                    IsDeleted = categoryViewModel.IsDeleted
                };
                var saveSuccessful = await categoryService.Update(model);

                if (saveSuccessful)
                {
                    var viewModel = new CategoryViewModel();
                    var result = (await categoryService.GetAll()).Select(x => new CategoryViewModel
                    {
                        Id = x.Id,
                        CategoryName = x.CategoryName,
                        
                        IsDeleted = x.IsDeleted
                    }).ToList();

                    viewModel.Categories = result;

                    //return RedirectToAction(nameof(CategorysList), viewModel);
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
        [Route("GetCategoryById/{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            if (id > 0)
            {
                var result = await categoryService.GetById(id);
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }


        [HttpPost]
        [Route("Delete/{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {

            var result = await categoryService.DeleteCategory(id);

            var viewModel = new CategoryViewModel();
            var resultList = (await categoryService.GetAll()).Select(x => new CategoryViewModel
            {
                CategoryName = x.CategoryName,
                
                IsDeleted = x.IsDeleted
            }).ToList();

            viewModel.Categories = resultList;
            //return RedirectToAction(nameof(CategorysList), viewModel);
            return Ok(viewModel);

        }



    }
}
