using Cars.Domain.Entities;
using Cars.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Persistence.CarsRepositories
{
   public class BusGarageRepository
    {
        #region Properties

        private readonly IRepository<BusGarage> _busGarageRepository;

        public BusGarageRepository(IRepository<BusGarage> repository)
        {
            _busGarageRepository = repository;

        }
        #endregion

        #region Actions

        public async Task<bool> Create(BusGarage model)
        {
            await _busGarageRepository.Create(model);

            var savedSuccessful = await _busGarageRepository.SaveChangesAsync();

            return savedSuccessful;
        }

        public async Task<IList<BusGarage>> GetAll()
        {
            var result = (await _busGarageRepository.GetAll()).Where(x => x.IsDeleted == false).ToList();
            return result;
        }


        public async Task<BusGarage> GetById(int id)
        {
            var user = await _busGarageRepository.GetById(id);
            return user;
        }

        public async Task<bool> Update(BusGarage model)
        {
            _busGarageRepository.Update(model);
            var updatedSuccesful = await _busGarageRepository.SaveChangesAsync();
            return updatedSuccesful;
        }

        public void Delete(BusGarage model)
        {
            _busGarageRepository.Delete(model);

        }

        public async Task<bool> DeleteBusGarage(int id)
        {
            var result = await _busGarageRepository.GetById(id);
            result.IsDeleted = true;
            var deletedSuccesful = await _busGarageRepository.SaveChangesAsync();
            return deletedSuccesful;
        }
        #endregion
    }
}
