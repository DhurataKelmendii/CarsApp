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
    public class BusService
    {

        private readonly BusRepository _busRepository;
        //private readonly IRepository<Bus> _repository;


        public BusService(IRepository<Bus> repository)
        {
            _busRepository = new BusRepository(repository);

        }

        public async Task<bool> Create(Bus bus)
        {
            var result = await _busRepository.Create(bus);

            return result;
        }

        public async Task<bool> Update(Bus bus)
        {
            var updatedSuccefully = await _busRepository.Update(bus);


            return updatedSuccefully;
        }

        //public async Task<bool> Delete(Bus Bus)
        //{
        //    _BusRepository.Delete(Bus);

        //    var deleted = await _repository.SaveChangesAsync();

        //    return deleted;
        //}

        public async Task<IList<Bus>> GetAll()
        {
            var result = await _busRepository.GetAll();

            return result;
        }

        public async Task<Bus> GetById(int id)
        {
            var result = await _busRepository.GetById(id);

            return result;

        }

        public async Task<bool> DeleteBus(int id)
        {
            var deleted = await _busRepository.DeleteBus(id);
            return deleted;
        }
    }
}
