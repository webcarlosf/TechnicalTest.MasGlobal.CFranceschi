using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogicContext.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TechnicalTest.MasGlobal.CFranceschi.ControllersApi
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeApiController : ControllerBase
    {
        private IEmployeeLogicContext _IemployeeLogicContext;

        public EmployeeApiController(IEmployeeLogicContext employeeLogicContext)
        {
            _IemployeeLogicContext = employeeLogicContext;
        }

        [HttpGet]
        [Route("GetAllEmployees")]
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