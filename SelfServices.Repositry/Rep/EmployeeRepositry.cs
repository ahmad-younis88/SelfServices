using Microsoft.Extensions.Configuration;
using SelfServices.Common.Interface;
using SelfServices.Common.Interface.Repositry;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using SelfServices.Common.Entity;
using SelfServices.Common.Generic;
using Dapper;
using System.Data;
using SelfServices.Common.Dto;

namespace SelfServices.Repositry.Rep
{   
    public class EmployeeRepositry : IRepositry , IEmployeeRepositry
    {
        #region :: Procedure Name 

        private const string _Get_Employee_By_Id = "GET_EMPLOYEES_BY_ID";
        private const string _Get_Employee_Salary_By_Emp_Id = "GET_EMPLOYEES_SALARY_BY_EMP_ID";

        #endregion

        #region :: Parampter Name

        private const string CompanyId = "@CompanyID";
        private const string EmployeeId = "@EmployeeID";
        private const string MonthID = "@MonthID";
        private const string YearID = "@YearID";

        #endregion

        private readonly IDapper Dapper;
        public EmployeeRepositry(IDapper dapper) 
        {
            Dapper = dapper;
        }

        public async Task<EmployeeViewDto> GetEmployee(EmployeeFilterDto employeeDto)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add(CompanyId, employeeDto.CompanyId, DbType.Int32, ParameterDirection.Input);
            dbparams.Add(EmployeeId, employeeDto.EmployeeId, DbType.String, ParameterDirection.Input);
            EmployeeViewDto employee = await Dapper.Get<EmployeeViewDto>(_Get_Employee_By_Id, dbparams, commandType: CommandType.StoredProcedure);
            return employee;
        }

        public async Task<EmployeeSalaryReportViewDto> GetEmployeeSalary(EmployeeSalaryFilterDto employeeSalaryFilter)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add(CompanyId, employeeSalaryFilter.CompanyId, DbType.Int32, ParameterDirection.Input);
            dbparams.Add(EmployeeId, employeeSalaryFilter.EmployeeId, DbType.String, ParameterDirection.Input);
            dbparams.Add(MonthID, employeeSalaryFilter.MonthId, DbType.Int32, ParameterDirection.Input);
            dbparams.Add(YearID, employeeSalaryFilter.YearId, DbType.Int32, ParameterDirection.Input);
            EmployeeSalaryReportViewDto employeeSalary = await Dapper.Get<EmployeeSalaryReportViewDto>(_Get_Employee_Salary_By_Emp_Id, dbparams, commandType: CommandType.StoredProcedure);
            return employeeSalary;
        }
    }
}
