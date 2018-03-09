using System.Collections.Generic;
using System.Threading.Tasks;
using Dtos;

namespace Services
{
    public interface IEmployeeService
    {
        Task<DtoEmployee> GetEmployeeById(int id);
        Task<IEnumerable<DtoEmployee>> GetEmployees();
    }
}