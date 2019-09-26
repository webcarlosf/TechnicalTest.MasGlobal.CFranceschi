//using Helpers;
using Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace DtoContext
{
    public class EmployeeHourCalculateDto : EmployeeDto
    {
        public override void CalculateSalary()
        {
            try
            {
                if (ContractTypeName == Values.ContractHourly)
                {
                    AnnualSalary = 120 * HourlySalary * 12;
                }
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
