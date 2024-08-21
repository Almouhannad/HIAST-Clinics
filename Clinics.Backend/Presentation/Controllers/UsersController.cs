using Application.Users.Commands.Login;
using Application.Users.Commands.RegisterDoctor;
using Domain.Entities.Identity.UserRoles;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
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

    [Authorize(Roles =Roles.AdminName)]
    [HttpPost("Doctors")]
    public async Task<IActionResult> RegisterDoctor([FromBody] RegisterDoctorCommand command)
    {
        var result = await _sender.Send(command);

        if (result.IsFailure)
            return HandleFailure(result);

        return Ok(result.Value);
    }

}
