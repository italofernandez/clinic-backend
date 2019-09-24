using DevAvaliacao.Domain.DataContext.Entities;
using DevAvaliacao.Shared.Configurations;
using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;

namespace DevAvaliacao.Infra.DataContext
{
    public class DevAvaliacaoDataContext : DbContext
    {
        public DbSet<Consultation> Consultations { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<DoctorSchedule> DoctorSchedules { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Specialty> Specialties { get; set; }
        public DbSet<User> Users { get; set; }

        // TODO Adicionar referência ao PostgreSQL
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql(Settings.ConnectionString);

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Ignore<Notification>();
        }
    }
}