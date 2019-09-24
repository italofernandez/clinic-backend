using System;
using System.Linq;
using DevAvaliacao.Domain.DataContext.Entities;
using DevAvaliacao.Domain.DataContext.Repositories;
using DevAvaliacao.Infra.DataContext;

namespace DevAvaliacao.Infra.Transactions.Repositories
{
    public class ConsultationRepository : IConsultationRepository
    {
        private DevAvaliacaoDataContext _context;
        public ConsultationRepository(DevAvaliacaoDataContext context)
        {
            _context = context;
        }
        public void Add(Consultation entity)
        {
            if (AnyTimeAvailable(entity.ScheduledTime))
            {
                _context.Consultations.Add(entity);
                _context.SaveChanges();
            }
        }

        public IQueryable<Consultation> GetAll()
        {
            return _context.Consultations;
        }

        public Consultation GetById(int Id)
        {
            return _context.Consultations.SingleOrDefault(x => x.Id == Id);
        }

        public void Remove(int Id)
        {
            _context.Consultations.Remove(GetById(Id));
            _context.SaveChanges();
        }

        public void Update(Consultation entity)
        {
            _context.Consultations.Update(entity);
            _context.SaveChanges();
        }

        public bool AnyTimeAvailable(DateTime TimeToCheck)
        {
            bool hasAvailableTime = false;

            hasAvailableTime = _context.DoctorSchedules.Any(x =>
                x.StartTime <= TimeToCheck &&
                x.EndTime >= TimeToCheck.AddMinutes(15));
            if (hasAvailableTime)
            {
                hasAvailableTime = !_context.Consultations.Any(x =>
                    x.ScheduledTime >= TimeToCheck || 
                    x.ScheduledTime.AddMinutes(15) >= TimeToCheck.AddMinutes(15));
            }

            return hasAvailableTime;
        }

        public bool AddCheckingForAvailableTime(Consultation consultation)
        {
            var result = AnyTimeAvailable(consultation.ScheduledTime);
            if (result)
            {
                _context.Consultations.Add(consultation);
                _context.SaveChanges();
            }
            return result;
        }
    }
}