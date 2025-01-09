using Assignment.DataAccess.Data.Contexts;
using Assignment.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment.DataAccess.Data.Repositories;

public class EmployeeRepository(AssignmentDbContext dbContext) : BaseRepository(dbContext)
{
    private readonly AssignmentDbContext _dbContext = dbContext;
    
    public async Task<bool> CreateEmployee(EmployeeModel employee)
    {
        return await Create(employee);
    }
    
    public async Task<bool> UpdateEmployee(EmployeeModel employee)
    {
        return await Update(employee);
    }
    
    public async Task<bool> DeleteEmployee(EmployeeModel employee)
    {
        return await Delete(employee);
    }
    
    public async Task<IEnumerable<EmployeeModel>> GetAllEmployees()
    {
        return await GetAll<EmployeeModel>();
    }
    
    public async Task<EmployeeModel?> GetEmployeeById(int id)
    {
        return await GetById<EmployeeModel>(id);
    }
}