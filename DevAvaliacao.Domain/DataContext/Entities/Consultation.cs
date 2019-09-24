using System;
using Flunt.Validations;

namespace DevAvaliacao.Domain.DataContext.Entities
{
    public class Consultation : Entity
    {
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public int UserId { get; set; }
        public string Specialty { get; set; }
        public DateTime ScheduledTime { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual Doctor Doctor { get; set; }
        public virtual User User { get; set; }

        bool Validate()
        {
            AddNotifications(new Contract()
                .IsGreaterOrEqualsThan(ScheduledTime, DateTime.Now, "ScheduledTime", "Impossível marcar em data retroativa")
                .IsNotNullOrEmpty(Specialty, "Specialty", "Informe a especialidade")
            );
            return Valid;
        }
    }
}