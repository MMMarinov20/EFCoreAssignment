using Assignment.Infrasctructure.Interfaces;
using Assignment.DataAccess.Models;
using Assignment.DataAccess.Data.Repositories;
using Assignment.DataAccess.Interfaces;

namespace Assignment.Infrasctructure.Services;

public class AssignmentService(IBaseRepository repository, AssignmentRepository assignmentRepository) : BaseService(repository), IAssignmentService
{
    private readonly AssignmentRepository _assignmentRepository;
    
    public async Task<bool> CreateAssignment(AssignmentModel assignment)
    {
        return await _assignmentRepository.CreateAssignment(assignment);
    }
    
    public async Task<bool> UpdateAssignment(AssignmentModel assignment)
    {
        return await _assignmentRepository.UpdateAssignment(assignment);
    }
    
    public async Task<bool> DeleteAssignment(AssignmentModel assignment)
    {
        return await _assignmentRepository.DeleteAssignment(assignment);
    }
    
    public async Task<IEnumerable<AssignmentModel>> GetAllAssignments()
    {
        return await _assignmentRepository.GetAllAssignments();
    }
    
    public async Task<AssignmentModel?> GetAssignmentById(int id)
    {
        return await _assignmentRepository.GetAssignmentById(id);
    }
}