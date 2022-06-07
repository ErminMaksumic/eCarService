using AutoMapper;
using eCarService.Database;
using eCarService.Model.Requests;
using eCarService.Model.SearchObjects;
using eCarService.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCarService.Service.Implementation
{
    public class CarServiceService : CRUDService<Model.CarService, CarServiceSearchObject, Database.CarService,
        CarServiceInsertRequest, CarServiceUpdateRequest>, ICarServiceService
    {
        public CarServiceService(eCarServiceContext context, IMapper mapper) : base(context, mapper)
        { }

        public override IQueryable<CarService> AddFilter(IQueryable<CarService> query, CarServiceSearchObject searchObject = null)
        {
            var filteredQuery = base.AddFilter(query, searchObject);

            if (!string.IsNullOrWhiteSpace(searchObject.Name))
            {
                filteredQuery = filteredQuery.Where(x => x.Address.StartsWith(searchObject.Name));
            }
            if (searchObject?.UserId != null && searchObject.UserId!=0)
            {
                filteredQuery = filteredQuery.Where(x => x.UserId == searchObject.UserId);
            }

            return filteredQuery;
        }

        public override void BeforeDelete(CarService entity)
        {
            var parts = _context.Parts.Where(x => x.CarServiceId == entity.CarServiceId).ToList();

            if(parts != null)
            {
                foreach (var item in parts)
                {
                    _context.Parts.Remove(item);
                    _context.SaveChanges();
                }
            }

            var brands = _context.CarBrands.Where(x => x.CarServiceId == entity.CarServiceId).ToList();

            if (brands != null)
            {
                foreach (var item in brands)
                {
                    _context.CarBrands.Remove(item);
                    _context.SaveChanges();
                }
            }

            var offers = _context.Offers.Where(x => x.CarServiceId == entity.CarServiceId).ToList();

            if (offers != null)
            {
                foreach (var item in offers)
                {
                    _context.Offers.Remove(item);
                    _context.SaveChanges();
                }
            }
        }
   


    }
}
