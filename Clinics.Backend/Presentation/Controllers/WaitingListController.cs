using Application.Employees.Commands.AttachFamilyMemberToEmployee;
using Application.Employees.Commands.CreateEmployee;
using Application.WaitingList.Commands.CreateWaitingListRecord;
using Application.WaitingList.Commands.DeleteWaitingListRecord;
using Application.WaitingList.Queries;
using Domain.Entities.Identity.UserRoles;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Controllers.Base;

namespace Presentation.Controllers;

[Route("api/WaitingList")]
public class WaitingListController : ApiController
{

    #region DI for MeditR sender
    public WaitingListController(ISender sender) : base(sender)
    {
    }
    #endregion

    //[Authorize(Roles = Roles.ReceptionistName)]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateWaitingListRecordCommand command)
    {
        var result = await _sender.Send(command);
        if (result.IsFailure)
            return HandleFailure(result);
        return Created();
    }

    //[Authorize(Roles = Roles.ReceptionistName)]
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var query = new GetAllWaitingListRecordsQuery();
        var result = await _sender.Send(query);
        if (result.IsFailure)
            return HandleFailure(result);
        return Ok(result.Value);
    }

    //[Authorize(Roles = Roles.ReceptionistName)]
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute(Name ="id")] int id)
    {
        var command = new DeleteWaitingListRecordCommand
        {
            Id = id
        };
        var result = await _sender.Send(command);
        if (result.IsFailure)
            return HandleFailure(result);
        return Ok();
    }

}
