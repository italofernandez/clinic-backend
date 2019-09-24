using System.Linq;
using DevAvaliacao.Domain.DataContext.Entities;
using DevAvaliacao.Domain.DataContext.Repositories;
using DevAvaliacao.Infra.DataContext;

namespace DevAvaliacao.Infra.Transactions.Repositories
{
    public class DoctorScheduleRepository : IDoctorScheduleRepository
    {
        private DevAvaliacaoDataContext _context;
        public DoctorScheduleRepository(DevAvaliacaoDataContext context)
        {
            _context = context;
        }

        public void Add(DoctorSchedule entity)
        {
            _context.DoctorSchedules.Add(entity);
            _context.SaveChanges();
        }

        public IQueryable<DoctorSchedule> GetAll()
        {
            return _context.DoctorSchedules;
        }

        public DoctorSchedule GetById(int Id)
        {
            return _context.DoctorSchedules.SingleOrDefault(x=>x.Id == Id);
        }

        public void Remove(int Id)
        {
            _context.DoctorSchedules.Remove(GetById(Id));
            _context.SaveChanges();
        }

        public void Update(DoctorSchedule entity)
        {
            _context.DoctorSchedules.Update(entity);
            _context.SaveChanges();
        }
    }
}