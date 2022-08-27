using eCarService.Model.Requests;
using eCarService.Model.SearchObjects;
using eCarService.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCarService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Administrator, ServiceRegistered, Unregistered")] // unregistered == mobile

    public class RatingController : BaseCRUDController<Model.Rating, RatingSearchObject, RatingUpsertRequest,
        RatingUpsertRequest>
    {
        public RatingController(IRatingService service): base(service)
        {}
    }
}
