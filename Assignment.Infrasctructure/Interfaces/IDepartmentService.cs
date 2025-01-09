using Assignment.DataAccess.Models;

namespace Assignment.Infrasctructure.Interfaces;

public interface IDepartmentService : IBaseService
{
    Task<bool> CreateDepartment(DepartmentModel department);
    Task<bool> UpdateDepartment(DepartmentModel department);
    Task<bool> DeleteDepartment(DepartmentModel department);
    Task<IEnumerable<DepartmentModel>> GetAllDepartments();
    Task<DepartmentModel?> GetDepartmentById(int id);
}