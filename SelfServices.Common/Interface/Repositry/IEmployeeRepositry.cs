using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SelfServices.Common.Dto;
using SelfServices.Common.Entity;

namespace SelfServices.Common.Interface.Repositry
{
    public interface IEmployeeRepositry
    {
        Task<EmployeeViewDto> GetEmployee(EmployeeFilterDto employeeDto);
        Task<EmployeeSalaryReportViewDto> GetEmployeeSalary(EmployeeSalaryFilterDto employeeSalaryFilter);
    }
}
