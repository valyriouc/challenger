using Backend.Transfer.Messages;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

public sealed class ChallengeController : ChallengerBaseController
{
    [HttpGet]
    public async Task<IActionResult> GetChallengesAsync(CancellationToken cancellationToken)
    {
        await Task.Delay(1000, cancellationToken);
        return Ok(new RespMessage(true, "Challenges retrieved successfully"));
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateChallengeAsync(CancellationToken cancellationToken)
    {
        await Task.Delay(1000, cancellationToken);
        return Ok(new RespMessage(true, "Challenge created successfully"));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetChallengeAsync(int id, CancellationToken cancellationToken)
    {

        return Ok();
    }

    [HttpPost("{id}/participate")]
    public async Task<IActionResult> ParticipateAsync(int id, CancellationToken cancellationToken)
    {
        return Ok();
    }
}