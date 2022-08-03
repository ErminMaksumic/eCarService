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

    public class CarServiceController : BaseCRUDController<CarService, CarServiceSearchObject,
        CarServiceInsertRequest, CarServiceUpdateRequest>
    {
        public CarServiceController(ICarServiceService service) : base(service)
        { }

        [AllowAnonymous]
        public override CarService Insert([FromBody] CarServiceInsertRequest request)
        {
            return base.Insert(request);
        }
        [AllowAnonymous]
        public override async Task<IEnumerable<CarService>> Get([FromQuery] CarServiceSearchObject search)
        {
            return await base.Get(search);
        }
        [AllowAnonymous]
        public override CarService GetById(int id)
        {
            return base.GetById(id);
        }
    }
}
