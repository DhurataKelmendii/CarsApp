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
    public class PlaceRepository
    {
        #region Properties

        private readonly IRepository<Place> _placeRepository;

        public PlaceRepository(IRepository<Place> repository)
        {
            _placeRepository = repository;

        }
        #endregion

        #region Actions

        public async Task<bool> Create(Place model)
        {
            await _placeRepository.Create(model);

            var savedSuccessful = await _placeRepository.SaveChangesAsync();

            return savedSuccessful;
        }

        public async Task<IList<Place>> GetAll()
        {
            var result = (await _placeRepository.GetAll()).Where(x => x.IsDeleted == false).ToList();
            return result;
        }


        public async Task<Place> GetById(int id)
        {
            var Place = await _placeRepository.GetById(id);
            return Place;
        }

        public async Task<bool> Update(Place model)
        {
            _placeRepository.Update(model);
            var updatedSuccesful = await _placeRepository.SaveChangesAsync();
            return updatedSuccesful;
        }

        public void Delete(Place model)
        {
            _placeRepository.Delete(model);

        }

        public async Task<bool> DeletePlace(int id)
        {
            var result = await _placeRepository.GetById(id);
            result.IsDeleted = true;
            var deletedSuccesful = await _placeRepository.SaveChangesAsync();
            return deletedSuccesful;
        }
        #endregion
    }
}
