using Assignment.DataAccess.Data.Contexts;
using Assignment.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment.DataAccess.Data.Repositories;

public class ProjectRepository(AssignmentDbContext dbContext) : BaseRepository(dbContext)
{   
    private readonly AssignmentDbContext _dbContext = dbContext;
    
    public async Task<bool> CreateProject(ProjectModel project)
    {
        return await Create(project);
    }
    
    public async Task<bool> UpdateProject(ProjectModel project)
    {
        return await Update(project);
    }
    
    public async Task<bool> DeleteProject(ProjectModel project)
    {
        return await Delete(project);
    }
    
    public async Task<IEnumerable<ProjectModel>> GetAllProjects()
    {
        return await GetAll<ProjectModel>();
    }
    
    public async Task<ProjectModel?> GetProjectById(int id)
    {
        return await GetById<ProjectModel>(id);
    }
}