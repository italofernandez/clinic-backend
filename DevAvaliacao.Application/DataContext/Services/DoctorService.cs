using System;
using System.Collections.Generic;
using DevAvaliacao.Domain.DataContext.Entities;
using DevAvaliacao.Domain.DataContext.Enums;
using DevAvaliacao.Domain.DataContext.Models;
using DevAvaliacao.Domain.DataContext.Services;
using DevAvaliacao.Infra.Transactions.UnityOfWork;
using Microsoft.EntityFrameworkCore;

namespace DevAvaliacao.Application.DataContext.Services
{
    public class DoctorService : IDoctorService
    {
        private IUnityOfWork _uow;
        public DoctorService(IUnityOfWork uow)
        {
            _uow = uow;
        }
        public bool CrmExist(string crm)
        {
            return _uow.DoctorRepository.CrmExist(crm); 
        }

        public IEnumerable<Doctor> GetAll()
        {
            return _uow.DoctorRepository.GetAll().Include(x=>x.Specialty);
        }

        public ResponseModel GetById(int Id)
        {
            try
            {
                var doctor = _uow.DoctorRepository.GetById(Id);
                return new ResponseModel
                {
                    Data = doctor,
                    Message = "Médico localizado",
                    Status = EResultStatus.Success
                };
            }
            catch (System.Exception ex)
            {
                return new ResponseModel
                {
                    Message = "Falha ao localizar o médico",
                    Status = EResultStatus.Failure,
                    InnerException = ex.Message
                };
            }

        }

        public ResponseModel GetWithFilters(Doctor entity)
        {
            throw new System.NotImplementedException();
        }

        public ResponseModel GetWithFiltersAndPagination(int pageSize, int pageNumber, Doctor entity = null)
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

        public ResponseModel Save(Doctor entity)
        {
            try
            {
                entity.Validate();
                if(CrmExist(entity.CRM))
                    entity.AddNotification("CRM", "Este CRM já foi cadastrado");
                if (entity.Notifications.Count > 0)
                {
                    return new ResponseModel
                    {
                        Status = EResultStatus.Failure,
                        Notifications = entity.Notifications,
                        Message = "Falha ao tentar cadastrar o médico"
                    };
                }
                else
                {
                    var specialty = _uow.SpecialtyRepository.GetById(entity.SpecialtyId);
                    if(specialty == null)
                    {
                        return new ResponseModel
                        {
                            Message = "Especialidade não encontrada"
                        };
                    }
                    _uow.DoctorRepository.Add(entity);
                    _uow.SaveChanges();

                    return new ResponseModel
                    {
                        Status = EResultStatus.Success,
                        Location = $"/api/doctors/{entity.Id}",
                        Message = "Médico cadastrado com sucesso"
                    };
                }
            }
            catch (Exception ex)
            {
                return new ResponseModel
                {
                    Status = EResultStatus.Failure,
                    InnerException = ex.Message,
                    Message = "Falha ao tentar cadastrar o médico"
                };
            }
        }

        public ResponseModel Update(Doctor entity)
        {
            throw new System.NotImplementedException();
        }
    }
}