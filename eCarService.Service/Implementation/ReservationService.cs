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
    public class ReservationService : CRUDService<Model.Reservation, BaseSearchObject, Database.Reservation,
        ReservationInsertRequest, ReservationInsertRequest>, IReservationService
    {
        public ReservationService(eCarServiceContext context, IMapper mapper) : base(context, mapper)
        {}

        public override IQueryable<Reservation> AddFilter(IQueryable<Reservation> query, BaseSearchObject search = null)
        {
            var filteredQuery = base.AddFilter(query, search);

            if (search.CarServiceId != null && search.CarServiceId != 0)
            {
                filteredQuery = filteredQuery.Where(x => x.Offer.CarServiceId == search.CarServiceId);
            }

            return filteredQuery.Include("Offer");
        }

    }
}
