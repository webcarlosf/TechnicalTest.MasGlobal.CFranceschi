using DaoContext.Repositories.Interfaces;
using DtoContext;
using LogicContext.Repositories.Interfaces;
using System;
using System.Collections.Generic;
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

            return null;
        }

        public Task<List<EmployeeSalary>> GetById(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
