using Assignment.DataAccess.Models;

namespace Assignment.Infrasctructure.Interfaces;

public interface IProjectService : IBaseService
{
    Task<bool> CreateProject(ProjectModel project);
    Task<bool> UpdateProject(ProjectModel project);
    Task<bool> DeleteProject(ProjectModel project);
    Task<IEnumerable<ProjectModel>> GetAllProjects();
    Task<ProjectModel?> GetProjectById(int id);
}