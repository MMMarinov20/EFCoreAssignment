using Assignment.Infrasctructure.Interfaces;
using Assignment.DataAccess.Models;
using Assignment.DataAccess.Data.Repositories;
using Assignment.DataAccess.Interfaces;

namespace Assignment.Infrasctructure.Services;

public class EmployeeService(IBaseRepository repository, EmployeeRepository employeeRepository) : BaseService(repository), IEmployeeService
{
    private readonly EmployeeRepository _employeeRepository;
    
    public async Task<bool> CreateEmployee(EmployeeModel employee)
    {
        return await _employeeRepository.CreateEmployee(employee);
    }
    
    public async Task<bool> UpdateEmployee(EmployeeModel employee)
    {
        return await _employeeRepository.UpdateEmployee(employee);
    }
    
    public async Task<bool> DeleteEmployee(EmployeeModel employee)
    {
        return await _employeeRepository.DeleteEmployee(employee);
    }
    
    public async Task<IEnumerable<EmployeeModel>> GetAllEmployees()
    {
        return await _employeeRepository.GetAllEmployees();
    }
    
    public async Task<EmployeeModel?> GetEmployeeById(int id)
    {
        return await _employeeRepository.GetEmployeeById(id);
    }
}