using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace Backend.Database.Models;

public class User
{
    [Key]
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public ClaimsPrincipal Create()
    {
        var claims = new List<Claim>
        {
            new(ClaimTypes.Name, Username),
            new(ClaimTypes.Email, Email),
            new(ClaimTypes.Sid, Id.ToString())
        };
        
        return new ClaimsPrincipal(new ClaimsIdentity(claims));
    }
}