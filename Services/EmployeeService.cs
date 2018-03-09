using AutoMapper;
using Common;
using Dtos;
using Entities;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services
{
    [UnityExpose]
    public class EmployeeService : IEmployeeService
    {

        public readonly IEmployeeRepository employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public async Task<IEnumerable<DtoEmployee>> GetEmployees()
        {
            var employees = await this.employeeRepository.GetEmployees();
            var destEmployees = employees.Select(e => this.Fabric(e));
            return destEmployees;
        }

        public async Task<DtoEmployee> GetEmployeeById(int id)
        {
            var employee = await this.employeeRepository.GetEmployee(id);
            var destEmployee = Fabric(employee);
            return destEmployee;
        }



        private DtoEmployee Fabric(Employee employee)
        {
            if(employee == null)
            {
                return null;
            }

            if (employee.ContractTypeName.Equals(ContractTypes.Hourly_Salary_Employee))
            {
                return Mapper.Map<Employee, DtoHourlyEmployee>(employee);
            }
            else
            {
                return Mapper.Map<Employee, DtoMontlyEmployee>(employee);
            }
        }



    }
}
