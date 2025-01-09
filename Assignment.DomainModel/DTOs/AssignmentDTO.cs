namespace Assignment.DomainModel.DTOs;

public class AssignmentDTO
{
    public class CreateAssignmentDTO
    {
        public int EmployeeId { get; set; }
        public int ProjectId { get; set; }
        public int HoursWorked { get; set; }
        public string Role { get; set; }
    }
    
    public class UpdateAssignmentDTO
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int ProjectId { get; set; }
        public int HoursWorked { get; set; }
        public string Role { get; set; }
    }
}