using Microsoft.AspNetCore.Mvc;
using Assignment.Infrasctructure.Interfaces;
using Assignment.DomainModel.DTOs;
using Assignment.DataAccess.Models;
using Assignment.Infrasctructure.Services;

namespace Assignment.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AssignmentController : ControllerBase
    {
        private readonly IAssignmentService _assignmentService;

        public AssignmentController(IAssignmentService assignmentService)
        {
            _assignmentService = assignmentService;
        }
        
        [HttpPost(Name = "CreateAssignment")]
        public async Task<IActionResult> CreateAssignment([FromBody] AssignmentDTO.CreateAssignmentDTO model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "Assignment data is required", errorCode = 400 });
            }

            AssignmentModel assignment = new()
            {
                EmployeeId = model.EmployeeId,
                ProjectId = model.ProjectId,
                HoursWorked = model.HoursWorked,
                Role = model.Role
            };
            
            bool result = await _assignmentService.CreateAssignment(assignment);
            
            if (result)
            {
                return Ok(new { message = "Assignment created successfully", errorCode = 200 });
            }
            else
            {
                return BadRequest(new { message = "Assignment creation failed", errorCode = 400 });
            }
        }
        
        [HttpPut(Name="UpdateAssignment")]
        public async Task<IActionResult> UpdateAssignment([FromBody] AssignmentDTO.UpdateAssignmentDTO model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "Assignment data is required", errorCode = 400 });
            }

            AssignmentModel assignment = new()
            {
                Id = model.Id,
                EmployeeId = model.EmployeeId,
                ProjectId = model.ProjectId,
                HoursWorked = model.HoursWorked,
                Role = model.Role
            };
            
            bool result = await _assignmentService.UpdateAssignment(assignment);
            
            if (result)
            {
                return Ok(new { message = "Assignment updated successfully", errorCode = 200 });
            }
            else
            {
                return BadRequest(new { message = "Assignment update failed", errorCode = 400 });
            }
        }
        
        [HttpDelete(Name = "DeleteAssignment")]
        public async Task<IActionResult> DeleteAssignment([FromBody] AssignmentDTO.UpdateAssignmentDTO model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "Assignment data is required", errorCode = 400 });
            }

            AssignmentModel assignment = new()
            {
                Id = model.Id,
                EmployeeId = model.EmployeeId,
                ProjectId = model.ProjectId,
                HoursWorked = model.HoursWorked,
                Role = model.Role
            };
            
            bool result = await _assignmentService.DeleteAssignment(assignment);
            
            if (result)
            {
                return Ok(new { message = "Assignment deleted successfully", errorCode = 200 });
            }
            else
            {
                return BadRequest(new { message = "Assignment deletion failed", errorCode = 400 });
            }
        }

        [HttpGet(Name = "GetAllAssignments")]
        public async Task<IActionResult> GetAllAssignments()
        {
            IEnumerable<AssignmentModel> assignments = await _assignmentService.GetAllAssignments();

            if (assignments.Any())
            {
                return Ok(assignments);
            }
            else
            {
                return NotFound(new { message = "No assignments found", errorCode = 404 });
            }
        }
        
        [HttpGet("{id}", Name = "GetAssignmentById")]
        public async Task<IActionResult> GetAssignmentById(int id)
        {
            AssignmentModel? assignment = await _assignmentService.GetAssignmentById(id);
            
            if (assignment != null)
            {
                return Ok(assignment);
            }
            else
            {
                return NotFound(new { message = "Assignment not found", errorCode = 404 });
            }
        }
    }
}