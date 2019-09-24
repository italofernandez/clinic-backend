using DevAvaliacao.Domain.DataContext.Entities;

namespace DevAvaliacao.Domain.DataContext.Services
{
    public interface IPatientService : IService<Patient>
    {
        bool CpfExist(string cpf);
    }
}