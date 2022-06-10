using eCarService.Model.Requests;
using eCarService.Model.SearchObjects;
using eCarService.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eCarService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Administrator, ServiceRegistered")]


    public class ReservationController : BaseCRUDController<Model.Reservation, BaseSearchObject, 
        ReservationInsertRequest, ReservationInsertRequest>
    {
        public ReservationController(IReservationService service) : base(service)
        { }
    }
}
