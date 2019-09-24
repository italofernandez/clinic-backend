using System.Linq;
using DevAvaliacao.Domain.DataContext.Entities;
using DevAvaliacao.Domain.DataContext.Repositories;
using DevAvaliacao.Infra.DataContext;

namespace DevAvaliacao.Infra.Transactions.Repositories
{
    public class UserRepository : IUserRepository
    {
        private DevAvaliacaoDataContext _context;
        public UserRepository(DevAvaliacaoDataContext context)
        {
            _context = context;
        }
        public void Add(User entity)
        {
            _context.Users.Add(entity);
            _context.SaveChanges();
        }

        public IQueryable<User> GetAll()
        {
            return _context.Users;
        }

        public User GetById(int Id)
        {
            return _context.Users.SingleOrDefault(x=>x.Id == Id);
        }

        public void Remove(int Id)
        {
            _context.Users.Remove(GetById(Id));
            _context.SaveChanges();
        }

        public void Update(User entity)
        {
            _context.Users.Update(entity);
            _context.SaveChanges();
        }
    }
}