namespace Assignment.DomainModel.DTOs;

public class DepartmentDTO
{
    public class CreateDepartmentDTO
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public decimal Budget { get; set; }
    }
    
    public class UpdateDepartmentDTO
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public decimal Budget { get; set; }
    }
}