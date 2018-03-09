using Common;
using Entities;
using HttpRequester;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Repository
{
    [UnityExpose]
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IRequesterService requesterService;

        public EmployeeRepository(IRequesterService requesterService)
        {
            this.requesterService = requesterService;
        }


        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await this.requesterService.GetEntities<Employee>();
            
        }


        public async Task<Employee> GetEmployee(int id)
        {
            var employees = await this.GetEmployees();
            return employees.Where(e => e.Id == id).FirstOrDefault();
        }


    }
}
