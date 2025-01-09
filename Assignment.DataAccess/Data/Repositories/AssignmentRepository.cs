using Assignment.DataAccess.Data.Contexts;
using Assignment.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment.DataAccess.Data.Repositories;

public class AssignmentRepository(AssignmentDbContext dbContext) : BaseRepository(dbContext)
{
    private readonly AssignmentDbContext _dbContext = dbContext;
    
    public async Task<bool> CreateAssignment(AssignmentModel assignment)
    {
        return await Create(assignment);
    }
    
    public async Task<bool> UpdateAssignment(AssignmentModel assignment)
    {
        return await Update(assignment);
    }
    
    public async Task<bool> DeleteAssignment(AssignmentModel assignment)
    {
        return await Delete(assignment);
    }
    
    public async Task<IEnumerable<AssignmentModel>> GetAllAssignments()
    {
        return await GetAll<AssignmentModel>();
    }
    
    public async Task<AssignmentModel?> GetAssignmentById(int id)
    {
        return await GetById<AssignmentModel>(id);
    }
}