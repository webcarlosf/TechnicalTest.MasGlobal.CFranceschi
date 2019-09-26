using Entities.Models;
using DaoContext.Repositories.Interfaces;
using Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DaoContext
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public async Task<IEnumerable<Employee>> GetAll()
        {
            IEnumerable<Employee> respuesta;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Values.UrlApi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.GetAsync(Values.UrIApiEmployees);

                if (response.IsSuccessStatusCode)
                {
                    string jsonMessage;
                    using (Stream responseStream = response.Content.ReadAsStreamAsync().Result)
                    {
                        jsonMessage = new StreamReader(responseStream).ReadToEnd();
                        return respuesta = JsonConvert.DeserializeObject<IEnumerable<Employee>>(jsonMessage);
                    }
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
