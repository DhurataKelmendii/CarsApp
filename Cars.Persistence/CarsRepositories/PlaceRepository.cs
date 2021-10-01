using Cars.Domain.Entities;
using Cars.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Persistence.CarsRepositories
{
    public class PlaceRepository
    {
        //private readonly GarageRepository _garageRepository = new GarageRepository();
        private readonly IRepository<Place> _placeRepository;

        private readonly CarsDbContext _dbContext;


        public PlaceRepository(IRepository<Place> repository,
            CarsDbContext dbContext
            )
        {
            _placeRepository = repository;

            _dbContext = dbContext;
        }
        public async Task<bool> Create(Place place)
        {
            await _placeRepository.Create(place);

            var savedSuccesfully = await _placeRepository.SaveChangesAsync();

            return savedSuccesfully;

        }

        public async Task<bool> Update(Place place)
        {
            _placeRepository.Update(place);

            var updatedSuccesful = await _placeRepository.SaveChangesAsync();
            return updatedSuccesful;
        }

        public async Task<Place> GetById(int id)
        {
            var result = await _placeRepository.GetById(id);
            return result;

        }

        public async Task<bool> DeletePlace(int id)
        {
            var result = await _placeRepository.GetById(id);
            result.IsDeleted = true;
            var deletedSuccesful = await _placeRepository.SaveChangesAsync();
            return deletedSuccesful;
        }

        public async Task<IList<Place>> GetAll()
        {
            var result = (await _placeRepository.GetAll()).Where(x => x.IsDeleted == false).ToList();
            return result;
        }

    }

}

