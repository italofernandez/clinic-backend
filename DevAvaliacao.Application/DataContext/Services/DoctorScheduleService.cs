using System.Collections.Generic;
using System.Linq;
using DevAvaliacao.Domain.DataContext.Entities;
using DevAvaliacao.Domain.DataContext.Models;
using DevAvaliacao.Domain.DataContext.Services;
using DevAvaliacao.Infra.Transactions.UnityOfWork;

namespace DevAvaliacao.Application.DataContext.Services
{
    public class DoctorScheduleService : IDoctorScheduleService
    {
        private IUnityOfWork _uow;
        public DoctorScheduleService(IUnityOfWork uow)
        {
            _uow = uow;
        }
        public IEnumerable<DoctorSchedule> GetAll()
        {
            return _uow.DoctorScheduleRepository.GetAll().ToList();
        }

        public IEnumerable<DoctorSchedule> GetByDoctorId(int doctorId)
        {
            return _uow.DoctorScheduleRepository.GetAll()
                .Where(x=>x.DoctorId == doctorId)
                .OrderBy(x=>x.StartTime)
                .ToList();
        }

        public ResponseModel GetById(int Id)
        {
            throw new System.NotImplementedException();
        }

        public ResponseModel GetWithFilters(DoctorSchedule entity)
        {
            throw new System.NotImplementedException();
        }

        public ResponseModel GetWithFiltersAndPagination(int pageSize, int pageNumber, DoctorSchedule entity = null)
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

        public ResponseModel Save(DoctorSchedule entity)
        {
            if(entity.Valid)
            {
                _uow.DoctorScheduleRepository.Add(entity);
                return new ResponseModel
                {
                    Status = Domain.DataContext.Enums.EResultStatus.Success,
                    Data = entity,
                    Message = "Horário definido com sucesso",
                    Location = $"/api/doctorSchedule/{entity.Id}"
                };
            }
            else
            {
                return new ResponseModel
                {
                    Status = Domain.DataContext.Enums.EResultStatus.Failure,
                    Message = "Falha ao tentar definir horário"
                };
            }
        }

        public ResponseModel Update(DoctorSchedule entity)
        {
            throw new System.NotImplementedException();
        }
    }
}