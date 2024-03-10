using Domain.Models;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;
[ApiController]
[Route("[controller]")]
public class ProjectController
{
    private readonly ProjectService projectService;
    public ProjectController()
    {
        projectService = new ProjectService();
    }
    [HttpGet("get-projects")]
    public async Task<List<Projects>> GetProjectsAsync()
    {
        return await projectService.GetValues();
    }
    [HttpPost("add-project")]
    public async Task<string> AddProjectAsync(Projects project)
    {
        return await projectService.AddValues(project);
    }
    [HttpPut("update-project")]
    public async Task<string> UpdateProjectAsync(Projects project)
    {
        return await projectService.UpdateValues(project);
    }
    [HttpDelete("delete-project")]
    public async Task<string> DeleteProjectAsync(int id)
    {
        return await projectService.DeleteValues(id);
    }
    
    [HttpGet("get-Projects-With-Quantity-Of-Tasks")]
    public async Task<List<Projects>> GetProjectsWithQuantityOfTasksAsync()
    {
        return await projectService.GetProjectsWithQuantityOfTasksAsync();
    }
}
