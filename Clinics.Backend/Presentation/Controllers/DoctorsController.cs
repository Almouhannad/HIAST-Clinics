using Application.Doctors.Commands.ChangeStatusByUserId;
using Application.Doctors.Queries.GetAllDoctors;
using Application.Doctors.Queries.GetStatusByUserId;
using Application.Employees.Queries.GetAvailable;
using Domain.Entities.Identity.UserRoles;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Controllers.Base;

namespace Presentation.Controllers;

[Route("api/Doctors")]
public class DoctorsController : ApiController
{

    #region DI for MeditR sender
    public DoctorsController(ISender sender) : base(sender)
    {
    }
    #endregion

    //[Authorize(Roles = Roles.ReceptionistName)]
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var query = new GetAllDoctorsQuery();
        var result = await _sender.Send(query);
        if (result.IsFailure)
            return HandleFailure(result);
        return Ok(result.Value);
    }

    //[Authorize(Roles = Roles.ReceptionistName)]
    [HttpGet("Available")]
    public async Task<IActionResult> GetAllAvailable()
    {
        var query = new GetAvailableDoctorsQuery();
        var result = await _sender.Send(query);
        if (result.IsFailure)
            return HandleFailure(result);
        return Ok(result.Value);
    }

    //[Authorize(Roles = Roles.DoctorName)]
    [HttpGet("Status/{id:int}")]
    public async Task<IActionResult> GetStatusByUserId([FromRoute(Name = "id")] int userId)
    {
        GetDoctorStatusByUserIdQuery query = new GetDoctorStatusByUserIdQuery { UserId = userId };
        var result = await _sender.Send(query);
        if (result.IsFailure)
            return HandleFailure(result);
        return Ok(result.Value);
    }

    //[Authorize(Roles = Roles.DoctorName)]
    [HttpPost("Status")]
    public async Task<IActionResult> ChangeStatusByUserId([FromBody] ChangeStatusByUserIdCommand command)
    {
        var result = await _sender.Send(command);
        if (result.IsFailure)
            return HandleFailure(result);
        return Ok();
    }
}
