using System.Linq;
using DevAvaliacao.Domain.DataContext.Entities;
using DevAvaliacao.Domain.DataContext.Repositories;
using DevAvaliacao.Infra.DataContext;
using Microsoft.EntityFrameworkCore;

namespace DevAvaliacao.Infra.Transactions.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        private DevAvaliacaoDataContext _context;
        public DoctorRepository(DevAvaliacaoDataContext context)
        {
            _context = context;
        }
        public void Add(Doctor entity)
        {
            _context.Doctors.Add(entity);
        }

        public bool CrmExist(string crm)
        {
            return _context.Doctors.Any(x=>x.CRM == crm);
        }

        public IQueryable<Doctor> GetAll()
        {
            return _context.Doctors;
        }

        public Doctor GetById(int Id)
        {
            return _context.Doctors.Include(x=>x.Specialty).SingleOrDefault(x=>x.Id == Id);
        }

        public void Remove(int Id)
        {
            _context.Doctors.Remove(GetById(Id));
        }

        public void Update(Doctor entity)
        {
            _context.Doctors.Update(entity);
        }
    }
}