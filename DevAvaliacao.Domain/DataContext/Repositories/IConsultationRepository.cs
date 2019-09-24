using DevAvaliacao.Domain.DataContext.Entities;

namespace DevAvaliacao.Domain.DataContext.Repositories
{
    public interface IConsultationRepository : IRepository<Consultation>
    {
        bool AddCheckingForAvailableTime(Consultation consultation);
    }
}