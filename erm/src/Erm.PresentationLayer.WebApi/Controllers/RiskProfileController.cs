using Microsoft.AspNetCore.Mvc;

namespace Erm.PresentationLayer.WebApi;

[ApiController]
[Route("api/riskprofiles")]
public sealed class RiskProfileController : ControllerBase
{
    [HttpGet]
    public string Get()
    {
        return "Hello from RiskProfileController";
    }
}

