using Company.Application.DTOs.DtoRequests;
using Company.Application.DTOs.DtoResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using Company.Domain.Models;
using Company.Domain.Interfaces;


namespace Company.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IEmployeeDapper _employeeDapper;

        public EmployeeService(IEmployeeRepository employeeRepository, IEmployeeDapper employeeDapper)
        {
            _employeeRepository = employeeRepository;
            _employeeDapper = employeeDapper;
        }

        public List<DtoEmployeeResponse> GetEmployees()
        {
            var employees = _employeeRepository.GetAllWithDetails();

            return employees.Select(p => new DtoEmployeeResponse
            {
                Name = p.Name,
                Surname = p.Surname,
                UnitName = p.Unit != null ? p.Unit.UnitName : string.Empty,
                CityName = p.City != null ? p.City.CityName : string.Empty
            }).ToList();
        }

        public List<DtoEmployeeResponse> GetEmployeesDapper()
        {
            List<Employee> employees = _employeeDapper.GetEmployeesDapper();

            return employees.Select(p => new DtoEmployeeResponse
            {
                Name = p.Name,
                Surname = p.Surname,
                UnitName = p.Unit?.UnitName ?? string.Empty,
                CityName = p.City?.CityName ?? string.Empty
            }).ToList();
        }

        public DtoResponse EmployeeAdd(DtoEmployeeRequest request)
        {
            try
            {
                var yeniEmployee = new Employee
                {
                    Name = request.Name,
                    Surname = request.Surname,
                    UnitId = request.UnitId,
                    Tcno = request.Tcno,
                    CityId = request.CityId
                };

                _employeeRepository.Add(yeniEmployee);
                _employeeRepository.SaveChanges();

                return new DtoResponse
                {
                    ReqCode = 200,
                    ReqMessage = "Employee başarıyla eklendi."
                };
            }
            catch (Exception ex)
            {
                return new DtoErrorResponse
                {
                    ReqCode = 500,
                    ReqMessage = "Employee eklenirken veritabanında bir hata oluştu!",
                    ErrCode = "DB_INSERT_ERR",
                    ErrMessage = ex.InnerException?.Message ?? ex.Message
                };
            }
        }

        public DtoResponse GetEmployeeById(int id)
        {
            try
            {
                var employee = _employeeRepository.GetById(id);

                if (employee == null)
                {
                    return new DtoErrorResponse
                    {
                        ReqCode = 404,
                        ReqMessage = "Aranan Employee bulunamadı.",
                        ErrCode = "NOT_FOUND"
                    };
                }

                return new DtoDataResponse<DtoEmployeeResponse>
                {
                    ReqCode = 200,
                    ReqMessage = "Employee başarıyla getirildi.",
                    Data = new DtoEmployeeResponse
                    {
                        Name = employee.Name,
                        Surname = employee.Surname,
                        UnitName = employee.Unit?.UnitName ?? string.Empty,
                        CityName = employee.City?.CityName ?? string.Empty
                    }
                };
            }
            catch (Exception ex)
            {
                return new DtoErrorResponse
                {
                    ReqCode = 500,
                    ReqMessage = "Employee getirilirken sunucuda hata oluştu!",
                    ErrCode = "DB_READ_ERR",
                    ErrMessage = ex.InnerException?.Message ?? ex.Message
                };
            }
        }

        public DtoResponse EmployeeUpdate(int id, DtoEmployeeRequest request)
        {
            try
            {
                var employee = _employeeRepository.GetById(id);
                if (employee == null)
                {
                    return new DtoErrorResponse
                    {
                        ReqCode = 404,
                        ReqMessage = "Güncellenecek Employee bulunamadı.",
                        ErrCode = "NOT_FOUND"
                    };
                }

                employee.Name = request.Name;
                employee.Surname = request.Surname;
                employee.Tcno = request.Tcno;
                employee.UnitId = request.UnitId;
                employee.CityId = request.CityId;

                _employeeRepository.Update(employee);
                _employeeRepository.SaveChanges();

                return new DtoResponse
                {
                    ReqCode = 200,
                    ReqMessage = "Employee başarıyla güncellendi."
                };
            }
            catch (Exception ex)
            {
                return new DtoErrorResponse
                {
                    ReqCode = 500,
                    ReqMessage = "Employee güncellenirken hata oluştu!",
                    ErrCode = "DB_UPDATE_ERR",
                    ErrMessage = ex.InnerException?.Message ?? ex.Message
                };
            }
        }

        public DtoResponse EmployeeHardDelete(int id)
        {
            try
            {
                var employee = _employeeRepository.GetById(id);
                if (employee == null)
                {
                    return new DtoErrorResponse
                    {
                        ReqCode = 404,
                        ReqMessage = "Silinecek Employee bulunamadı.",
                        ErrCode = "NOT_FOUND"
                    };
                }

                _employeeRepository.Delete(employee);
                _employeeRepository.SaveChanges();

                return new DtoResponse
                {
                    ReqCode = 200,
                    ReqMessage = "Employee başarıyla silindi."
                };
            }
            catch (Exception ex)
            {
                return new DtoErrorResponse
                {
                    ReqCode = 500,
                    ReqMessage = "Employee silinirken hata oluştu!",
                    ErrCode = "DB_DELETE_ERR",
                    ErrMessage = ex.InnerException?.Message ?? ex.Message
                };
            }
        }

        public DtoResponse EmployeeSoftDelete(int id)
        {
            try
            {
                var employee = _employeeRepository.GetById(id);
                if (employee == null)
                {
                    return new DtoErrorResponse
                    {
                        ReqCode = 404,
                        ReqMessage = "Silinecek Employee bulunamadı.",
                        ErrCode = "NOT_FOUND"
                    };
                }

                employee.Status = 0;
                _employeeRepository.Update(employee);
                _employeeRepository.SaveChanges();

                return new DtoResponse
                {
                    ReqCode = 200,
                    ReqMessage = "Employee başarıyla pasif duruma alındı."
                };
            }
            catch (Exception ex)
            {
                return new DtoErrorResponse
                {
                    ReqCode = 500,
                    ReqMessage = "Employee pasife alınırken hata oluştu!",
                    ErrCode = "DB_SOFT_DELETE_ERR",
                    ErrMessage = ex.InnerException?.Message ?? ex.Message
                };
            }
        }

        public List<int> GetCityCodes()
        {
            var employees = _employeeRepository.GetWithCity();
            var cityCodes = employees
                .Where(p => p.City != null && !string.IsNullOrEmpty(p.City.CityCode))
                .Select(p => Convert.ToInt32(p.City?.CityCode))
                .Distinct()
                .OrderBy(k => k)
                .ToList();
            return cityCodes;
        }
    }
}