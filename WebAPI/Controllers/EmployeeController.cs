using Domain.Models;
using Infrastructure.Services;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;
[ApiController]
[Route("[controller]")]
public class EmployeeController
{
    private readonly EmployeeService employeeService;
    public EmployeeController()
    {
        employeeService = new EmployeeService();
    }
    [HttpGet("get-employees")]
    public async Task<List<Employees>> GetEmployeesAsync()
    {
        return await employeeService.GetValues();
    }
    [HttpPost("add-employee")]
    public async Task<string> AddEmployeeAsync(Employees employee)
    {
        return await employeeService.AddValues(employee);
    }
    [HttpPut("update-employee")]
    public async Task<string> UpdateEmployeeAsync(Employees employee)
    {
        return await employeeService.UpdateValues(employee);
    }
    [HttpDelete("delete-employee")]
    public async Task<string> DeleteEmployeeAsync(int id)
    {
        return await employeeService.DeleteValues(id);
    }
    [HttpGet("get-Employees-By-ProjectID")]
    public async Task<List<Employees>> GetEmployeesByProjectIDAsync(int projectId)
    {
        return await employeeService.GetEmployeesByProjectIDAsync(projectId);
    }
}
