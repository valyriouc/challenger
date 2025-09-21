using System.ComponentModel.DataAnnotations;

namespace Backend.Database.Models;

public class Challenge
{
    [Key]
    public int Id { get; set; }
    
    public string Title { get; set; } = null!;
    
    public string Description { get; set; } = null!;
    
    public ICollection<Rule> Rules { get; set; } = new List<Rule>();
    
    public User Owner { get; set; } = null!;

    public ICollection<User> Participants { get; set; } = [];
    
    public DateTime StartDate { get; set; }
    
    public DateTime EndDate { get; set; }
}

public sealed class Rule
{
    [Key]
    public int Id { get; set; }
    
    public string Name { get; set; } = null!;
    
    public string Description { get; set; } = null!;
}