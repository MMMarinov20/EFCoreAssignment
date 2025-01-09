using Assignment.Infrasctructure.Interfaces;
using Assignment.DataAccess.Models;
using Assignment.DataAccess.Data.Repositories;
using Assignment.DataAccess.Interfaces;

namespace Assignment.Infrasctructure.Services;

public class ProjectService(IBaseRepository repository, ProjectRepository projectRepository) : BaseService(repository), IProjectService
{
    private readonly ProjectRepository _projectRepository;
    
    public async Task<bool> CreateProject(ProjectModel project)
    {
        return await _projectRepository.CreateProject(project);
    }
    
    public async Task<bool> UpdateProject(ProjectModel project)
    {
        return await _projectRepository.UpdateProject(project);
    }
    
    public async Task<bool> DeleteProject(ProjectModel project)
    {
        return await _projectRepository.DeleteProject(project);
    }
    
    public async Task<IEnumerable<ProjectModel>> GetAllProjects()
    {
        return await _projectRepository.GetAllProjects();
    }
    
    public async Task<ProjectModel?> GetProjectById(int id)
    {
        return await _projectRepository.GetProjectById(id);
    }
}