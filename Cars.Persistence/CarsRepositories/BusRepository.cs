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
    public class BusRepository
    {
        #region Properties

        private readonly IRepository<Bus> _busRepository;

        public BusRepository(IRepository<Bus> repository)
        {
            _busRepository = repository;

        }
        #endregion

        #region Actions

        public async Task<bool> Create(Bus model)
        {
            await _busRepository.Create(model);

            var savedSuccessful = await _busRepository.SaveChangesAsync();

            return savedSuccessful;
        }

        public async Task<IList<Bus>> GetAll()
        {
            var result = (await _busRepository.GetAll()).Where(x => x.IsDeleted == false).ToList();
            return result;
        }


        public async Task<Bus> GetById(int id)
        {
            var user = await _busRepository.GetById(id);
            return user;
        }

        public async Task<bool> Update(Bus model)
        {
            _busRepository.Update(model);
            var updatedSuccesful = await _busRepository.SaveChangesAsync();
            return updatedSuccesful;
        }

        public void Delete(Bus model)
        {
            _busRepository.Delete(model);

        }

        public async Task<bool> DeleteBus(int id)
        {
            var result = await _busRepository.GetById(id);
            result.IsDeleted = true;
            var deletedSuccesful = await _busRepository.SaveChangesAsync();
            return deletedSuccesful;
        }
        #endregion
    }
}
