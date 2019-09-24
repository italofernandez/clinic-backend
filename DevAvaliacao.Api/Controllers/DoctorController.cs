using DevAvaliacao.Domain.DataContext.Entities;
using DevAvaliacao.Domain.DataContext.Enums;
using DevAvaliacao.Domain.DataContext.Services;
using Microsoft.AspNetCore.Mvc;

namespace DevAvaliacao.Api.Controllers
{
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private IDoctorService _service;
        public DoctorController(IDoctorService service)
        {
            _service = service;
        }
        [HttpGet]
        [Route("api/doctors/{id}")]
        public ActionResult GetById(int id)
        {
            var result = _service.GetById(id);
            if (result.Status == EResultStatus.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpGet]
        [Route("api/doctors")]
        public ActionResult GetAll()
        {
            var result = _service.GetAll();
            return Ok(result);
        }

        [HttpPost]
        [Route("api/doctors")]
        public ActionResult Save([FromBody] Doctor doctor)
        {
            var result = _service.Save(doctor);
            if (result.Status == EResultStatus.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }
    }
}