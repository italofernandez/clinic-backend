using System;
using System.Collections.Generic;
using DevAvaliacao.Domain.DataContext.Entities;
using DevAvaliacao.Domain.DataContext.Enums;
using DevAvaliacao.Domain.DataContext.Models;
using DevAvaliacao.Domain.DataContext.Services;
using DevAvaliacao.Infra.Transactions.UnityOfWork;

namespace DevAvaliacao.Application.DataContext.Services
{
    public class PatientService : IPatientService
    {
        private IUnityOfWork _uow;

        public PatientService(IUnityOfWork uow)
        {
            _uow = uow;
        }

        public bool CpfExist(string cpf)
        {
            return _uow.PatientRepository.CpfExist(cpf);
        }

        public IEnumerable<Patient> GetAll()
        {
            return _uow.PatientRepository.GetAll();
        }

        public ResponseModel GetById(int Id)
        {
            try
            {
                var patient = _uow.PatientRepository.GetById(Id);
                return new ResponseModel
                {
                    Data = patient,
                    Message = "Paciente localizado",
                    Status = EResultStatus.Success
                };
            }
            catch (System.Exception ex)
            {
                return new ResponseModel
                {
                    Status = EResultStatus.Failure,
                    Message = "Falha ao localizar o paciente",
                    InnerException = ex.Message
                };
            }
        }

        public ResponseModel GetWithFilters(Patient entity)
        {
            throw new System.NotImplementedException();
        }

        public ResponseModel GetWithFiltersAndPagination(int pageSize, int pageNumber, Patient entity = null)
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

        public ResponseModel Save(Patient entity)
        {
            try
            {
                entity.Validate();
                if(CpfExist(entity.CPF))
                    entity.AddNotification("CPF", "Este CPF já foi cadastrado");
                if (entity.Notifications.Count > 0)
                {
                    return new ResponseModel
                    {
                        Status = EResultStatus.Failure,
                        Notifications = entity.Notifications,
                        Message = "Falha ao tentar cadastrar o paciente"
                    };
                }
                else
                {
                    _uow.PatientRepository.Add(entity);
                    _uow.SaveChanges();

                    return new ResponseModel
                    {
                        Status = EResultStatus.Success,
                        Location = $"/api/patients/{entity.Id}",
                        Message = "Paciente cadastrado com sucesso"
                    };
                }
            }
            catch (Exception ex)
            {
                return new ResponseModel
                {
                    Status = EResultStatus.Failure,
                    InnerException = ex.Message,
                    Message = "Falha ao tentar cadastrar o paciente"
                };
            }
        }

        public ResponseModel Update(Patient entity)
        {
            throw new System.NotImplementedException();
        }
    }
}