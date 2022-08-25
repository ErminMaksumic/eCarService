using eCarService.Model;
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


    public class ReservationController : BaseCRUDController<Model.Reservation, OrderSearchObject, 
        ReservationInsertRequest, ReservationInsertRequest>
    {
        private readonly IReservationService _service;

        public ReservationController(IReservationService service) : base(service)
        {
            this._service = service;
        }


        [HttpPut("changeStatus/{id}")]
        public Model.Reservation ChangeStatus(int id, [FromBody] ChangeStatusRequest req)
        {
            return _service.ChangeStatus(id, req.Status);
        }

    }

}
