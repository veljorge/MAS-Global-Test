using System.Collections.Generic;
using System.Threading.Tasks;
using Entities;

namespace Repository
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetEmployees();
        Task<Employee> GetEmployee(int id);
    }
}