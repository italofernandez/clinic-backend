using DevAvaliacao.Domain.DataContext.Entities;
using DevAvaliacao.Domain.DataContext.Services;
using Microsoft.AspNetCore.Mvc;

namespace DevAvaliacao.Api.Controllers
{
    [ApiController]
    public class DoctorScheduleController : ControllerBase
    {
        private IDoctorScheduleService _service;
        public DoctorScheduleController(IDoctorScheduleService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("api/doctorSchedule")]
        public ActionResult Save([FromBody] DoctorSchedule doctorSchedule)
        {
            var result = _service.Save(doctorSchedule);
            if(result.Status == Domain.DataContext.Enums.EResultStatus.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpGet]
        [Route("api/doctorSchedule/{doctorId}")]
        public ActionResult GetByDoctorId(int doctorId)
        {
            var result = _service.GetByDoctorId(doctorId);
            return Ok(result);
        }
    }
}