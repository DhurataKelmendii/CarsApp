using Cars.Domain.Entities;
using Cars.Persistence.CarsRepositories;
using Cars.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Service.CarsServices
{
    public class CategoryService
    {

        private readonly CategoryRepository _categoryRepository;
        //private readonly IRepository<Category> _repository;


        public CategoryService(IRepository<Category> repository)
        {
            _categoryRepository = new CategoryRepository(repository);

        }

        public async Task<bool> Create(Category category)
        {
            var result = await _categoryRepository.Create(category);

            return result;
        }

        public async Task<bool> Update(Category category)
        {
            var updatedSuccefully = await _categoryRepository.Update(category);


            return updatedSuccefully;
        }

        //public async Task<bool> Delete(Category Category)
        //{
        //    _CategoryRepository.Delete(Category);

        //    var deleted = await _repository.SaveChangesAsync();

        //    return deleted;
        //}

        public async Task<IList<Category>> GetAll()
        {
            var result = await _categoryRepository.GetAll();

            return result;
        }

        public async Task<Category> GetById(int id)
        {
            var result = await _categoryRepository.GetById(id);

            return result;

        }

        public async Task<bool> DeleteCategory(int id)
        {
            var deleted = await _categoryRepository.DeleteCategory(id);
            return deleted;
        }
    }
}
