using System.Collections.Generic;
using System.Linq;
using DevAvaliacao.Domain.DataContext.Entities;
using DevAvaliacao.Domain.DataContext.Models;
using DevAvaliacao.Domain.DataContext.Services;
using DevAvaliacao.Infra.Transactions.UnityOfWork;

namespace DevAvaliacao.Application.DataContext.Services
{
    public class ConsultationService : IConsultationService
    {
        private IUnityOfWork _uow;
        public ConsultationService(IUnityOfWork uow)
        {
            _uow = uow;
        }
        public IEnumerable<Consultation> GetAll()
        {
            return _uow.ConsultationRepository.GetAll().ToList();
        }

        public ResponseModel GetById(int Id)
        {
            var data = _uow.ConsultationRepository.GetById(Id);
            return new ResponseModel
            {
                Data = data,
                Message = "Consulta Localizada"
            };
        }

        public ResponseModel GetWithFilters(Consultation entity)
        {
            throw new System.NotImplementedException();
        }

        public ResponseModel GetWithFiltersAndPagination(int pageSize, int pageNumber, Consultation entity = null)
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

        public ResponseModel Save(Consultation entity)
        {
            if (entity.Valid)
            {
                var hasAvailableTime = _uow.ConsultationRepository.AddCheckingForAvailableTime(entity);
                if (hasAvailableTime)
                {
                    return new ResponseModel
                    {
                        Status = Domain.DataContext.Enums.EResultStatus.Success,
                        Data = entity,
                        Location = $"/api/consultations/{entity.Id}",
                        Message = "Consulta marcada com sucesso"
                    };
                }
                else
                {
                    return new ResponseModel
                    {
                        Status = Domain.DataContext.Enums.EResultStatus.Failure,
                        Message = "Não há horário disponível"
                    };
                }
            }
            else
            {
                return new ResponseModel
                {
                    Status = Domain.DataContext.Enums.EResultStatus.Failure,
                    Message = "Falha ao tentar marcar consulta",
                    Notifications = entity.Notifications
                };
            }
        }

        public ResponseModel Update(Consultation entity)
        {
            throw new System.NotImplementedException();
        }
    }
}