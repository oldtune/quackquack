using Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace QuackQuack.Controllers;
public abstract class ExtendedControllerBase : ControllerBase
{
    [NonAction]
    protected IActionResult DelegateCouldBeFailed(CouldBeFailed couldBeFailedOperation)
    {
        if (couldBeFailedOperation.Failed)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        return Ok();
    }
}