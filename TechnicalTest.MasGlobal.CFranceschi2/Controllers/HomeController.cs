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
            string Uri = "";
            if (string.IsNullOrEmpty(Id))
            {
                Uri = Values.UrIApiGetAllEmployees;
            }
            else
            {
                Uri = Values.UrIApiGetEmployeeById + Id;
            }

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Values.UrlApiLocal);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = client.GetAsync(Uri).Result;

                if (response.IsSuccessStatusCode)
                {
                    var json = JsonConvert.DeserializeObject<IEnumerable<Employee>>(response.Content.ReadAsStringAsync().Result);
                    return Json(json);
                }
                else
                {
                    throw new HandlerExceptions(MessagesHandler.MessagesConectionError);
                }
            }
        }
    }
}
