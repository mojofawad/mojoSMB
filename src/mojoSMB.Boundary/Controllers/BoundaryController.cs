using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace mojoSMB.Boundary.Controllers;

[ApiController]
[Route("mojosmb/[controller]")]
public class BoundaryController(ILogger<BoundaryController> logger) : ControllerBase
{
    private readonly ILogger<BoundaryController> _logger = logger;

    [HttpGet(Name = "GetSmbBoundary")]
    public IEnumerable<SmbBoundaryViewModel> Get()
    {
        return
        [
            new SmbBoundaryViewModel("BoundaryOne", 1, "The description of BoundaryOne", "Type: bool"),
            new SmbBoundaryViewModel("BoundaryTwo", 2, "The description of BoundaryTwo", "Type: string"),
            new SmbBoundaryViewModel("BoundaryThree", 3, "The description of BoundaryThree", "Type: int")
        ];
        
    }
}

public class SmbBoundaryViewModel(string boundaryName, int boundaryValue, string boundaryDescription, string boundaryType)
{
    public string BoundaryName { get; set; } = boundaryName;
    public int BoundaryValue { get; set; } = boundaryValue;
    public string BoundaryDescription { get; set; } = boundaryDescription;
    public string BoundaryType { get; set; } = boundaryType;
}