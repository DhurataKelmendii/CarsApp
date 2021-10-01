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
        //private readonly BusGarageRepository _busGarageRepository = new BusGarageRepository();
        private readonly IRepository<BusGarage> _busGarageRepository;
        

        public BusGarageRepository(IRepository<BusGarage> repository
            
            )
        {
            _busGarageRepository = repository;


            
        }


        public async Task<bool> Create(BusGarage busGarage)
        {
            await _busGarageRepository.Create(busGarage);

            var savedSuccesfully = await _busGarageRepository.SaveChangesAsync();

            return savedSuccesfully;

        }

        public async Task<bool> Update(BusGarage busGarage)
        {
            _busGarageRepository.Update(busGarage);

            var updatedSuccesful = await _busGarageRepository.SaveChangesAsync();
            return updatedSuccesful;
        }

        public async Task<BusGarage> GetById(int id)
        {
            var result = await _busGarageRepository.GetById(id);
            return result;

        }

        public async Task<bool> DeleteBusGarage(int id)
        {
            var result = await _busGarageRepository.GetById(id);
            result.IsDeleted = true;
            var deletedSuccesful = await _busGarageRepository.SaveChangesAsync();
            return deletedSuccesful;
        }

        public async Task<IList<BusGarage>> GetAll()
        {
            var result = (await _busGarageRepository.GetAll()).Where(x => x.IsDeleted == false).ToList();
            return result;
        }



        // Cars in BusGarage

    }

}

