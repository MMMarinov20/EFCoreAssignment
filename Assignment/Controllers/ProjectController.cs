using Microsoft.AspNetCore.Mvc;
using Assignment.Infrasctructure.Interfaces;
using Assignment.DomainModel.DTOs;
using Assignment.DataAccess.Models;
using Assignment.Infrasctructure.Services;

namespace Assignment.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;
        
        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }
        
        [HttpPost(Name = "CreateProject")]
        public async Task<IActionResult> CreateProject([FromBody] ProjectDTO.CreateProjectDTO model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "Project data is required", errorCode = 400 });
            }

            ProjectModel project = new()
            {
                Name = model.Name,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                Budget = model.Budget
            };
            
            bool result = await _projectService.CreateProject(project);
            
            if (result)
            {
                return Ok(new { message = "Project created successfully", errorCode = 200 });
            }
            else
            {
                return BadRequest(new { message = "Project creation failed", errorCode = 400 });
            }
        }
        
        [HttpPut(Name="UpdateProject")]
        public async Task<IActionResult> UpdateProject([FromBody] ProjectDTO.UpdateProjectDTO model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "Project data is required", errorCode = 400 });
            }

            ProjectModel project = new()
            {
                Id = model.ProjectId,
                Name = model.Name,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                Budget = model.Budget
            };
            
            bool result = await _projectService.UpdateProject(project);
            
            if (result)
            {
                return Ok(new { message = "Project updated successfully", errorCode = 200 });
            }
            else
            {
                return BadRequest(new { message = "Project update failed", errorCode = 400 });
            }
        }
        
        [HttpDelete(Name="DeleteProject")]
        public async Task<IActionResult> DeleteProject([FromBody] ProjectDTO.UpdateProjectDTO model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "Project data is required", errorCode = 400 });
            }

            ProjectModel project = new()
            {
                Id = model.ProjectId,
                Name = model.Name,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                Budget = model.Budget
            };
            
            bool result = await _projectService.DeleteProject(project);
            
            if (result)
            {
                return Ok(new { message = "Project deleted successfully", errorCode = 200 });
            }
            else
            {
                return BadRequest(new { message = "Project deletion failed", errorCode = 400 });
            }
        }
        
        [HttpGet(Name="GetAllProjects")]
        public async Task<IActionResult> GetAllProjects()
        {
            IEnumerable<ProjectModel> projects = await _projectService.GetAllProjects();
            
            if (projects != null)
            {
                return Ok(projects);
            }
            else
            {
                return BadRequest(new { message = "No projects found", errorCode = 400 });
            }
        }
        
        [HttpGet("{id}", Name="GetProjectById")]
        public async Task<IActionResult> GetProjectById(int id)
        {
            ProjectModel? project = await _projectService.GetProjectById(id);
            
            if (project != null)
            {
                return Ok(project);
            }
            else
            {
                return BadRequest(new { message = "Project not found", errorCode = 400 });
            }
        }
    }
}
