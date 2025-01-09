using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Assignment.DataAccess.Data.Contexts;
using Assignment.DataAccess.Interfaces;

namespace Assignment.DataAccess.Models;

public class ProjectModel : IBaseModel
{

    [Required]
    [Key]
    public int Id { get; set; }
    
    [Required]
    [StringLength(16)]
    public string Name { get; set; }
    
    [Required]
    public DateTime StartDate { get; set; }
    
    [Required]
    public DateTime EndDate { get; set; }
    
    [Required]
    public decimal Budget { get; set; }
}