using AutoMapper;
using eCarService.Database;
using eCarService.Model.Helpers;
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
    public class CarBrandService: CRUDService<Model.CarBrand, CarBrandSearchObject, Database.CarBrand,
        CarBrandUpsertRequest, CarBrandUpsertRequest>, ICarBrandService
    {
        public CarBrandService(eCarServiceContext context, IMapper mapper) : base(context, mapper)
        { }

        public override IQueryable<CarBrand> AddFilter(IQueryable<CarBrand> query, CarBrandSearchObject search = null)
        {
            var filteredQuery = base.AddFilter(query, search);

            if (!string.IsNullOrEmpty(search?.Name))
            {
                filteredQuery = filteredQuery.Where(x => x.Name.StartsWith(search.Name));
            }
            if (search?.CarServiceId != null && search?.CarServiceId != 0)
            {
                filteredQuery = filteredQuery.Where(x => x.CarServiceId == search.CarServiceId);
            }

            return filteredQuery;
        }

        public override void BeforeDelete(CarBrand entity)
        {
            if (_context.CarBrands.Where(x=> x.CarServiceId == entity.CarServiceId).ToList().Count() == 1)
                throw new UserException("You must have at least 1 car brand!");

            if (_context.CarBrandOffers.Where(x => x.CarBrandId == entity.CarBrandId).ToList().Count() > 0)
                throw new UserException("One or more offers contains this brand! Unselect brand in that offers first!");


            var reservations = _context.Reservations.Where(x => x.CarBrandId == entity.CarBrandId);

            foreach (var item in reservations)
            {
                item.CarBrandId = null;
            }
        }

    }
}
