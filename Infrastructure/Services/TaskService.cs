using Infrastructure.Interface;
using Domain.Models;
using Infrastructure.Dapper;
using Dapper;

namespace Infrastructure.Services;

public class TaskService : Interface<Tasks>
{
    private DapperContext dapperContext = new DapperContext();
    public async Task<string> AddValues(Tasks value)
    {
        await dapperContext.Connection().ExecuteAsync("insert into Tasks(ProjectID,Title,Description,AssignedTo,DueDate)values(@projectId,@title,@description,@assignedTo,@dueDate)",value);
        return "Succesfully Done";
    }

    public async Task<string> DeleteValues(int taskId)
    {
        await dapperContext.Connection().ExecuteAsync("delete from Tasks where TaskID = @taskId",new {TaskId = taskId});
        return "Succesfully Done";
    }

    public async Task<List<Tasks>> GetValues()
    {
        var result = await dapperContext.Connection().QueryAsync<Tasks>("select * from Tasks");
        return result.ToList();
    }

    public async Task<string> UpdateValues(Tasks value)
    {
        await dapperContext.Connection().ExecuteAsync("update Tasks set Name = @name, Title = @title, Description = @description, AssignedTo = @assignedTo, DueDate = @dueDate where taskID = @taskId ",value);
        return "Succesfully Done";
    }
    public async Task<List<Tasks>> GetTasksByEmployeeIDAsync(int assignedTo)
    {
        var result = await dapperContext.Connection().QueryAsync<Tasks>("select * from Tasks where AssignedTo = @assignedTo",new {AssignedTo = assignedTo});
        return result.ToList();
    }
    public async Task<List<Tasks>> GetTasksByProjectIDAsync(int projectId)
    {
        var result = await dapperContext.Connection().QueryAsync<Tasks>(@"select * from Tasks 
                                                                          where ProjectID = @projectId",new {ProjectId = projectId});
        return result.ToList();
    }
}
