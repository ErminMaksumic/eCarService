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
    public class PartService : CRUDService<Model.Part, PartSearchObject, Database.Part, PartUpsertRequest,
        PartUpsertRequest>, IPartService
    {
        public PartService(eCarServiceContext context, IMapper mapper) : base(context,mapper)
        {}

        public override IQueryable<Part> AddInclude(IQueryable<Part> query, PartSearchObject search = null)
        {
            var includedQuery = base.AddInclude(query, search);

            if (search.InclCarService)
            {
                includedQuery = includedQuery.Include("CarService");
            }

            return includedQuery;
        }

        public override IQueryable<Part> AddFilter(IQueryable<Part> query, PartSearchObject search = null)
        {
            var filteredQuery = base.AddFilter(query, search);

            if (search.CarServiceId!=null)
            {
                filteredQuery = filteredQuery.Where(x => x.CarServiceId == search.CarServiceId);
            }
            if (!string.IsNullOrWhiteSpace(search.Name))
            {
                filteredQuery = filteredQuery.Where(x => x.Name.StartsWith(search.Name));
            }
            return filteredQuery;

        }


    }
}
