using System.Collections.Generic;
using System.Linq;
using Company.Application.DtoRequests;
using Company.Application.Interfaces;
using Company.Domain.Constants;
using Company.Domain.Interfaces;
using Company.Domain.Models;

namespace Company.Application.Services
{
    public class EmployeeTaskService : IEmployeeTaskService
    {
        private readonly IEmployeeTaskRepository _employeeTaskRepository;
        private readonly ICacheService _cacheService;

        public EmployeeTaskService(IEmployeeTaskRepository employeeTaskRepository, ICacheService cacheService)
        {
            _employeeTaskRepository = employeeTaskRepository;
            _cacheService = cacheService;
        }

        public List<EmployeeTask> GetAll()
        {
            if (_cacheService.IsAdd(GeneralConstants.EmployeeTaskCacheKey))
            {
                return _cacheService.Get<List<EmployeeTask>>(GeneralConstants.EmployeeTaskCacheKey!);
            }

            var employeeTasks = _employeeTaskRepository.GetAll();
            _cacheService.Add(GeneralConstants.EmployeeTaskCacheKey, employeeTasks, 60);
            return employeeTasks;
        }

        public EmployeeTask GetById(int id)
        {
            var employeeTasks = GetAll();
            return employeeTasks.FirstOrDefault(x => x.Id == id);
        }

        public void Add(DtoEmployeeTaskRequest request)
        {
            var employeeTask = new EmployeeTask
            {
                EmployeeId = request.EmployeeId,
                TaskId = request.TaskId,
                StartDate = request.StartDate,
                EndDate = request.EndDate
            };

            _employeeTaskRepository.Add(employeeTask);
            _employeeTaskRepository.SaveChanges();
            _cacheService.Remove(GeneralConstants.EmployeeTaskCacheKey);
        }

        public void Update(int id, DtoEmployeeTaskRequest request)
        {
            var employeeTask = _employeeTaskRepository.GetById(id);
            if (employeeTask != null)
            {
                employeeTask.EmployeeId = request.EmployeeId;
                employeeTask.TaskId = request.TaskId;
                employeeTask.StartDate = request.StartDate;
                employeeTask.EndDate = request.EndDate;

                _employeeTaskRepository.Update(employeeTask);
                _employeeTaskRepository.SaveChanges();
                _cacheService.Remove(GeneralConstants.EmployeeTaskCacheKey);
            }
        }

        public void Delete(int id)
        {
            var employeeTask = _employeeTaskRepository.GetById(id);
            if (employeeTask != null)
            {
                _employeeTaskRepository.Delete(employeeTask);
                _employeeTaskRepository.SaveChanges();
                _cacheService.Remove(GeneralConstants.EmployeeTaskCacheKey);
            }
        }
    }
}