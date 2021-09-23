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
    public class ReservationService
    {
        private readonly ReservationRepository _reservationRepository;


        public ReservationService(IRepository<Reservation> repository)
        {
            _reservationRepository = new ReservationRepository(repository);

        }

        public async Task<bool> Create(Reservation busGarage)
        {
            var result = await _reservationRepository.Create(busGarage);

            return result;
        }

        public async Task<bool> Update(Reservation busGarage)
        {
            var updatedSuccefully = await _reservationRepository.Update(busGarage);


            return updatedSuccefully;
        }

        public async Task<IList<Reservation>> GetAll()
        {
            var result = await _reservationRepository.GetAll();

            return result;
        }

        public async Task<Reservation> GetById(int id)
        {
            var result = await _reservationRepository.GetById(id);

            return result;

        }

        public async Task<bool> DeleteReservation(int id)
        {
            var deleted = await _reservationRepository.DeleteReservation(id);
            return deleted;
        }
    }

}
