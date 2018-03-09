using System.Collections.Generic;
using System.Threading.Tasks;

namespace HttpRequester
{
    public interface IRequesterService
    {
        Task<IEnumerable<T>> GetEntities<T>();
    }
}