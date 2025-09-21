using Backend.Database.Models;
using Backend.Services;
using Backend.Transfer.Messages;
using Backend.Transfer.User;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[AllowAnonymous]
public sealed class AuthController(
    IWebService<UserModel, User> service) : ChallengerBaseController
{
    [HttpPost("register")]
    public async Task<ActionResult> RegisterAsync(UserModel model, CancellationToken cancellationToken)
    {
        var result = await service.GetAsync(
                x => x.Username == model.Username || x.Email == model.Email,
                cancellationToken)
            .AsEnumerable();

        if (result.Any())
        {
            return BadRequest(
                new RespMessage(false, "User already exists"));
        }

        try
        {
            var id = await service.CreateAsync(model, cancellationToken);
            return Ok(new RespMessage(false, $"User created with id '{id}'"));
        }
        catch (Exception e)
        {
            return BadRequest(new RespMessage(false, e.Message));
        }
    }

    [HttpPost("login")]
    public async Task<ActionResult> LoginAsync(UserModel model, CancellationToken cancellationToken)
    {
        IEnumerable<User> result = await service.GetAsync(
                x => x.Username == model.Username && x.Email == model.Email,
                cancellationToken)
            .AsEnumerable();

        User[] users = result as User[] ?? result.ToArray();
        if (users.Length != 1)
        {
            return BadRequest(
                new RespMessage(false, "Invalid username or password"));
        }

        await base.HttpContext.SignInAsync(users.First().Create());
        
        return Ok(new RespMessage(true, "Login successful"));
    }

    [HttpDelete("logout")]
    public async Task<ActionResult> LogoutAsync()
    {
        return Ok();
    }
}