using Microsoft.AspNetCore.Mvc;
using Assignment.Infrasctructure.Interfaces;
using Assignment.DomainModel.DTOs;
using Assignment.DataAccess.Models;
using Assignment.Infrasctructure.Services;

namespace Assignment.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;
        
        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }
        
        [HttpPost(Name = "CreateDepartment")]
        public async Task<IActionResult> CreateDepartment([FromBody] DepartmentDTO.CreateDepartmentDTO model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "Department data is required", errorCode = 400 });
            }

            DepartmentModel department = new()
            {
                Name = model.Name,
                Location = model.Location,
                Budget = model.Budget
            };
            
            bool result = await _departmentService.CreateDepartment(department);
            
            if (result)
            {
                return Ok(new { message = "Department created successfully", errorCode = 200 });
            }
            else
            {
                return BadRequest(new { message = "Department creation failed", errorCode = 400 });
            }
        }
        
        [HttpPut(Name="UpdateDepartment")]
        public async Task<IActionResult> UpdateDepartment([FromBody] DepartmentDTO.UpdateDepartmentDTO model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "Department data is required", errorCode = 400 });
            }

            DepartmentModel department = new()
            {
                Id = model.DepartmentId,
                Name = model.Name,
                Location = model.Location,
                Budget = model.Budget
            };
            
            bool result = await _departmentService.UpdateDepartment(department);
            
            if (result)
            {
                return Ok(new { message = "Department updated successfully", errorCode = 200 });
            }
            else
            {
                return BadRequest(new { message = "Department update failed", errorCode = 400 });
            }
        }
        
        [HttpDelete(Name="DeleteDepartment")]
        public async Task<IActionResult> DeleteDepartment([FromBody] DepartmentDTO.UpdateDepartmentDTO model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "Department data is required", errorCode = 400 });
            }

            DepartmentModel department = new()
            {
                Id = model.DepartmentId,
                Name = model.Name,
                Location = model.Location,
                Budget = model.Budget
            };
            
            bool result = await _departmentService.DeleteDepartment(department);
            
            if (result)
            {
                return Ok(new { message = "Department deleted successfully", errorCode = 200 });
            }
            else
            {
                return BadRequest(new { message = "Department deletion failed", errorCode = 400 });
            }
        }
        
        [HttpGet(Name="GetAllDepartments")]
        public async Task<IActionResult> GetAllDepartments()
        {
            IEnumerable<DepartmentModel> departments = await _departmentService.GetAllDepartments();
            
            if (departments != null)
            {
                return Ok(departments);
            }
            else
            {
                return BadRequest(new { message = "No departments found", errorCode = 400 });
            }
        }
        
        [HttpGet("{id}", Name="GetDepartmentById")]
        public async Task<IActionResult> GetDepartmentById(int id)
        {
            DepartmentModel? department = await _departmentService.GetDepartmentById(id);
            
            if (department != null)
            {
                return Ok(department);
            }
            else
            {
                return NotFound(new { message = "Department not found", errorCode = 404 });
            }
        }
    }
}