using Common;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace HttpRequester
{
    [UnityExpose]
    public class RequesterService : IRequesterService
    {
        HttpClient client = new HttpClient();

        public async Task<IEnumerable<T>> GetEntities<T>()
        {
            var response = await client.GetAsync("http://masglobaltestapi.azurewebsites.net/api/Employees");
            if (response.IsSuccessStatusCode)
            {
                var dataTransformed = await response.Content.ReadAsStringAsync();
                return new JavaScriptSerializer().Deserialize<IEnumerable<T>>(dataTransformed);
            }

            return new JavaScriptSerializer().Deserialize<IEnumerable<T>>(string.Empty);
        }
    }
}
