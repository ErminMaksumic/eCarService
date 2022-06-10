using eCarService.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eCarService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class BaseController<T, TSearch> : ControllerBase where T : class where TSearch : class
    { 
        public readonly IBaseService<T, TSearch> _service;
        public BaseController(IBaseService<T, TSearch> service)
        {
            _service = service;
        }
        [HttpGet]
        virtual public IEnumerable<T> Get([FromQuery] TSearch search)
        {
            return _service.Get(search);
        }
        [HttpGet("{id}")]

        virtual public T GetById(int id)
        {
            return _service.GetById(id);
        }

       
    }
}