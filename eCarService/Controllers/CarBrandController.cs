using eCarService.Model;
using eCarService.Model.Requests;
using eCarService.Model.SearchObjects;
using eCarService.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCarService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarBrandController : BaseCRUDController<Model.CarBrand, CarBrandSearchObject,
        CarBrandUpsertRequest, CarBrandUpsertRequest>
    {
        public CarBrandController(ICarBrandService service) 
            : base(service)
        {}
    }
}
