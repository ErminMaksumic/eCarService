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
        public class AdditionalServiceService : CRUDService<Model.AdditionalService, AdditionalServiceSearchObject,
        Database.AdditionalService, AdditionalServiceUpsertRequest, AdditionalServiceUpsertRequest>, 
        IAdditionalServiceService
    {
        public AdditionalServiceService(eCarServiceContext context, IMapper mapper) : base(context, mapper)
        {}

        public override IQueryable<AdditionalService> AddFilter(IQueryable<AdditionalService> query, AdditionalServiceSearchObject search = null)
        {
            var filteredQuery = base.AddFilter(query, search);

            if(!string.IsNullOrWhiteSpace(search.Name))
            {
                filteredQuery = filteredQuery.Where(x => x.Name.StartsWith(search.Name));
            }

            return filteredQuery;
        }
    }
}
