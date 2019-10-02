using AutoMapper;
using DaoContext.Repositories.Interfaces;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaoContext
{
    public class EmployeeContextDbRepository : IEmployeeRepository
    {
        public Task<IEnumerable<Employee>> GetAll()
        {
            try
            {
                var listEmployee = new List<Employee>() {
                    new Employee()
                    {
                        Id = 3,
                        Name = "Carlos Franceschi",
                        HourlySalary = 10,
                        MonthlySalary = 2000,
                        ContractTypeName = "MonthlySalaryEmployee",
                        RoleId = 1,
                        RoleName = "Administrator"
                    },
                    new Employee()
                    {
                        Id = 4,
                        Name = "Carlos Franceschi",
                        HourlySalary = 10,
                        MonthlySalary = 2000,
                        ContractTypeName = "HourlySalaryEmployee",
                        RoleId = 1,
                        RoleName = "Administrator"
                    }
                };

                var respuesta = (Mapper.Map<IEnumerable<Entities.Models.Employee>, IEnumerable<Entities.Models.Employee>>(listEmployee));

                return Task.FromResult(respuesta);               
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
