using AutoMapper;
using DtoContext;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DaoContext.AppConfigurations
{
    public class MapsEmployee
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Employee, EmployeeDto>();
                cfg.CreateMap<EmployeeDto, Employee>();

                cfg.CreateMap<Employee, EmployeeHourCalculateDto>();
                cfg.CreateMap<Employee, EmployeeMonthlyCalculateDto>();

                cfg.CreateMap<EmployeeHourCalculateDto, EmployeeSalary>();
                cfg.CreateMap<EmployeeMonthlyCalculateDto, EmployeeSalary>();

                cfg.CreateMap<Entities.Models.Employee, Entities.Models.Employee>();
            });
        }

        public static void TearDown()
        {
            AutoMapper.Mapper.Reset();
        }
    }
}
