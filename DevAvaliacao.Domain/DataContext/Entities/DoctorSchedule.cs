using System;
namespace DevAvaliacao.Domain.DataContext.Entities
{
    public class DoctorSchedule : Entity
    {
        public int DoctorId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public virtual Doctor Doctor { get; set; }
    }
}