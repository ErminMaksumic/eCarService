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
    [Authorize]

    public class UserController : BaseCRUDController<Model.User, UserSearchObject,
        UserInsertRequest, UserUpdateRequest>
    {
        private readonly IUserService _service;
        public UserController(IUserService service) :
            base(service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public override User Insert([FromBody] UserInsertRequest request)
        {
            return base.Insert(request);
        }

        [Authorize(Roles = "Administrator")]
        public override User Delete(int id)
        {
            return base.Delete(id);
        }

        public override IEnumerable<User> Get([FromQuery] UserSearchObject search)
        {
            return base.Get(search);
        }

        [HttpPut("changePassword/{id}")]
        public Model.User ChangePassword(int id, [FromBody] MyProfileUpdateRequest req)
        {
            return _service.ChangePassword(id, req);
        }

        [HttpPut("changeRole/{id}")]
        public Model.User ChangeRole(int id, [FromBody] RoleUpdateRequest req)
        {
            return _service.ChangeRole(id, req.RoleId);
        }

    }
}
