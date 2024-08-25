using Application.Employees.Commands.AttachFamilyMemberToEmployee;
using Application.Employees.Commands.CreateEmployee;
using Application.Employees.Queries.GetById;
using Application.Employees.Queries.GetBySerialNumber;
using Domain.Entities.Identity.UserRoles;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Controllers.Base;

namespace Presentation.Controllers;

[Route("api/Employees")]
public class EmployeesController : ApiController
{

    #region DI for MeditR sender
    public EmployeesController(ISender sender) : base(sender)
    {
    }
    #endregion

    //[Authorize(Roles = Roles.ReceptionistName)]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateEmployeeCommand command)
    {
        var result = await _sender.Send(command);
        if (result.IsFailure)
            return HandleFailure(result);
        return Created();
    }

    //[Authorize(Roles = Roles.ReceptionistName)]
    [HttpPost("SerialNumber")] // It's a get, but serial number shouldn't be sent via routing, so we'll use post
    public async Task<IActionResult> GetBySerialNumber([FromBody] GetEmployeeBySerialNumberQuery query)
    {
        var result = await _sender.Send(query);
        if (result.IsFailure)
            return HandleFailure(result);
        return Ok(result.Value);
    }

    //[Authorize(Roles = Roles.ReceptionistName)]
    [HttpGet("{id:int}")] // It's a get, but serial number shouldn't be sent via routing, so we'll use post
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var query = new GetEmployeeByIdQuery { Id = id };
        var result = await _sender.Send(query);
        if (result.IsFailure)
            return HandleFailure(result);
        return Ok(result.Value);
    }


    //[Authorize(Roles = Roles.ReceptionistName)]
    [HttpPut("FamilyMembers")]
    public async Task<IActionResult> AttachFamilyMember([FromBody] AttachFamilyMemberToEmployeeCommand command)
    {
        var result = await _sender.Send(command);
        if (result.IsFailure)
            return HandleFailure(result);
        return Ok();
    }
}
