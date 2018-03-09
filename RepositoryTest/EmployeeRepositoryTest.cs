using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository;
using NSubstitute;
using Entities;
using HttpRequester;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace RepositoryTest
{
    [TestClass]
    public class EmployeeRepositoryTest
    {
        private IRequesterService requesterService;

        [TestInitialize]
        public void TestInitialize()
        {
            requesterService = Substitute.For<IRequesterService>();
        }

        [TestMethod]
        public async Task GetEmployeesTest()
        {
            var employees = new List<Employee>() { new Employee { Id = 0 }, new Employee { Id = 1 } };
            requesterService.GetEntities<Employee>().Returns(employees);

            var repo = this.GetRepo();

            var response = (await repo.GetEmployees()).ToList();


            Assert.IsTrue(employees[0].Id == response[0].Id && employees[1].Id == response[1].Id);
        }

        [TestMethod]
        public async Task GetEmployeeTest()
        {
            var employees = new List<Employee>() { new Employee { Id = 0 }, new Employee { Id = 1 } };
            requesterService.GetEntities<Employee>().Returns(employees);

            var repo = this.GetRepo();

            var response = (await repo.GetEmployee(0));


            Assert.IsTrue(employees[0].Id == response.Id);
        }


        private EmployeeRepository GetRepo()
        {
            return new EmployeeRepository(this.requesterService);
        }
    }
}
