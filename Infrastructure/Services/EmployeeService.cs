using Infrastructure.Interface;
using Domain.Models;
using Infrastructure.Dapper;
using Dapper;


namespace Infrastructure.Services;

public class EmployeeService : Interface<Employees>
{
    private DapperContext dapperContext = new DapperContext();
    public async Task<string> AddValues(Employees value)
    {
        await dapperContext.Connection().ExecuteAsync("insert into Employees(Name,Department)values(@name,@department)",value);
        return "Succesfully Done";
    }

    public async Task<string> DeleteValues(int employeeId)
    {
        await dapperContext.Connection().ExecuteAsync("delete from Employees where EmployeeID = @employeeId",new {EmployeeId = employeeId});
        return "Succesfully Done";
    }

    public async Task<List<Employees>> GetValues()
    {
        var result = await dapperContext.Connection().QueryAsync<Employees>("select * from Employees");
        return result.ToList();
    }

    public async Task<string> UpdateValues(Employees value)
    {
        await dapperContext.Connection().ExecuteAsync("update Employees set Name = @name, Department = @department where EmployeeID = @employeeId ",value);
        return "Succesfully Done";
    }
    public async Task<List<Employees>> GetEmployeesByProjectIDAsync(int projectId)
    {
        var result = await dapperContext.Connection().QueryAsync<Employees>(@"select e.EmployeeID,e.Name,e.Department from Tasks as t
                                                                              join Employees as e on t.AssignedTo = e.EmployeeID
                                                                              join Projects as p on t.ProjectID = p.ProjectID
                                                                              where p.ProjectID = @projectId", new {ProjectId = projectId});
        return result.ToList();
    }
}
