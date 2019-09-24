using DevAvaliacao.Domain.DataContext.Entities;
using DevAvaliacao.Domain.DataContext.Services;
using Microsoft.AspNetCore.Mvc;

namespace DevAvaliacao.Api.Controllers
{
    public class UserController : ControllerBase
    {
        private IUserService _service;
        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("api/users")]
        public ActionResult Save([FromBody] User user)
        {
            var result = _service.Save(user);
            if(result.Status == Domain.DataContext.Enums.EResultStatus.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }
    }
}