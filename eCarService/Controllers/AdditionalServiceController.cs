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
        private readonly IAdditionalServiceService service;

        public AdditionalServiceController(IAdditionalServiceService service) : base(service)
        {
            this.service = service;
        }
        [HttpGet("Recommend/{id}")]
        public async Task<List<Model.AdditionalService>> Recommend(int id)
        {
            return await service.Recommend(id);
    }
    }

  
}
