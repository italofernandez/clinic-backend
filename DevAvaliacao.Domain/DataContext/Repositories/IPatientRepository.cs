using DevAvaliacao.Domain.DataContext.Entities;

namespace DevAvaliacao.Domain.DataContext.Repositories
{
    public interface IPatientRepository : IRepository<Patient>
    {
        bool CpfExist(string cpf);   
    }
}