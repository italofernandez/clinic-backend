using System.Collections.Generic;
using DevAvaliacao.Domain.DataContext.Entities;

namespace DevAvaliacao.Domain.DataContext.Services
{
    public interface IDoctorScheduleService : IService<DoctorSchedule>
    {
        IEnumerable<DoctorSchedule> GetByDoctorId(int doctorId);
    }
}