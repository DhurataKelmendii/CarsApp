using Cars.Domain.Entities;
using Cars.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Persistence.CarsRepositories
{
    public class ReservationRepository
    {
        #region Properties

        private readonly IRepository<Reservation> _reservationRepository;

        public ReservationRepository(IRepository<Reservation> repository)
        {
            _reservationRepository = repository;

        }
        #endregion

        #region Actions

        public async Task<bool> Create(Reservation model)
        {
            await _reservationRepository.Create(model);

            var savedSuccessful = await _reservationRepository.SaveChangesAsync();

            return savedSuccessful;
        }

        public async Task<IList<Reservation>> GetAll()
        {
            var result = (await _reservationRepository.GetAll()).Where(x => x.IsDeleted == false).ToList();
            return result;
        }


        public async Task<Reservation> GetById(int id)
        {
            var user = await _reservationRepository.GetById(id);
            return user;
        }

        public async Task<bool> Update(Reservation model)
        {
            _reservationRepository.Update(model);
            var updatedSuccesful = await _reservationRepository.SaveChangesAsync();
            return updatedSuccesful;
        }

        public async Task<bool> DeleteReservation(int id)
        {
            var result = await _reservationRepository.GetById(id);
            result.IsDeleted = true;
            var deletedSuccesful = await _reservationRepository.SaveChangesAsync();
            return deletedSuccesful;
        }
        #endregion
    }
}
