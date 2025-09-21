using System.ComponentModel.DataAnnotations;

namespace Backend.Database.Models;

public class Follows
{
    [Key]
    public int Id { get; set; }
    
    public User Leader { get; set; } = null!;
    
    public ICollection<User> Followers { get; set; } = new List<User>();
}