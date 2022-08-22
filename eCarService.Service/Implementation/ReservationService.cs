using AutoMapper;
using eCarService.Database;
using eCarService.Model.Requests;
using eCarService.Model.SearchObjects;
using eCarService.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCarService.Service.Implementation
{
    public class ReservationService : CRUDService<Model.Reservation, OrderSearchObject, Database.Reservation,
        ReservationInsertRequest, ReservationInsertRequest>, IReservationService
    {
        public ReservationService(eCarServiceContext context, IMapper mapper) : base(context, mapper)
        {}

        public override Model.Reservation Insert(ReservationInsertRequest request)
        {
            var reservation = _mapper.Map<Database.Reservation>(request);

            _context.Reservations.Add(reservation);
            _context.SaveChanges();

            foreach (var reservationAdditionalService in request.AdditionalServices)
            {
                Database.ReservationsAdditionalService reservationAdditionalServiceObject = new ReservationsAdditionalService();
                reservationAdditionalServiceObject.AdditionalServiceId = reservationAdditionalService;
                reservationAdditionalServiceObject.ReservationId = reservation.ReservationId;

                _context.ReservationsAdditionalServices.Add(reservationAdditionalServiceObject);

                _context.SaveChanges();
            }

            return _mapper.Map<Model.Reservation>(reservation);
        }

        public override IQueryable<Reservation> AddFilter(IQueryable<Reservation> query, OrderSearchObject search = null)
        {
            var filteredQuery = base.AddFilter(query, search);

            if (search.CarServiceId != null && search.CarServiceId != 0)
            {
                filteredQuery = filteredQuery.Where(x => x.Offer.CarServiceId == search.CarServiceId);
            }
            if (search.From != null && search.To != null)
            {
                filteredQuery = filteredQuery.Where(x => x.Date > search.From && x.Date < search.To);
            }
            if (!string.IsNullOrWhiteSpace(search.Name))
            {
                filteredQuery = filteredQuery.Where(x => x.Offer.Name.StartsWith(search.Name));
            }

            return filteredQuery.Include("Offer").Include("CarBrand").Include("ReservationsAdditionalServices")
                .Include("ReservationsAdditionalServices.AdditionalService");
        }

        public override IQueryable<Reservation> AddInclude(IQueryable<Reservation> query, OrderSearchObject search = null)
        {
            var filteredQuery = base.AddInclude(query, search);

            filteredQuery = filteredQuery.Include("ReservationsAdditionalServices");

            if (!string.IsNullOrWhiteSpace(search.Include))
                filteredQuery = filteredQuery.Include(search.Include);

            return filteredQuery;
        }

        public override void BeforeDelete(Reservation entity)
        {
            var reservationAdditionalServices = _context.ReservationsAdditionalServices.Where(x => x.ReservationId == entity.ReservationId);

            _context.RemoveRange(reservationAdditionalServices);
        }

        public Model.Reservation ChangeStatus(int id, string status)
        {
            var entity = _context.Reservations.Find(id);

            if (entity != null)
                entity.Status = status;

            _context.SaveChanges();

            return _mapper.Map<Model.Reservation>(entity);
        }

    }
}
