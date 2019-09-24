using System.Collections.Generic;
using DevAvaliacao.Domain.DataContext.Entities;
using DevAvaliacao.Domain.DataContext.Models;
using DevAvaliacao.Domain.DataContext.Services;
using DevAvaliacao.Infra.Transactions.UnityOfWork;

namespace DevAvaliacao.Application.DataContext.Services
{
    public class SpecialtyService : ISpecialtyService
    {
        private IUnityOfWork _uow;
        public SpecialtyService(IUnityOfWork uow)
        {
            _uow = uow;
        }
        public IEnumerable<Specialty> GetAll()
        {
            return _uow.SpecialtyRepository.GetAll();
        }

        public ResponseModel GetById(int Id)
        {
            var specialty = _uow.SpecialtyRepository.GetById(Id);

            if (specialty == null)
            {
                return new ResponseModel
                {
                    Message = "Especialidade não encontrada",
                    Status = Domain.DataContext.Enums.EResultStatus.Failure
                };
            }
            else
            {
                return new ResponseModel
                {
                    Message = "Especialidade Localizada",
                    Status = Domain.DataContext.Enums.EResultStatus.Success,
                    Data = specialty
                };
            }
        }

        public ResponseModel GetWithFilters(Specialty entity)
        {
            throw new System.NotImplementedException();
        }

        public ResponseModel GetWithFiltersAndPagination(int pageSize, int pageNumber, Specialty entity = null)
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

        public ResponseModel Save(Specialty entity)
        {
            if(entity.Valid)
            {
                _uow.SpecialtyRepository.Add(entity);
                return new ResponseModel
                {
                    Data = entity,
                    Status = Domain.DataContext.Enums.EResultStatus.Success,
                    Message = "Especialidade cadastrada com sucesso"
                };
            }
            else
            {
                return new ResponseModel
                {
                    Status = Domain.DataContext.Enums.EResultStatus.Failure,
                    Message = "Falha ao tentar cadastradar especialidade",
                    Notifications = entity.Notifications
                };
            }            
        }

        public ResponseModel Update(Specialty entity)
        {
            throw new System.NotImplementedException();
        }
    }
}