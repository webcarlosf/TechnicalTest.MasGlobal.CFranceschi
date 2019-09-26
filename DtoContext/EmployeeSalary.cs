using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DtoContext
{
    public class EmployeeSalary : Employee
    {
        public double AnnualSalary { get; set; }
    }
}
