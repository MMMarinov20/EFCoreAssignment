using Microsoft.EntityFrameworkCore;
using Assignment.DataAccess.Data.Contexts;
using Assignment.DataAccess.Interfaces;
namespace Assignment.DataAccess.Data.Repositories;

public class BaseRepository(AssignmentDbContext dbContext) : IBaseRepository
{
    private readonly AssignmentDbContext _dbContext = dbContext;
    
    public async Task<bool> Create<T>(T entity) where T : class
    {
        await _dbContext.Set<T>().AddAsync(entity);
        return await _dbContext.SaveChangesAsync() > 0;
    }
    
    public async Task<bool> Update<T>(T entity) where T : class
    {
        _dbContext.Set<T>().Update(entity);
        return await _dbContext.SaveChangesAsync() > 0;
    }
    
    public async Task<bool> Delete<T>(T entity) where T : class
    {
        _dbContext.Set<T>().Remove(entity);
        return await _dbContext.SaveChangesAsync() > 0;
    }
    
    public async Task<T?> GetById<T>(int id) where T : class
    {
        return await _dbContext.Set<T>().FindAsync(id);
    }
    
    public async Task<IEnumerable<T>> GetAll<T>() where T : class
    {
        return await _dbContext.Set<T>().ToListAsync();
    }
}