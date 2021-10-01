using Cars.Domain.Entities;
using Cars.Persistence;
using Cars.Persistence.CarsRepositories;
using Cars.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Service.CarsServices
{
    public class PlaceService
    {
        private readonly PlaceRepository _placeRepository;

        public PlaceService(IRepository<Place> repository, CarsDbContext context)
        {
            _placeRepository = new PlaceRepository(repository, context);

        }

        public async Task<bool> Create(Place place)
        {
            var result = await _placeRepository.Create(place);

            return result;
        }

        public async Task<bool> Update(Place place)
        {
            var updatedSuccefully = await _placeRepository.Update(place);


            return updatedSuccefully;
        }


        public async Task<IList<Place>> GetAll()
        {
            var result = await _placeRepository.GetAll();

            return result;
        }

        public async Task<Place> GetById(int id)
        {
            var result = await _placeRepository.GetById(id);

            return result;

        }

        public async Task<bool> DeletePlace(int id)
        {
            var deleted = await _placeRepository.DeletePlace(id);
            return deleted;
        }


    }
}

