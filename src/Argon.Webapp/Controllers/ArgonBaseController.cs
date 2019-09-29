using Argon.Webapp.Utils;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace Argon.Webapp.Controllers
{
    public class ArgonBaseController : Controller
    {
        protected IActionResult Error(string error)
        {
            return BadRequest(error);
        }

        protected IActionResult HandleCommandResult(CommandResult result)
        {
            return result.IsSuccess ? NoContent() : Error(result.Error);
        }

        protected IActionResult HandleQueryResult<T>(T result)
        {
            if (typeof(T) is ICollection)
                return HandleQueryCollectionResult(result);
            return HandleQueryElementResult(result);
        }

        private IActionResult HandleQueryCollectionResult<T>(T result)
        {
            return Ok(result);
        }

        private IActionResult HandleQueryElementResult<T>(T result)
        {
            if (result is null)
                return NotFound();
            return Ok(result);
        }
    }
}