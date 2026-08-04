using System.Collections.Generic;
using Company.Application.DtoRequests;
using Company.Domain.Models;

namespace Company.Application.Services
{
    public interface IProjectTaskService
    {
        List<ProjectTask> GetAll();
        ProjectTask GetById(int id);
        void Add(DtoProjectTaskRequest request);
        void Update(int id, DtoProjectTaskRequest request);
        void Delete(int id);
    }
}