using DevAvaliacao.Domain.DataContext.Repositories;
using DevAvaliacao.Infra.DataContext;
using DevAvaliacao.Infra.Transactions.Repositories;

namespace DevAvaliacao.Infra.Transactions.UnityOfWork
{
    public class UnityOfWork : IUnityOfWork
    {
        private DevAvaliacaoDataContext _context;
        public UnityOfWork(DevAvaliacaoDataContext context)
        {
            _context = context;
            ConsultationRepository = new ConsultationRepository(context);
            DoctorRepository = new DoctorRepository(context);
            DoctorScheduleRepository = new DoctorScheduleRepository(context);
            PatientRepository = new PatientRepository(context);
            SpecialtyRepository = new SpecialtyRepository(context);
            UserRepository = new UserRepository(context); 
        }
        public IConsultationRepository ConsultationRepository { get; set; }
        public IDoctorRepository DoctorRepository { get ; set ; }
        public IDoctorScheduleRepository DoctorScheduleRepository { get ; set ; }
        public IPatientRepository PatientRepository { get ; set ; }
        public ISpecialtyRepository SpecialtyRepository { get ; set ; }
        public IUserRepository UserRepository { get ; set ; }

        public DevAvaliacaoDataContext context
        {
            get
            {
                if(_context == null)
                    _context = new DevAvaliacaoDataContext();
                return _context;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}