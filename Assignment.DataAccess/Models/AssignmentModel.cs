using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Assignment.DataAccess.Data.Contexts;
using Assignment.DataAccess.Interfaces;

namespace Assignment.DataAccess.Models;

public class AssignmentModel : IBaseModel
{
    [Required]
    [Key]
    public int Id { get; set; }
    
    [Required]
    [ForeignKey("Employee")]
    public int EmployeeId { get; set; }
    
    [Required]
    [ForeignKey("Project")]
    public int ProjectId { get; set; }
    
    [Required]
    public int HoursWorked { get; set; }
    
    [Required]
    [StringLength(32)]
    public string Role { get; set; }
}