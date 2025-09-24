using Microsoft.AspNetCore.Mvc;

namespace ITransitionTask3.Controllers;

[Route("orifovhamidulla_gmail_com")]
[ApiController]
public class LcmController : ControllerBase
{
    [HttpGet]
    public IActionResult Get([FromQuery] string? x, [FromQuery] string? y)
    {
        if (!int.TryParse(x, out int a) || !int.TryParse(y, out int b) || a <= 0 || b <= 0)
        {
            return Content("NaN", "text/plain");
        }

        int gcd = Gcd(a, b);
        long lcm = (long)a / gcd * b; // use long to avoid overflow
        return Content(lcm.ToString(), "text/plain");
    }

    private int Gcd(int a, int b)
    {
        while (b != 0)
        {
            int t = b;
            b = a % b;
            a = t;
        }
        return a;
    }
}
