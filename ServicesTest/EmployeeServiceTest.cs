using Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Repository;
using Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicesTest
{
    [TestClass]
    public class EmployeeServiceTest
    {

        private IEmployeeRepository employeeRepository;




        [TestMethod]
        public async Task GetEmployeesTest()
        {
            AutoMapper.Mapper.Reset();
            AutoMapperBootstrapper.Configuration();
            employeeRepository = Substitute.For<IEmployeeRepository>();
            var employees = new List<Employee>() { new Employee { Id = 0, ContractTypeName = ContractTypes.Hourly_Salary_Employee }, new Employee { Id = 1, ContractTypeName = ContractTypes.Monthly_Salary_Employee } };
            employeeRepository.GetEmployees().Returns(employees);

            var service = this.GetService();

            var response = (await service.GetEmployees()).ToList();

            Assert.IsTrue(employees[0].ContractTypeName == response[0].ContractTypeName && employees[1].ContractTypeName == response[1].ContractTypeName);

        }


        [TestMethod]
        public async Task GetEmployeeByIdTest()
        {
            AutoMapper.Mapper.Reset();
            AutoMapperBootstrapper.Configuration();
            employeeRepository = Substitute.For<IEmployeeRepository>();
            var employee = new Employee { Id = 0, ContractTypeName = ContractTypes.Hourly_Salary_Employee };
            employeeRepository.GetEmployee(Arg.Any<int>()).Returns(employee);

            var service = this.GetService();

            var response = await service.GetEmployeeById(0);

            Assert.IsTrue(employee.ContractTypeName == response.ContractTypeName);

        }

        



        private EmployeeService GetService()
        {
            return new EmployeeService(this.employeeRepository);
        }

    }
}
