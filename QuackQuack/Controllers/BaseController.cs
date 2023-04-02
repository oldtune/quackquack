using Microsoft.AspNetCore.Mvc;
using Shared.FunctionalTypes;

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

    [NonAction]
    protected IActionResult DelegateCouldBeNone<T>(CouldBeNone<T> something)
    {
        if (something.HasValue)
        {
            return Ok(something);
        }
        return BadRequest();
    }

    [NonAction]
    protected IActionResult DelegateCouldBeNone<T, TResult>(CouldBeNone<T> something, Func<T, TResult> func)
    {
        if (something.HasValue)
        {
            return Ok(func(something.Value));
        }

        return BadRequest();
    }
}