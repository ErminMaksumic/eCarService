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

    public class AdditionalServiceController : BaseCRUDController<Model.AdditionalService, AdditionalServiceSearchObject,
        AdditionalServiceUpsertRequest, AdditionalServiceUpsertRequest>
    {
        public AdditionalServiceController(IAdditionalServiceService service) : base(service)
        {}
    }
}
