using System.Numerics;
using Microsoft.AspNetCore.Mvc;

namespace ITransitionTask3.Controllers;

[Route("orifovhamidulla_gmail_com")]
[ApiController]
public class LcmController : ControllerBase
{
    [HttpGet]
    public IActionResult Get([FromQuery] string? x, [FromQuery] string? y)
    {
        if (!BigInteger.TryParse(x, out BigInteger a) || !BigInteger.TryParse(y, out BigInteger b) || a < 0 || b < 0)
        {
            return Content("NaN", "text/plain");
        }

        BigInteger gcd = Gcd(a, b);
        BigInteger lcm = (BigInteger)a / gcd * b; // use BigInteger to avoid overflow
        return Content(lcm.ToString(), "text/plain");
    }

    private BigInteger Gcd(BigInteger a, BigInteger b)
    {
        if (a == 0 || b == 0)
        {
            return 0;
        }
        while (b != 0)
        {
            BigInteger t = b;
            b = a % b;
            a = t;
        }
        return a;
    }
}
