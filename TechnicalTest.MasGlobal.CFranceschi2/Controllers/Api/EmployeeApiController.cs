using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogicContext.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TechnicalTest.MasGlobal.CFranceschi2.Controllers.Api
{
    //[Route("Api/[controller]")]
    [ApiController]
    public class EmployeeApiController : ControllerBase
    {
        private IEmployeeLogicContext _IemployeeLogicContext;

        public EmployeeApiController(IEmployeeLogicContext employeeLogicContext)
        {
            _IemployeeLogicContext = employeeLogicContext;
        }

        [HttpGet]
        [Route("Api/GetAllEmployees")] // https://localhost:44363/Api/GetAllEmployees
        public async Task<IActionResult> GetAllEmployees()
        {
            try
            {
                return Ok(await _IemployeeLogicContext.GetAll());
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
    }
}