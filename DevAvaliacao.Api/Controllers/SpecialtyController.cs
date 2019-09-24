using DevAvaliacao.Domain.DataContext.Entities;
using DevAvaliacao.Domain.DataContext.Services;
using Microsoft.AspNetCore.Mvc;

namespace DevAvaliacao.Api.Controllers
{
    public class SpecialtyController : ControllerBase
    {
        private ISpecialtyService _service;
        public SpecialtyController(ISpecialtyService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("api/specialties")]
        public ActionResult GetAll()
        {
            var result = _service.GetAll();
            return Ok(result);
        }

        [HttpPost]
        [Route("api/specialties")]
        public ActionResult Save([FromBody] Specialty specialty)
        {
            var result = _service.Save(specialty);
            if(result.Status == Domain.DataContext.Enums.EResultStatus.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }
    }
}