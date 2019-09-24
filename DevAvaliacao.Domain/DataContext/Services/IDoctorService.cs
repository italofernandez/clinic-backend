using DevAvaliacao.Domain.DataContext.Entities;

namespace DevAvaliacao.Domain.DataContext.Services
{
    public interface IDoctorService : IService<Doctor>
    {
        bool CrmExist(string crm);
    }
}