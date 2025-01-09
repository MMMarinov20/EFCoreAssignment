using Assignment.DataAccess.Data.Contexts;
using Assignment.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment.DataAccess.Data.Repositories;

public class DepartmentRepository(AssignmentDbContext dbContext) : BaseRepository(dbContext)
{
    private readonly AssignmentDbContext _dbContext = dbContext;
    
    public async Task<bool> CreateDepartment(DepartmentModel department)
    {
        return await Create(department);
    }
    
    public async Task<bool> UpdateDepartment(DepartmentModel department)
    {
        return await Update(department);
    }
    
    public async Task<bool> DeleteDepartment(DepartmentModel department)
    {
        return await Delete(department);
    }
    
    public async Task<IEnumerable<DepartmentModel>> GetAllDepartments()
    {
        return await GetAll<DepartmentModel>();
    }
    
    public async Task<DepartmentModel?> GetDepartmentById(int id)
    {
        return await GetById<DepartmentModel>(id);
    }
}