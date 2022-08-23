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

    public class PaymentController : BaseCRUDController<Model.Payment, BaseSearchObject,
        PaymentUpsertRequest, PaymentUpsertRequest>
    {
        public PaymentController(IPaymentService service)
            : base(service)
        { }
    }
}
