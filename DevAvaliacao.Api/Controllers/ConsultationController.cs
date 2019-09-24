using DevAvaliacao.Domain.DataContext.Entities;
using DevAvaliacao.Domain.DataContext.Services;
using Microsoft.AspNetCore.Mvc;

namespace DevAvaliacao.Api.Controllers
{
    [ApiController]
    public class ConsultationController : ControllerBase
    {
        private IConsultationService _service;
        public ConsultationController(IConsultationService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("api/consultations")]
        public ActionResult Save([FromBody] Consultation consultation)
        {
            var result = _service.Save(consultation);
            if(result.Status == Domain.DataContext.Enums.EResultStatus.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }
    }
    
}