using eCarService.Model;
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
    [Authorize(Roles = "Administrator, ServiceRegistered")]

    public class OfferController : BaseCRUDController<Model.Offer, OfferSearchObject, OfferUpsertRequest,
        OfferUpsertRequest>
    {
        public OfferController(IOfferService service) : base(service)
        { }
        [AllowAnonymous]
        public override Offer Insert([FromBody] OfferUpsertRequest request)
        {
            return base.Insert(request);
        }
    }
}
