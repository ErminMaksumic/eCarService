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
    public class OfferController : BaseCRUDController<Model.Offer, OfferSearchObject, OfferInsertRequest,
        OfferInsertRequest>
    {
        public OfferController(IOfferService service) : base(service)
        { }
        [AllowAnonymous]
        public override Offer Insert([FromBody] OfferInsertRequest request)
        {
            return base.Insert(request);
        }
    }
}
