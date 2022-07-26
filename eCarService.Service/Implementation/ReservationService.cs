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

            return filteredQuery.Include("Offer").Include("CarBrand");
        }

        //public override IQueryable<Reservation> AddInclude(IQueryable<Reservation> query, OrderSearchObject search = null)
        //{
        //    if (!string.IsNullOrWhiteSpace(search.Include))
        //        query.Include(search.Include);

        //    return query;
        //}

        public override void BeforeDelete(Reservation entity)
        {
            var reservationAdditionalServices = _context.ReservationsAdditionalServices.Where(x => x.ReservationId == entity.ReservationId);

            _context.RemoveRange(reservationAdditionalServices);
        }

    }
}
