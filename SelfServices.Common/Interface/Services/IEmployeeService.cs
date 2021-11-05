using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SelfServices.Common.Dto;
using SelfServices.Common.Entity;

namespace SelfServices.Common.Interface.Services
{
    public interface IEmployeeService
    {
        Task<EmployeeViewDto> GetEmployee(EmployeeFilterDto employeeDto);
        Task<EmployeeSalaryReportViewDto> GetEmployeeSalary(EmployeeSalaryFilterDto employeeSalaryFilter);
        Task<List<EmployeeBalancesDto>> GetEmployeeBalances(EmployeeFilterDto employeeDto);
        Task<List<LeaveType>> GetLeaveRequestType(EmployeeFilterDto employeeDto);
        Task<int> AddEmployeeVacationRequest(VacationRequestDto vacationRequestDto);
        Task<int> AddEmployeeLeaveRequest(LeaveRequestDto leaveRequestDto);
        Task<int> UpdateVacactionRequestStatus(RequestUpdateStatusDto requestUpdateStatusDto);
        Task<int> UpdateLeaveRequestStatus(RequestUpdateStatusDto requestUpdateStatusDto);
    }
}
