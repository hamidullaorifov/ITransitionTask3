using Microsoft.AspNetCore.Mvc;

namespace ITransitionTask3.Controllers;

[Route("orifovhamidulla_gmail_com")]
[ApiController]
public class LcmController : ControllerBase
{
    [HttpGet]
    public IActionResult Get([FromQuery] string? x, [FromQuery] string? y)
    {
        if (!long.TryParse(x, out long a) || !long.TryParse(y, out long b) || a <= 0 || b <= 0)
        {
            return Content("NaN", "text/plain");
        }

        long gcd = Gcd(a, b);
        long lcm = (long)a / gcd * b; // use long to avoid overflow
        return Content(lcm.ToString(), "text/plain");
    }

    private long Gcd(long a, long b)
    {
        while (b != 0)
        {
            long t = b;
            b = a % b;
            a = t;
        }
        return a;
    }
}
