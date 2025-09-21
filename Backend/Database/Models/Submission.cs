using System.ComponentModel.DataAnnotations;

namespace Backend.Database.Models;

public class Submission
{
    [Key]
    public int Id { get; set; }
    
    public User User { get; set; }
    
    public Challenge Challenge { get; set; }
    
    public DateTime Timestamp { get; set; }
}