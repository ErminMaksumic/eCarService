using eCarService.Model.Requests;
using eCarService.Model.SearchObjects;
using eCarService.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eCarService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class CustomOfferRequestController : BaseCRUDController<Model.CustomOfferRequest, CustomOfferSearchObject,
        Model.Requests.CustomOfferUpsertRequest, Model.Requests.CustomOfferUpsertRequest>
    {
        private readonly ICustomOfferRequestService _service;

        public CustomOfferRequestController(ICustomOfferRequestService service) : base(service)
        {
            _service = service;

        }

        [HttpPut("changeStatus/{id}")]
        public Model.CustomOfferRequest ChangeStatus(int id, [FromBody] ChangeStatusRequest req)
        {
            return _service.ChangeStatus(id, req.Status);
        }

    }
}
