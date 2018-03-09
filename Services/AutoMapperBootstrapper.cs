using AutoMapper;
using Dtos;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public static class AutoMapperBootstrapper
    {

        public static void Configuration()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Employee, DtoEmployee>();
                cfg.CreateMap<DtoEmployee, Employee>();
                cfg.CreateMap<Employee, DtoHourlyEmployee>();
                cfg.CreateMap<Employee, DtoMontlyEmployee>();
            });
        }

    }
}
