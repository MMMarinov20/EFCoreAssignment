using Microsoft.AspNetCore.Mvc;
using Assignment.Infrasctructure.Interfaces;
using Assignment.DomainModel.DTOs;
using Assignment.DataAccess.Models;
using Assignment.Infrasctructure.Services;

namespace Assignment.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        
        [HttpGet(Name = "CreateEmployee")]
        public async Task<IActionResult> CreateEmployee(EmployeeDTO.CreateEmployeeDTO employeeDTO)
        {
            var employee = new EmployeeModel
            {
                Name = employeeDTO.Name,
                Position = employeeDTO.Position,
                HireDate = employeeDTO.HireDate,
                Salary = employeeDTO.Salary,
                DepartmentId = employeeDTO.DepartmentId
            };
            
            var result = await _employeeService.CreateEmployee(employee);
            
            if (result)
            {
                return Ok();
            }
            
            return BadRequest();
        }
        
        [HttpPut(Name = "UpdateEmployee")]
        public async Task<IActionResult> UpdateEmployee(EmployeeDTO.UpdateEmployeeDTO employeeDTO)
        {
            var employee = new EmployeeModel
            {
                Id = employeeDTO.EmployeeId,
                Name = employeeDTO.Name,
                Position = employeeDTO.Position,
                HireDate = employeeDTO.HireDate,
                Salary = employeeDTO.Salary,
                DepartmentId = employeeDTO.DepartmentId
            };
            
            var result = await _employeeService.UpdateEmployee(employee);
            
            if (result)
            {
                return Ok();
            }
            
            return BadRequest();
        }
        
        [HttpDelete(Name = "DeleteEmployee")]
        public async Task<IActionResult> DeleteEmployee(EmployeeDTO.UpdateEmployeeDTO employeeDTO)
        {
            var employee = new EmployeeModel
            {
                Id = employeeDTO.EmployeeId,
                Name = employeeDTO.Name,
                Position = employeeDTO.Position,
                HireDate = employeeDTO.HireDate,
                Salary = employeeDTO.Salary,
                DepartmentId = employeeDTO.DepartmentId
            };
            
            var result = await _employeeService.DeleteEmployee(employee);
            
            if (result)
            {
                return Ok();
            }
            
            return BadRequest();
        }
        
        [HttpGet(Name = "GetAllEmployees")]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = await _employeeService.GetAllEmployees();
            
            return Ok(employees);
        }
        
        [HttpGet("{id}", Name = "GetEmployeeById")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var employee = await _employeeService.GetEmployeeById(id);
            
            if (employee != null)
            {
                return Ok(employee);
            }
            
            return NotFound();
        }
    }
}