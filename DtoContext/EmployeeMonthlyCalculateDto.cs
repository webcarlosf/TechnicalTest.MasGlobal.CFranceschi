using Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace DtoContext
{
    public class EmployeeMonthlyCalculateDto : EmployeeDto
    {
        public override void CalculateSalary()
        {
            try
            {
                if (ContractTypeName == Values.ContractMonthly)
                {
                    AnnualSalary = MonthlySalary * 12;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
