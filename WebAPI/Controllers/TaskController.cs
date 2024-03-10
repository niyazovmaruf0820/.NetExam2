using Domain.Models;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;
[ApiController]
[Route("[controller]")]
public class TaskController
{
    private readonly TaskService taskService;
    public TaskController()
    {
        taskService = new TaskService();
    }
    [HttpGet("get-tasks")]
    public async Task<List<Tasks>> GetTasksAsync()
    {
        return await taskService.GetValues();
    }
    [HttpDelete("delete-task")]
    public async Task<string> DeleteTaskAsync(int id)
    {
        return await taskService.DeleteValues(id);
    }
    [HttpPost("add-task")]
    public async Task<string> AddTaskAsync(Tasks task)
    {
        return await 
        taskService.AddValues(task);
    }
    [HttpPut("update-task")]
    public async Task<string> UpdateTaskAsync(Tasks task)
    {
        return await taskService.UpdateValues(task);
    }
    [HttpGet("get-Tasks-By-EmployeeID")]
    public async Task<List<Tasks>> GetTasksByEmployeeIDAsync(int employeeId)
    {
        return await taskService.GetTasksByEmployeeIDAsync(employeeId);
    }
    [HttpGet("get-Tasks-By-ProjectID")]
    public async Task<List<Tasks>> GetTasksByProjectIDAsync(int projectId)
    {
        return await taskService.GetTasksByProjectIDAsync(projectId);
    }
}
