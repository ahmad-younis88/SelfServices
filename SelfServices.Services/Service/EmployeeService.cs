using SelfServices.Common.Interface.Services;
using SelfServices.Common.Interface.Repositry;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SelfServices.Common.Generic;
using SelfServices.Common.Entity;
using SelfServices.Common.Dto;

namespace SelfServices.Services.Service
{
    public class EmployeeService : IServices , IEmployeeService
    {
        private IEmployeeRepositry EmployeeRepositry;
        public EmployeeService(IEmployeeRepositry employeeRepositry)
        {
            EmployeeRepositry = employeeRepositry;
        }

        public async Task<EmployeeViewDto> GetEmployee(EmployeeFilterDto employeeDto)
        {
            EmployeeViewDto employeeViewDto = await EmployeeRepositry.GetEmployee(employeeDto);
            return employeeViewDto;
        }

        public async Task<EmployeeSalaryReportViewDto> GetEmployeeSalary(EmployeeSalaryFilterDto employeeSalaryFilter)
        {
            EmployeeSalaryReportViewDto employeeSalaryViewDto = await EmployeeRepositry.GetEmployeeSalary(employeeSalaryFilter);
            return employeeSalaryViewDto;
        }

        public async Task<List<EmployeeBalancesDto>> GetEmployeeBalances(EmployeeFilterDto employeeDto)
        {
            List<EmployeeBalancesDto> employeeBalances = await EmployeeRepositry.GetEmployeeBalances(employeeDto);
            return employeeBalances;
        }

        public async Task<List<LeaveType>> GetLeaveRequestType(EmployeeFilterDto employeeDto)
        {
            List<LeaveType> leaveTypes = await EmployeeRepositry.GetLeaveRequestType(employeeDto);
            return leaveTypes;
        }
    }
}
