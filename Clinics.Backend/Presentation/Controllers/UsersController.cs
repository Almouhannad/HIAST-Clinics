using Application.Users.Commands.Login;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Presentation.Controllers.Base;

namespace Presentation.Controllers;

[Route("api/Users")]
public class UsersController : ApiController
{
    #region CTOR DI
    public UsersController(ISender sender) : base(sender)
    {
    }
    #endregion

    [HttpPost]
    public async Task<IActionResult> LoginUser([FromBody] LoginCommand command)
    {
        var result = await _sender.Send(command);

        if (result.IsFailure)
            return HandleFailure(result);

        return Ok(result.Value);
    }

}
