using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SelfServices.API.Generic;
using SelfServices.Common.Dto;
using SelfServices.Common.Entity;
using SelfServices.Common.Interface.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelfServices.API.Controllers
{
    [Route("api/emplyoee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private TokenServices TokenServices;
        private IEmployeeService EmployeeService;

        public EmployeeController(TokenServices tokenServices, IEmployeeService employeeService)
        {
            TokenServices = tokenServices;
            EmployeeService = employeeService;
        }


        [HttpPost]
        [Route("GetbyId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetEmployeeById([FromBody] EmployeeDto employeeDto)
        {
            try
            {
                EmployeeViewDto employee = await EmployeeService.GetEmployee(employeeDto);
                return Ok(new { isSuccess = true, Message = "", data = employee });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

    }
}
