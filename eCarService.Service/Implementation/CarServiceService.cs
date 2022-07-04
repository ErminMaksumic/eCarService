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

        public override Model.CarService Delete(int id)
        {
            var entity = _context.CarServices.Include("User").Include("User.Role").FirstOrDefault(x=> x.CarServiceId == id);

            if (entity != null)
            {
                BeforeDelete(entity);
                _context.Remove(entity);

                _context.SaveChanges();
            }

            return _mapper.Map<Model.CarService>(entity);
        }

        public override void BeforeDelete(CarService entity)
        {
            if (entity?.User?.Role?.Name == "Administrator")
            {
                throw new UserException("You cannot delete Administrator's service");
            }

            DeleteItems(entity);
        }

        private void DeleteItems(CarService entity)
        {
            var parts = _context.Parts.Where(x => x.CarServiceId == entity.CarServiceId).ToList();

            if (parts != null)
            {
                foreach (var item in parts)
                {
                    _context.Parts.Remove(item);
                }
            }

            var brands = _context.CarBrands.Where(x => x.CarServiceId == entity.CarServiceId).ToList();

            if (brands != null)
            {
                foreach (var item in brands)
                {
                    _context.CarBrands.Remove(item);
                }
            }

            var offers = _context.Offers.Where(x => x.CarServiceId == entity.CarServiceId).ToList();

            if (offers != null)
            {
                foreach (var item in offers)
                {
                    _context.Offers.Remove(item);
                }
            }
               
            _context.SaveChanges();
        }

        public override Model.CarService Insert(CarServiceInsertRequest request)
        {
            if (request != null)
            {
                return base.Insert(request);
            }

            return null;
        }

        public override IQueryable<CarService> AddInclude(IQueryable<CarService> query, CarServiceSearchObject search = null)
        {
            return query.Include("User");
        }



    }
}
