using Assignment.DataAccess.Models;

namespace Assignment.Infrasctructure.Interfaces;

public interface IAssignmentService : IBaseService
{
    Task<bool> CreateAssignment(AssignmentModel assignment);
    Task<bool> UpdateAssignment(AssignmentModel assignment);
    Task<bool> DeleteAssignment(AssignmentModel assignment);
    Task<IEnumerable<AssignmentModel>> GetAllAssignments();
    Task<AssignmentModel?> GetAssignmentById(int id);
}