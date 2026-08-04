using System.Collections.Generic;
using System.Linq;
using Company.Application.DtoRequests;
using Company.Application.Interfaces;
using Company.Domain.Constants;
using Company.Domain.Interfaces;
using Company.Domain.Models;

namespace Company.Application.Services
{
    public class ProjectTaskService : IProjectTaskService
    {
        private readonly IProjectTaskRepository _projectTaskRepository;
        private readonly ICacheService _cacheService;

        public ProjectTaskService(IProjectTaskRepository projectTaskRepository, ICacheService cacheService)
        {
            _projectTaskRepository = projectTaskRepository;
            _cacheService = cacheService;
        }

        public List<ProjectTask> GetAll()
        {
            if (_cacheService.IsAdd(GeneralConstants.ProjectTaskCacheKey))
            {
                return _cacheService.Get<List<ProjectTask>>(GeneralConstants.ProjectTaskCacheKey!);
            }

            var tasks = _projectTaskRepository.GetAll();
            _cacheService.Add(GeneralConstants.ProjectTaskCacheKey, tasks, 60);
            return tasks;
        }

        public ProjectTask GetById(int id)
        {
            var tasks = GetAll();
            return tasks.FirstOrDefault(x => x.Id == id);
        }

        public void Add(DtoProjectTaskRequest request)
        {
            var task = new ProjectTask
            {
                Description = request.Description,
                Effort = request.Effort
            };

            _projectTaskRepository.Add(task);
            _projectTaskRepository.SaveChanges();
            _cacheService.Remove(GeneralConstants.ProjectTaskCacheKey);
        }

        public void Update(int id, DtoProjectTaskRequest request)
        {
            var task = _projectTaskRepository.GetById(id);
            if (task != null)
            {
                task.Description = request.Description;
                task.Effort = request.Effort;

                _projectTaskRepository.Update(task);
                _projectTaskRepository.SaveChanges();
                _cacheService.Remove(GeneralConstants.ProjectTaskCacheKey);
            }
        }

        public void Delete(int id)
        {
            var task = _projectTaskRepository.GetById(id);
            if (task != null)
            {
                _projectTaskRepository.Delete(task);
                _projectTaskRepository.SaveChanges();
                _cacheService.Remove(GeneralConstants.ProjectTaskCacheKey);
            }
        }
    }
}