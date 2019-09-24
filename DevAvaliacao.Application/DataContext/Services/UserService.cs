using System.Collections.Generic;
using DevAvaliacao.Domain.DataContext.Entities;
using DevAvaliacao.Domain.DataContext.Models;
using DevAvaliacao.Domain.DataContext.Services;
using DevAvaliacao.Infra.Transactions.UnityOfWork;

namespace DevAvaliacao.Application.DataContext.Services
{
    public class UserService : IUserService
    {
        private IUnityOfWork _uow;
        public UserService(IUnityOfWork uow)
        {
            _uow = uow;
        }
        public IEnumerable<User> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public ResponseModel GetById(int Id)
        {
            throw new System.NotImplementedException();
        }

        public ResponseModel GetWithFilters(User entity)
        {
            throw new System.NotImplementedException();
        }

        public ResponseModel GetWithFiltersAndPagination(int pageSize, int pageNumber, User entity = null)
        {
            throw new System.NotImplementedException();
        }

        public ResponseModel GetWithPagination(int pageSize, int pageNumber)
        {
            throw new System.NotImplementedException();
        }

        public ResponseModel Remove(int Id)
        {
            throw new System.NotImplementedException();
        }

        public ResponseModel Save(User entity)
        {
            _uow.UserRepository.Add(entity);
            return new ResponseModel
            {
                Location = $"api/users/{entity.Id}",
                Message = "Usuário gravado com sucesso"
            };
        }

        public ResponseModel Update(User entity)
        {
            throw new System.NotImplementedException();
        }
    }
}