using DevAvaliacao.Domain.DataContext.Entities;
using DevAvaliacao.Domain.DataContext.Enums;
using DevAvaliacao.Domain.DataContext.Services;
using Microsoft.AspNetCore.Mvc;

namespace DevAvaliacao.Api.Controllers
{
    [ApiController]
    public class PatientController : ControllerBase
    {
        private IPatientService _service;
        public PatientController(IPatientService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("api/patients/{id}")]
        public ActionResult GetById(int id)
        {
            var result = _service.GetById(id);
            if (result.Status == EResultStatus.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpGet]
        [Route("api/patients")]
        public ActionResult GetAll()
        {
            var result = _service.GetAll();
            return Ok(result);
        }
        
        [HttpPost]
        [Route("api/patients")]
        public ActionResult Save([FromBody] Patient patient)
        {
            var result = _service.Save(patient);
            if(result.Status == EResultStatus.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }
    }
}