using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DtoContext
{
    public abstract class EmployeeDto : Employee
    {
        public double AnnualSalary { get; set; }

        public abstract void CalculateSalary();
    }
}
