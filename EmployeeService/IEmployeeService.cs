using System.Collections.Generic;
using System.Threading.Tasks;
using Dtos;

namespace EmployeeService
{
    public interface IEmployeeService
    {
        Task<DtoEmployee> GetEmployeeById(int id);
        Task<IEnumerable<DtoEmployee>> GetEmployees();
    }
}