using Application.Doctors.Commands.ChangeStatusByUserId;
using Application.Doctors.Queries.GetAllDoctors;
using Application.Doctors.Queries.GetStatusByUserId;
using Application.Employees.Queries.GetAvailable;
using Application.Visits.Commands.Create;
using Application.Visits.Queries.GetAllByPatientId;
using Domain.Entities.Identity.UserRoles;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Controllers.Base;

namespace Presentation.Controllers;

[Route("api/Visits")]
public class VisitsController : ApiController
{

    #region DI for MeditR sender
    public VisitsController(ISender sender) : base(sender)
    {
    }
    #endregion

    //[Authorize(Roles = Roles.DoctorName)]
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetAllByPatientId([FromRoute(Name = "id")] int patientId)
    {
        GetAllVisitsByPatientIdQuery query = new GetAllVisitsByPatientIdQuery { PatientId = patientId };
        var result = await _sender.Send(query);
        if (result.IsFailure)
            return HandleFailure(result);
        return Ok(result.Value);
    }

    //[Authorize(Roles = Roles.DoctorName)]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateVisitCommand command)
    {
        var result = await _sender.Send(command);
        if (result.IsFailure)
            return HandleFailure(result);
        return Ok();
    }

}
