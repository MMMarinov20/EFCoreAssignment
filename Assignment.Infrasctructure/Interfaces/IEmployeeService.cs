using Assignment.DataAccess.Models;

namespace Assignment.Infrasctructure.Interfaces;

public interface IEmployeeService : IBaseService
{   
    Task<bool> CreateEmployee(EmployeeModel employee);
    Task<bool> UpdateEmployee(EmployeeModel employee);
    Task<bool> DeleteEmployee(EmployeeModel employee);
    Task<IEnumerable<EmployeeModel>> GetAllEmployees();
    Task<EmployeeModel?> GetEmployeeById(int id);
}