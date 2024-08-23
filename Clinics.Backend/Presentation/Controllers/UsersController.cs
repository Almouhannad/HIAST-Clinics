using Application.Users.Commands.Login;
using Application.Users.Commands.RegisterDoctor;
using Application.Users.Commands.RegisterReceptionist;
using Application.Users.Queries.GetAllDoctorUsers;
using Application.Users.Queries.GetAllReceptionistsUsers;
using Application.Users.Queries.GetDoctorUserById;
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

    #region Login
    [HttpPost]
    public async Task<IActionResult> LoginUser([FromBody] LoginCommand command)
    {
        var result = await _sender.Send(command);

        if (result.IsFailure)
            return HandleFailure(result);

        return Ok(result.Value);
    }

    #endregion

    #region Doctors
    [Authorize(Roles = Roles.AdminName)]
    [HttpPost("Doctors")]
    public async Task<IActionResult> RegisterDoctor([FromBody] RegisterDoctorCommand command)
    {
        var result = await _sender.Send(command);

        if (result.IsFailure)
            return HandleFailure(result);

        return Created();
    }

    [Authorize(Roles = Roles.AdminName)]
    [HttpGet("Doctors")]
    public async Task<IActionResult> GetAllDoctorUsers()
    {
        var query = new GetAllDoctorUsersQuery();
        var result = await _sender.Send(query);
        if (result.IsFailure)
            return HandleFailure(result);
        return Ok(result.Value);
    }

    [Authorize(Roles = Roles.AdminName)]
    [HttpGet("Doctors/{id:int}")]
    public async Task<IActionResult> GetDoctorUserById([FromRoute(Name ="id")] int id )
    {
        var query = new GetDoctorUserByIdQuery { Id = id };
        var result = await _sender.Send(query);
        if (result.IsFailure)
            return HandleFailure(result);
        return Ok(result.Value);
    }
    #endregion

    #region Receptionist
    [Authorize(Roles = Roles.AdminName)]
    [HttpPost("Receptionists")]
    public async Task<IActionResult> RegisterReceptionist([FromBody] RegisterReceptionistCommand command)
    {
        var result = await _sender.Send(command);

        if (result.IsFailure)
            return HandleFailure(result);

        return Created();
    }
    [Authorize(Roles = Roles.AdminName)]
    [HttpGet("Receptionists")]
    public async Task<IActionResult> GetAllReceptionistUsers()
    {
        var query = new GetAllReceptionistUsersQuery();
        var result = await _sender.Send(query);
        if (result.IsFailure)
            return HandleFailure(result);
        return Ok(result.Value);
    }
    #endregion


}
