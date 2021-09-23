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
   public class BusGarageServices
    {
        private readonly BusGarageRepository _busGarageRepository;


        public BusGarageServices(IRepository<BusGarage> repository)
        {
            _busGarageRepository = new BusGarageRepository(repository);

        }

        public async Task<bool> Create(BusGarage busGarage)
        {
            var result = await _busGarageRepository.Create(busGarage);

            return result;
        }

        public async Task<bool> Update(BusGarage busGarage)
        {
            var updatedSuccefully = await _busGarageRepository.Update(busGarage);


            return updatedSuccefully;
        }

        public async Task<IList<BusGarage>> GetAll()
        {
            var result = await _busGarageRepository.GetAll();

            return result;
        }

        public async Task<BusGarage> GetById(int id)
        {
            var result = await _busGarageRepository.GetById(id);

            return result;

        }

        public async Task<bool> DeleteBusGarage(int id)
        {
            var deleted = await _busGarageRepository.DeleteBusGarage(id);
            return deleted;
        }
    }

}
