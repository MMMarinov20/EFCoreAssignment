using Assignment.Infrasctructure.Interfaces;
using Assignment.DataAccess.Models;
using Assignment.DataAccess.Data.Repositories;
using Assignment.DataAccess.Interfaces;

namespace Assignment.Infrasctructure.Services;

public class DepartmentService(IBaseRepository repository, DepartmentRepository departmentRepository) : BaseService(repository), IDepartmentService
{
    private readonly DepartmentRepository _departmentRepository;
    
    public async Task<bool> CreateDepartment(DepartmentModel department)
    {
        return await _departmentRepository.CreateDepartment(department);
    }
    
    public async Task<bool> UpdateDepartment(DepartmentModel department)
    {
        return await _departmentRepository.UpdateDepartment(department);
    }
    
    public async Task<bool> DeleteDepartment(DepartmentModel department)
    {
        return await _departmentRepository.DeleteDepartment(department);
    }
    
    public async Task<IEnumerable<DepartmentModel>> GetAllDepartments()
    {
        return await _departmentRepository.GetAllDepartments();
    }
    
    public async Task<DepartmentModel?> GetDepartmentById(int id)
    {
        return await _departmentRepository.GetDepartmentById(id);
    }
}