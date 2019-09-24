using System;
using DevAvaliacao.Domain.DataContext.Repositories;
using DevAvaliacao.Infra.DataContext;

namespace DevAvaliacao.Infra.Transactions.UnityOfWork
{
    public interface IUnityOfWork : IDisposable
    {
        IConsultationRepository ConsultationRepository { get; set; }
        IDoctorRepository DoctorRepository { get; set; }
        IDoctorScheduleRepository DoctorScheduleRepository { get; set; }
        IPatientRepository PatientRepository { get; set; }
        ISpecialtyRepository SpecialtyRepository { get; set; }
        IUserRepository UserRepository { get; set; }

        DevAvaliacaoDataContext context { get; }
        void SaveChanges();
    }
}