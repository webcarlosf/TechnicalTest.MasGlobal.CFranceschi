using DtoContext;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LogicContext.Repositories.Interfaces
{
    public interface IEmployeeLogicContext
    {
        Task<List<EmployeeSalary>> GetAll();

        Task<List<EmployeeSalary>> GetById(int Id);
    }
}
