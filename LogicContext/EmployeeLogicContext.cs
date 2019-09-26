using AutoMapper;
using DaoContext.Repositories.Interfaces;
using DtoContext;
using Entities.Models;
using Helpers;
using LogicContext.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicContext
{
    public class EmployeeLogicContext : IEmployeeLogicContext
    {
        private IEmployeeRepository iemployeeRepository;

        public EmployeeLogicContext(IEmployeeRepository employeeRepository)
        {
            iemployeeRepository = employeeRepository;
        }
        public EmployeeLogicContext(){}

        public async Task<List<EmployeeSalary>> GetAll()
        {
            List<EmployeeSalary> respuesta = new List<EmployeeSalary>();

            var result = await iemployeeRepository.GetAll();

            var hourlyList = result.Where(x => x.ContractTypeName == Values.ContractHourly).ToList();
            var monthlyList = result.Where(x => x.ContractTypeName == Values.ContractMonthly).ToList();

            var employeeHour = Mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeHourCalculateDto>>(hourlyList).ToList();
            var employeeMonthly = Mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeMonthlyCalculateDto>>(monthlyList).ToList();

            employeeHour.ForEach(x => x.CalculateSalary());
            employeeMonthly.ForEach(x => x.CalculateSalary());

            respuesta.AddRange(Mapper.Map<IEnumerable<EmployeeHourCalculateDto>, IEnumerable<EmployeeSalary>>(employeeHour).ToList());
            respuesta.AddRange(Mapper.Map<IEnumerable<EmployeeMonthlyCalculateDto>, IEnumerable<EmployeeSalary>>(employeeMonthly).ToList());

            return respuesta;
        }        

        public async Task<List<EmployeeSalary>> GetById(int Id)
        {
            List<EmployeeSalary> respuesta = new List<EmployeeSalary>();
            EmployeeSalary employeeSalary = new EmployeeSalary();

            var result = await iemployeeRepository.GetAll();

            var employee = result.Where(x => x.Id == Id).FirstOrDefault();
            
            if (employee.ContractTypeName == Values.ContractHourly)
            {
                var employeeHourly = Mapper.Map<Employee, EmployeeHourCalculateDto>(employee);
                employeeHourly.CalculateSalary();
                employeeSalary = Mapper.Map<EmployeeHourCalculateDto, EmployeeSalary>(employeeHourly);
            }
            else
            {
                var employeeMonthly = Mapper.Map<Employee, EmployeeMonthlyCalculateDto>(employee);
                employeeMonthly.CalculateSalary();
                employeeSalary = Mapper.Map<EmployeeMonthlyCalculateDto, EmployeeSalary>(employeeMonthly);
            }

            respuesta.Add(employeeSalary);

            return respuesta;
        }
      
    }
}
