﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SelfServices.API.GenericServices;
using SelfServices.Common.Dto;
using SelfServices.Common.Entity;
using SelfServices.Common.Interface.Services;
using System;
using System.Collections.Generic;
using System.IO;
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
        private readonly IHostingEnvironment _hostingEnv;

        public EmployeeController(TokenServices tokenServices, IEmployeeService employeeService, IHostingEnvironment hostingEnv)
        {
            TokenServices = tokenServices;
            EmployeeService = employeeService;
            _hostingEnv = hostingEnv;
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


        [Authorize]
        [HttpPost]
        [Route("VacationRequest")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AddEmployeeVacationRequest([FromForm] VacationRequestDto vacationRequestDto, IFormFile file)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(_hostingEnv.WebRootPath))
                {
                    _hostingEnv.WebRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
                }

                if (file != null)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var filePath = Path.Combine(_hostingEnv.WebRootPath, "files", fileName);

                    using (var fileSteam = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(fileSteam);
                    }

                    vacationRequestDto.FilePath = Path.Combine("files", fileName);
                }

                int nResult = await EmployeeService.AddEmployeeVacationRequest(vacationRequestDto);
                return Ok(new { isSuccess = nResult > 0 ? true : false, Message = "", data = "" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [Authorize]
        [HttpPost]
        [Route("LeaveRequest")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AddEmployeeLeaveRequest([FromForm] LeaveRequestDto leaveRequestDto, IFormFile file)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(_hostingEnv.WebRootPath))
                {
                    _hostingEnv.WebRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
                }

                if (file != null)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var filePath = Path.Combine(_hostingEnv.WebRootPath, "files", fileName);

                    using (var fileSteam = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(fileSteam);
                    }

                    leaveRequestDto.FilePath = Path.Combine("files", fileName);
                }

                int nResult = await EmployeeService.AddEmployeeLeaveRequest(leaveRequestDto);
                return Ok(new { isSuccess = nResult > 0 ? true : false, Message = "", data = "" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [Authorize]
        [HttpPost]
        [Route("VacationRequest/UpdateStatus")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateVacactionRequestStatus([FromBody] RequestUpdateStatusDto requestUpdateStatusDto)
        {
            try
            {
                int nResult = await EmployeeService.UpdateVacactionRequestStatus(requestUpdateStatusDto);
                return Ok(new { isSuccess = nResult > 0 ? true : false, Message = "", data = "" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [Authorize]
        [HttpPost]
        [Route("LeaveRequest/UpdateStatus")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateLeaveRequestStatus([FromBody] RequestUpdateStatusDto requestUpdateStatusDto)
        {
            try
            {
                int nResult = await EmployeeService.UpdateLeaveRequestStatus(requestUpdateStatusDto);
                return Ok(new { isSuccess = nResult > 0 ? true : false, Message = "", data = "" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [Authorize]
        [HttpPost]
        [Route("EmployeeRequests")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetEmployeeRequests([FromBody] EmployeeRequestFilter employeeRequestFilter)
        {
            try
            {
                List<EmployeeRequestDto> employeeRequests = await EmployeeService.GetEmployeeRequest(employeeRequestFilter);
                return Ok(new { isSuccess = true, Message = "", data = employeeRequests });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [Authorize]
        [HttpPost]
        [Route("EmployeeRequestsByDirectManager")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetEmployeeRequestsByDirectManager([FromBody] EmployeeRequestFilter employeeRequestFilter)
        {
            try
            {
                List<EmployeeRequestDto> employeeRequests = await EmployeeService.GetRequestsByDirectManagerId(employeeRequestFilter);
                return Ok(new { isSuccess = true, Message = "", data = employeeRequests });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet]
        [Route("GetVacationRequestDetails")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetVacationRequestDetails(int requestId)
        {
            try
            {
                EmployeeRequestDto employee = await EmployeeService.GetVacationRequestDetail(requestId);
                return Ok(new { isSuccess = true, Message = "", data = employee });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet]
        [Route("GetLeaveRequestDetails")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetLeaveRequestDetails(int requestId)
        {
            try
            {
                EmployeeRequestDto employee = await EmployeeService.GetLeaveRequestDetail(requestId);
                return Ok(new { isSuccess = true, Message = "", data = employee });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

    }
}
