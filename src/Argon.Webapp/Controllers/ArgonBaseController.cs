using Microsoft.AspNetCore.Mvc;

namespace Argon.Webapp.Controllers
{
    public class ArgonBaseController : Controller
    {
        protected IActionResult Error(string error)
        {
            return BadRequest(error);
        }
    }
}
