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
using System;

namespace SelfServices.Repositry.Rep
{   
    public class EmployeeRepositry : IRepositry , IEmployeeRepositry
    {
        #region :: Procedure Name 

        private const string _Get_Employee_By_Id = "GET_EMPLOYEES_BY_ID";
        private const string _Get_Employee_Salary_By_Emp_Id = "GET_EMPLOYEES_SALARY_BY_EMP_ID";
        private const string _Get_Employees_Balances_By_Emp_Id = "GET_EMPLOYEES_BALANCES_BY_EMP_ID";
        private const string _Get_Employees_Leave_Type = "GET_EMPLOYEES_LEAVE_TYPE";
        private const string _Add_Employee_Vacation_Request = "ADD_EMPLOYEE_VACATION_REQUEST";
        private const string _Add_Employee_Leave_Request = "ADD_EMPLOYEE_LEAVE_REQUEST";
        private const string _Update_Employee_Vacation_Request_Status = "UPDATE_EMPLOYEE_VACATION_REQUEST_STATUS";
        private const string _Update_Employee_Leave_Request_Status = "UPDATE_EMPLOYEE_LEAVE_REQUEST_STATUS";
        private const string _Get_All_Employee_Request_By_Emp_Id = "GET_ALL_EMPLOYEE_REQUEST_BY_EMP_ID";
        private const string _Get_All_Request_By_Direct_Mang_Id = "GET_ALL_REQUESTS_BY_DIRECT_MANAGER_ID";
        private const string _Get_Leave_Request_By_Id = "GET_LEAVE_REQUEST_BY_ID";
        private const string _Get_Vacation_Request_By_Id = "GET_VACATION_REQUEST_BY_ID";

        #endregion

        #region :: Parampter Name

