using eCarService.Model.Requests;
using eCarService.Model.SearchObjects;
using eCarService.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace eCarService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : BaseCRUDController<Model.Reservation, BaseSearchObject, 
        ReservationInsertRequest, ReservationInsertRequest>
    {
        public ReservationController(IReservationService service) : base(service)
        { }
    }
}
