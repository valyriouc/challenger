using System.ComponentModel.DataAnnotations;

namespace Backend.Transfer.User;

public class UserModel
{
    [Required]
    public string Username { get; set; } = null!;

    [Required]
    public string Password { get; set; } = null!;
    
    [Required]
    public string Email { get; set; } = null!;
}