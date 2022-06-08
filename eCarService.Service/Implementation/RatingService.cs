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
    public class RatingService : CRUDService<Model.Rating, RatingSearchObject, Database.Rating, RatingUpsertRequest,
        RatingUpsertRequest>, IRatingService
    {
        public RatingService(eCarServiceContext context, IMapper mapper) : base(context, mapper)
        {}

        public override IQueryable<Rating> AddFilter(IQueryable<Rating> query, RatingSearchObject search = null)
        {
            var filteredQuery = base.AddFilter(query, search);

            if (search.UserId != null && search.UserId != 0)
            {
                filteredQuery = filteredQuery.Where(x=> x.UserId == search.UserId);
            }
          

            return filteredQuery;
        }
    }
}
