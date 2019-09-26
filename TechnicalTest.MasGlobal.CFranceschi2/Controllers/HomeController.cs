using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Entities.Models;
using Helpers;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TechnicalTest.MasGlobal.CFranceschi2.Models;

namespace TechnicalTest.MasGlobal.CFranceschi2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult SearchEmployees(string Id)
        {
            if (string.IsNullOrEmpty(Id))
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Values.UrlApiLocal);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var response = client.GetAsync(Values.UrIApiGetAllEmployees).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonMessage;
                        using (Stream responseStream = response.Content.ReadAsStreamAsync().Result)
                        {
                            jsonMessage = new StreamReader(responseStream).ReadToEnd();
                            var json = JsonConvert.DeserializeObject<IEnumerable<Employee>>(jsonMessage);
                            return Json(json);
                        }
                    }
                    else
                    {
                        throw new HandlerExceptions(MessagesHandler.MessagesConectionError);
                    }
                }
            }
            else
            {
                var json = "";
                return Json(json);
            }
        }
    }
}
