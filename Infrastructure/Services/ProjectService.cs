using Infrastructure.Interface;
using Domain.Models;
using Infrastructure.Dapper;
using Dapper;

namespace Infrastructure.Services;

public class ProjectService : Interface<Projects>
{
    private DapperContext dapperContext = new DapperContext();
    public async Task<string> AddValues(Projects value)
    {
        await dapperContext.Connection().ExecuteAsync("insert into Projects(Name,Description,StartDate,EndDate)values(@name,@description,@startDate,@endDate)",value);
        return "Succesfully Done";
    }

    public async Task<string> DeleteValues(int projectId)
    {
        await dapperContext.Connection().ExecuteAsync("delete from Projects where ProjectID = @projectId",new {ProjectId = projectId});
        return "Succesfully Done";
    }

    public async Task<List<Projects>> GetValues()
    {
        var result = await dapperContext.Connection().QueryAsync<Projects>("select * from Projects");
        return result.ToList();
    }

    public async Task<string> UpdateValues(Projects value)
    {
        await dapperContext.Connection().ExecuteAsync("update Projects set Name = @name, Description = @description, StartDate = @startDate, EndDate = @endDate where ProjectID = @projectId ",value);
        return "Succesfully Done";
    }
    public async Task<List<Projects>> GetProjectsWithQuantityOfTasksAsync()
    {
        var result = await dapperContext.Connection().QueryAsync<Projects>(@"select p.ProjectID,p.Name, p.Description, p.StartDate, p.EndDate, Sum(t.TaskID) as TaskQuantity from Tasks as t
                                                                             join Projects as p on t.ProjectID = p.ProjectID
                                                                             group by p.ProjectID");
        return result.ToList();
    }
}
