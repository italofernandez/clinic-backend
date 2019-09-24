using System.Linq;
using DevAvaliacao.Domain.DataContext.Entities;
using DevAvaliacao.Domain.DataContext.Repositories;
using DevAvaliacao.Infra.DataContext;

namespace DevAvaliacao.Infra.Transactions.Repositories
{
    public class SpecialtyRepository : ISpecialtyRepository
    {
        private DevAvaliacaoDataContext _context;
        public SpecialtyRepository(DevAvaliacaoDataContext context)
        {
            _context = context;
        }
        public void Add(Specialty entity)
        {
            _context.Specialties.Add(entity);
            _context.SaveChanges();
        }

        public IQueryable<Specialty> GetAll()
        {
            return _context.Specialties;
        }

        public Specialty GetById(int Id)
        {
            var specialty = _context.Specialties.SingleOrDefault(x=>x.Id == Id);
            if (Id == 1 && specialty == null)
            {
                Add(new Specialty { Id = Id, Name = "Clínico Geral" });
            }
            var createdSpecialty = _context.Specialties.SingleOrDefault(x=>x.Id == Id);
            return createdSpecialty;
        }

        public void Remove(int Id)
        {
            _context.Specialties.Remove(GetById(Id));
            _context.SaveChanges();
        }

        public void Update(Specialty entity)
        {
            _context.Specialties.Update(entity);
            _context.SaveChanges();
        }
    }
}