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
    public class CustomOfferRequestService : CRUDService<Model.CustomOfferRequest, CustomOfferSearchObject,
        Database.CustomOfferRequest, CustomOfferUpsertRequest, CustomOfferUpsertRequest>, ICustomOfferRequestService
    {
        public CustomOfferRequestService(eCarServiceContext context, IMapper mapper) : base(context, mapper)
        {}

        public override IQueryable<CustomOfferRequest> AddFilter(IQueryable<CustomOfferRequest> query, CustomOfferSearchObject search = null)
        {
            var filteredQuery = base.AddFilter(query, search);

            if (search.CarServiceId != null && search.CarServiceId != 0)
            {
                filteredQuery = filteredQuery.Where(x => x.CarServiceId == search.CarServiceId);
            }
            if (!string.IsNullOrWhiteSpace(search.Name))
            {
                filteredQuery = filteredQuery.Where(x => x.Name.StartsWith(search.Name));
            }
            return filteredQuery;
        }

        public Model.CustomOfferRequest ChangeStatus(int id, string status)
        {
            var entity = _context.CustomOfferRequests.Find(id);

            entity.Status = status;

            _context.SaveChanges();

            return _mapper.Map<Model.CustomOfferRequest>(entity);
        }

        public override Model.CustomOfferRequest GetById(int id)
        {
            var entity = _context.CustomOfferRequests.Include("User").FirstOrDefault(x=> x.CustomReqId == id);

            return _mapper.Map<Model.CustomOfferRequest>(entity);
        }

        public override IQueryable<CustomOfferRequest> AddInclude(IQueryable<CustomOfferRequest> query, CustomOfferSearchObject search = null)
        {
            return query.Include("User");
        }
    }
}
