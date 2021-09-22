using Cars.Domain.Entities;
using Cars.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Persistence.CarsRepositories
{
    public class CategoryRepository
    {
        #region Properties

        private readonly IRepository<Category> _categoryRepository;

        public CategoryRepository(IRepository<Category> repository)
        {
            _categoryRepository = repository;

        }
        #endregion

        #region Actions

        public async Task<bool> Create(Category model)
        {
            await _categoryRepository.Create(model);

            var savedSuccessful = await _categoryRepository.SaveChangesAsync();

            return savedSuccessful;
        }

        public async Task<IList<Category>> GetAll()
        {
            var result = (await _categoryRepository.GetAll()).Where(x => x.IsDeleted == false).ToList();
            return result;
        }


        public async Task<Category> GetById(int id)
        {
            var user = await _categoryRepository.GetById(id);
            return user;
        }

        public async Task<bool> Update(Category model)
        {
            _categoryRepository.Update(model);
            var updatedSuccesful = await _categoryRepository.SaveChangesAsync();
            return updatedSuccesful;
        }

        public void Delete(Category model)
        {
            _categoryRepository.Delete(model);

        }

        public async Task<bool> DeleteCategory(int id)
        {
            var result = await _categoryRepository.GetById(id);
            result.IsDeleted = true;
            var deletedSuccesful = await _categoryRepository.SaveChangesAsync();
            return deletedSuccesful;
        }
        #endregion
    }
}
