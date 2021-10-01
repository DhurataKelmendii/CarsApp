using Cars.Domain.Entities;
using Cars.Infrastructure.ViewModels;
using Cars.Persistence;
using Cars.Persistence.CarsRepositories;
using Cars.Persistence.Repositories;
using Cars.Service.CarsServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace CarsUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly ReservationService reservationService;

        public ReservationController(IRepository<Reservation> repository)
        {
            reservationService = new ReservationService(repository);
        }

        [HttpGet]
        [Route("ReservationsList")]
        public async Task<IActionResult> ReservationsList()
        {
            var model = new ReservationViewModel();
            var result = (await reservationService.GetAll()).Select(x => new ReservationViewModel
            {
                RezervationName = x.RezervationName,
                RezervationStartDate = x.RezervationStartDate,
                RezervationEndDate = x.RezervationEndDate,
                TotalBill = x.TotalBill,
                GarageName = x.GarageName,
                CarsUsing = x.CarsUsing,
                Id = x.Id,
                IsDeleted = x.IsDeleted
            }).ToList();

            model.Reservations = result;
            return Ok(model);
        }


        [HttpPost]
        [Route("CreateReservation")]
        public async Task<IActionResult> CreateReservation([FromBody] ReservationViewModel reservationViewModel)
        {
            if (reservationViewModel != null)
            {
                var model = new Reservation()
                {
                    Id = reservationViewModel.Id,
                    RezervationName = reservationViewModel.RezervationName,
                    RezervationStartDate = reservationViewModel.RezervationStartDate,
                    RezervationEndDate = reservationViewModel.RezervationEndDate,
                    TotalBill = reservationViewModel.TotalBill,
                    GarageName = reservationViewModel.GarageName,
                    CarsUsing = reservationViewModel.CarsUsing,
                    IsDeleted = reservationViewModel.IsDeleted
                };
                var saveSuccessful = await reservationService.Create(model);

                if (saveSuccessful)
                {
                    return Ok(true);
                }
                return Ok(false);
            }
            else
            {
                return BadRequest();
            }
        }


        [HttpPost]
        [Route("UpdateReservation")]
        public async Task<IActionResult> UpdateReservation(ReservationViewModel reservationViewModel)
        {
            if (reservationViewModel != null)
            {
                var model = new Reservation()
                {
                    Id = reservationViewModel.Id,
                    RezervationName = reservationViewModel.RezervationName,
                    RezervationStartDate = reservationViewModel.RezervationStartDate,
                    RezervationEndDate = reservationViewModel.RezervationEndDate,
                    TotalBill = reservationViewModel.TotalBill,
                    GarageName = reservationViewModel.GarageName,
                    CarsUsing = reservationViewModel.CarsUsing,
               
                };
                var saveSuccessful = await reservationService.Update(model);

                if (saveSuccessful)
                {
                    var viewModel = new ReservationViewModel();
                    var result = (await reservationService.GetAll()).Select(x => new ReservationViewModel
                    {
                        RezervationName = x.RezervationName,
                        RezervationStartDate = x.RezervationStartDate,
                        RezervationEndDate = x.RezervationEndDate,
                        TotalBill = x.TotalBill,
                        GarageName = x.GarageName,
                        CarsUsing = x.CarsUsing,
                        Id = x.Id,
                        IsDeleted = x.IsDeleted
                    }).ToList();

                    viewModel.Reservations = result;

                    return Ok(true);
                }
                return Ok(false);
            }
            else
            {
                return BadRequest(false);
            }
        }


        [HttpGet]
        [Route("GetReservationById/{id}")]
        public async Task<IActionResult> GetReservationById(int id)
        {
            if (id > 0)
            {
                var result = await reservationService.GetById(id);
                return Ok(result);
            }
            else
            {
                return BadRequest(null);
            }
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {

            var result = await reservationService.GetAll();
            return Ok(result);


        }

        [HttpPost]
        [Route("DeleteReservation/{id}")]
        public async Task<IActionResult> DeleteReservation(int id)
        {

            var result = await reservationService.DeleteReservation(id);

            var viewModel = new ReservationViewModel();
            var resultList = (await reservationService.GetAll()).Select(x => new ReservationViewModel
            {
                RezervationName = x.RezervationName,
                RezervationStartDate = x.RezervationStartDate,
                RezervationEndDate = x.RezervationEndDate,
                TotalBill = x.TotalBill,
                GarageName = x.GarageName,
                CarsUsing = x.CarsUsing,
                Id = x.Id,
                IsDeleted = x.IsDeleted
            }).ToList();

            viewModel.Reservations = resultList;
            return Ok(result);

        }

    }
}
