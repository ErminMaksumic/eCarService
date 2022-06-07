using eCarService.Model.Requests;
using eCarService.Model.SearchObjects;
using eCarService.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCarService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingController : BaseCRUDController<Model.Rating, BaseSearchObject, RatingUpsertRequest,
        RatingUpsertRequest>
    {
        public RatingController(IRatingService service): base(service)
        {}
    }
}
