using Microsoft.AspNetCore.Mvc;

namespace Erm.PresentationLayer.WebApi;

public sealed class RiskProfileController : ControllerBase
{
    public string Get()
    {
        return "Hello from RiskProfileController";
    }
}

