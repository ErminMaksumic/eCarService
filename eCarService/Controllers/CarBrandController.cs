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

    public class CarBrandController : BaseCRUDController<Model.CarBrand, CarBrandSearchObject,
        CarBrandUpsertRequest, CarBrandUpsertRequest>
    {
        public CarBrandController(ICarBrandService service) 
            : base(service)
        { }
    }
}
