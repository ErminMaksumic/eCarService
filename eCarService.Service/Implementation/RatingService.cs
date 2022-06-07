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
    public class RatingService : CRUDService<Model.Rating, BaseSearchObject, Database.Rating, RatingUpsertRequest,
        RatingUpsertRequest>, IRatingService
    {
        public RatingService(eCarServiceContext context, IMapper mapper) : base(context, mapper)
        {}
    }
}
