using System.Linq;
using DevAvaliacao.Domain.DataContext.Entities;
using DevAvaliacao.Domain.DataContext.Repositories;
using DevAvaliacao.Infra.DataContext;

namespace DevAvaliacao.Infra.Transactions.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private DevAvaliacaoDataContext _context;
        public PatientRepository(DevAvaliacaoDataContext context)
        {
            _context = context;
        }
        public void Add(Patient entity)
        {
            _context.Patients.Add(entity);
        }

        public bool CpfExist(string cpf)
        {
            return _context.Patients.Any(x => x.CPF == cpf);
        }

        public IQueryable<Patient> GetAll()
        {
            return _context.Patients;
        }

        public Patient GetById(int Id)
        {
            return _context.Patients.SingleOrDefault(x => x.Id == Id);
        }

        public void Remove(int Id)
        {
            _context.Patients.Remove(GetById(Id));
        }

        public void Update(Patient entity)
        {
            _context.Patients.Update(entity);
        }
    }
}