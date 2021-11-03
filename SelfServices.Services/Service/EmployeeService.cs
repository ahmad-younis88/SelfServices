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

        public async Task<EmployeeViewDto> GetEmployee(EmployeeDto employeeDto)
        {
            EmployeeViewDto employeeViewDto = await EmployeeRepositry.GetEmployee(employeeDto);
            return employeeViewDto;
        }
    }
}
