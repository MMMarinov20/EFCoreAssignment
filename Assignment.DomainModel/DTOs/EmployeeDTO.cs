namespace Assignment.DomainModel.DTOs;

public class EmployeeDTO
{
    public class CreateEmployeeDTO
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public DateTime HireDate { get; set; }
        public decimal Salary { get; set; }
        public int DepartmentId { get; set; }
    }
    
    public class UpdateEmployeeDTO
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public DateTime HireDate { get; set; }
        public decimal Salary { get; set; }
        public int DepartmentId { get; set; }
    }
}