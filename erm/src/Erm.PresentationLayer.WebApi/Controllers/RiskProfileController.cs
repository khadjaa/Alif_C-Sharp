using Erm.BussinessLayer;

using Microsoft.AspNetCore.Mvc;

namespace Erm.PresentationLayer.WebApi;

[ApiController]
[Route("api/riskprofiles")]
public sealed class RiskProfileController : ControllerBase
{
    private readonly RiskProfileService _riskProfileService;

    public RiskProfileController()
    {
        _riskProfileService = new();
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] RiskProfileInfo riskProfileInfo)
    {
        await _riskProfileService.CreateAsync(riskProfileInfo);
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> Query([FromQuery] string? query, [FromQuery] string? name)
    {
        if (!string.IsNullOrEmpty(query))
        {
            return Ok(await _riskProfileService.QueryAsync(query));
        }

        if (!string.IsNullOrEmpty(name))
        {
            return Ok(await _riskProfileService.GetAsync(name));
        }

        return BadRequest();
    }

    [HttpGet]
    [Route("{name}")]
    public async Task<IActionResult> GetByName([FromRoute] string name)
    {
        return Ok(await _riskProfileService.GetAsync(name));
    }
}