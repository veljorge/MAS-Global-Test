using Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace EmpoyerTestApplication.ApiControllers
{
    [RoutePrefix("api")]
    public class EmployeesController : ApiController
    {
        private readonly IEmployeeService employeeService;

        //public EmployeesController()
        //{
        //}

        public EmployeesController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        [HttpGet]
        [Route("employees")]
        public async Task<IHttpActionResult> Get()
        {
            var employees = (await this.employeeService.GetEmployees()).ToList();
            var response = new { data = employees, count= employees.Count };
            return Ok(response);
        }

        // GET api/<controller>/5
        [HttpGet]
        [Route("employees/{id}")]
        public async Task<IHttpActionResult> Get(int id)
        {
            var employee = await this.employeeService.GetEmployeeById(id);
            var response =  new { data = employee, count = employee == null ? 0 : 1 };
            return Ok(response);
        }

    }
}