        private const string RequestIdParam = "@RequestID";
        private const string CompanyId = "@CompanyID";
        private const string EmployeeId = "@EmployeeID";
        private const string MonthID = "@MonthID";
        private const string YearID = "@YearID";
        private const string RequestNo = "@@RequestNo";
        private const string RequestStatus = "@RequestStatus";
        private const string VacationTypeID = "@VacationTypeID";
        private const string LeaveTypeID = "@LeaveTypeID";
        private const string RequestDate = "@RequestDate";
        private const string FromDate = "@FromDate";
        private const string ToDate = "@ToDate";
        private const string FromTime = "@FromTime";
        private const string ToTime = "@ToTime";
        private const string Note = "@Note";
        private const string FilePath = "@FilePath";
        private const string PageIndex = "@PageIndex";



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
        public async Task<List<EmployeeBalancesDto>> GetEmployeeBalances(EmployeeFilterDto employeeDto)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add(CompanyId, employeeDto.CompanyId, DbType.Int32, ParameterDirection.Input);
            dbparams.Add(EmployeeId, employeeDto.EmployeeId, DbType.String, ParameterDirection.Input);
            List<EmployeeBalancesDto> employeeBalances = await Dapper.GetAll<EmployeeBalancesDto>(_Get_Employees_Balances_By_Emp_Id, dbparams, commandType: CommandType.StoredProcedure);
            return employeeBalances;
        }
        public async Task<List<LeaveType>> GetLeaveRequestType(EmployeeFilterDto employeeDto)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add(CompanyId, employeeDto.CompanyId, DbType.Int32, ParameterDirection.Input);
            dbparams.Add(EmployeeId, employeeDto.EmployeeId, DbType.String, ParameterDirection.Input);
            List<LeaveType> leaveTypes = await Dapper.GetAll<LeaveType>(_Get_Employees_Leave_Type, dbparams, commandType: CommandType.StoredProcedure);
            return leaveTypes;
        }
        public async Task<int> AddEmployeeVacationRequest(VacationRequestDto vacationRequestDto)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add(CompanyId, int.Parse(vacationRequestDto.CompanyID), DbType.Int32, ParameterDirection.Input);
            dbparams.Add(EmployeeId, vacationRequestDto.EmployeeID, DbType.String, ParameterDirection.Input);
            dbparams.Add(VacationTypeID, int.Parse(vacationRequestDto.VacationTypeID), DbType.Int32, ParameterDirection.Input);
            dbparams.Add(RequestDate, Convert.ToDateTime(vacationRequestDto.RequestDate), DbType.DateTime, ParameterDirection.Input);
            dbparams.Add(FromDate, Convert.ToDateTime(vacationRequestDto.FromDate), DbType.DateTime, ParameterDirection.Input);
            dbparams.Add(ToDate, Convert.ToDateTime(vacationRequestDto.ToDate), DbType.DateTime, ParameterDirection.Input);
            dbparams.Add(Note, vacationRequestDto.Note, DbType.String, ParameterDirection.Input);
            dbparams.Add(FilePath, vacationRequestDto.FilePath, DbType.String, ParameterDirection.Input);
            int nResult = await Dapper.Insert(_Add_Employee_Vacation_Request, dbparams, commandType: CommandType.StoredProcedure);
            return nResult;
        }
        public async Task<int> AddEmployeeLeaveRequest(LeaveRequestDto leaveRequestDto)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add(CompanyId, int.Parse(leaveRequestDto.CompanyID), DbType.Int32, ParameterDirection.Input);
            dbparams.Add(EmployeeId, leaveRequestDto.EmployeeID, DbType.String, ParameterDirection.Input);
            dbparams.Add(LeaveTypeID, int.Parse(leaveRequestDto.LeaveTypeID), DbType.Int32, ParameterDirection.Input);
            dbparams.Add(RequestDate, Convert.ToDateTime(leaveRequestDto.RequestDate), DbType.DateTime, ParameterDirection.Input);
            dbparams.Add(FromTime, Convert.ToDateTime(leaveRequestDto.FromTime), DbType.DateTime, ParameterDirection.Input);
            dbparams.Add(ToTime, Convert.ToDateTime(leaveRequestDto.ToTime), DbType.DateTime, ParameterDirection.Input);
            dbparams.Add(Note, leaveRequestDto.Note, DbType.String, ParameterDirection.Input);
            dbparams.Add(FilePath, leaveRequestDto.FilePath, DbType.String, ParameterDirection.Input);
            int nResult = await Dapper.Insert(_Add_Employee_Leave_Request, dbparams, commandType: CommandType.StoredProcedure);
            return nResult;
        }
        public async Task<int> UpdateVacactionRequestStatus(RequestUpdateStatusDto requestUpdateStatusDto)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add(RequestNo, requestUpdateStatusDto.RequestNo, DbType.Int32, ParameterDirection.Input);
            dbparams.Add(CompanyId, requestUpdateStatusDto.CompanyID, DbType.Int32, ParameterDirection.Input);
            dbparams.Add(EmployeeId, requestUpdateStatusDto.EmployeeID, DbType.String, ParameterDirection.Input);
            dbparams.Add(RequestStatus, requestUpdateStatusDto.RequestStatus, DbType.Int32, ParameterDirection.Input);
            int nResult = await Dapper.Update(_Update_Employee_Vacation_Request_Status, dbparams, commandType: CommandType.StoredProcedure);
            return nResult;
        }
        public async Task<int> UpdateLeaveRequestStatus(RequestUpdateStatusDto requestUpdateStatusDto)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add(RequestNo, requestUpdateStatusDto.RequestNo, DbType.Int32, ParameterDirection.Input);
            dbparams.Add(CompanyId, requestUpdateStatusDto.CompanyID, DbType.Int32, ParameterDirection.Input);
            dbparams.Add(EmployeeId, requestUpdateStatusDto.EmployeeID, DbType.String, ParameterDirection.Input);
            dbparams.Add(RequestStatus, requestUpdateStatusDto.RequestStatus, DbType.Int32, ParameterDirection.Input);
            int nResult = await Dapper.Update(_Update_Employee_Leave_Request_Status, dbparams, commandType: CommandType.StoredProcedure);
            return nResult;
        }
        public async Task<List<EmployeeRequestDto>> GetEmployeeRequest(EmployeeRequestFilter employeeRequestFilter)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add(CompanyId, employeeRequestFilter.CompanyID, DbType.Int32, ParameterDirection.Input);
            dbparams.Add(EmployeeId, employeeRequestFilter.EmployeeID, DbType.String, ParameterDirection.Input);
            dbparams.Add(RequestDate, employeeRequestFilter.RequestDate, DbType.DateTime, ParameterDirection.Input);
            dbparams.Add(FromDate, employeeRequestFilter.FromDate, DbType.DateTime, ParameterDirection.Input);
            dbparams.Add(ToDate, employeeRequestFilter.ToDate, DbType.DateTime, ParameterDirection.Input);
            dbparams.Add(Note, employeeRequestFilter.Note, DbType.String, ParameterDirection.Input);
            dbparams.Add(PageIndex, employeeRequestFilter.PageIndex, DbType.Int32, ParameterDirection.Input);
            List<EmployeeRequestDto> employeeRequests = await Dapper.GetAll<EmployeeRequestDto>(_Get_All_Employee_Request_By_Emp_Id, dbparams, commandType: CommandType.StoredProcedure);
            return employeeRequests;
        }
        public async Task<List<EmployeeRequestDto>> GetRequestsByDirectManagerId(EmployeeRequestFilter employeeRequestFilter)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add(CompanyId, employeeRequestFilter.CompanyID, DbType.Int32, ParameterDirection.Input);
            dbparams.Add(EmployeeId, employeeRequestFilter.EmployeeID, DbType.String, ParameterDirection.Input);
            dbparams.Add(RequestDate, employeeRequestFilter.RequestDate, DbType.DateTime, ParameterDirection.Input);
            dbparams.Add(FromDate, employeeRequestFilter.FromDate, DbType.DateTime, ParameterDirection.Input);
            dbparams.Add(ToDate, employeeRequestFilter.ToDate, DbType.DateTime, ParameterDirection.Input);
            dbparams.Add(Note, employeeRequestFilter.Note, DbType.String, ParameterDirection.Input);
            List<EmployeeRequestDto> employeeRequests = await Dapper.GetAll<EmployeeRequestDto>(_Get_All_Request_By_Direct_Mang_Id, dbparams, commandType: CommandType.StoredProcedure);
            return employeeRequests;
        }
        public async Task<EmployeeRequestDto> GetLeaveRequestDetail(int requestId)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add(RequestIdParam, requestId, DbType.Int32, ParameterDirection.Input);
            EmployeeRequestDto employeeRequests = await Dapper.Get<EmployeeRequestDto>(_Get_Leave_Request_By_Id, dbparams, commandType: CommandType.StoredProcedure);
            return employeeRequests;
        }
        public async Task<EmployeeRequestDto> GetVacationRequestDetail(int requestId)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add(RequestIdParam, requestId, DbType.Int32, ParameterDirection.Input);
            EmployeeRequestDto employeeRequests = await Dapper.Get<EmployeeRequestDto>(_Get_Vacation_Request_By_Id, dbparams, commandType: CommandType.StoredProcedure);
            return employeeRequests;
        }
    }
}
