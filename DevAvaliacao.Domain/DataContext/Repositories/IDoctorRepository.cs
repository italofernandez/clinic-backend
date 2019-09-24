using DevAvaliacao.Domain.DataContext.Entities;

namespace DevAvaliacao.Domain.DataContext.Repositories
{
    public interface IDoctorRepository : IRepository<Doctor>
    {
        bool CrmExist(string crm);
    }
}