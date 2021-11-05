using Microsoft.AspNetCore.Authorization;
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
    [Route("api/employee")]
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
        public async Task<IActionResult> GetEmployeeById([FromBody] EmployeeFilterDto employeeDto)
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

        [HttpPost]
        [Route("EmpSalary/GetbyId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetEmployeeSalary([FromBody] EmployeeSalaryFilterDto employeeSalaryFilterDto)
        {
            try
            {
                EmployeeSalaryReportViewDto employeeSalary = await EmployeeService.GetEmployeeSalary(employeeSalaryFilterDto);
                return Ok(new { isSuccess = true, Message = "", data = employeeSalary });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [Authorize]
        [HttpPost]
        [Route("Balances")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetEmployeeBalances([FromBody] EmployeeFilterDto employeeDto)
        {
            try
            {
                List<EmployeeBalancesDto> employeeBalancesDtos = await EmployeeService.GetEmployeeBalances(employeeDto);
                return Ok(new { isSuccess = true, Message = "", data = employeeBalancesDtos });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [Authorize]
        [HttpPost]
        [Route("LeaveType")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetLeaveType([FromBody] EmployeeFilterDto employeeDto)
        {
            try
            {
                List<LeaveType> leaveTypes = await EmployeeService.GetLeaveRequestType(employeeDto);
                return Ok(new { isSuccess = true, Message = "", data = leaveTypes });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

    }
}
