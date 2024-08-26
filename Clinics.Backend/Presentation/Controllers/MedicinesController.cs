using Application.Doctors.Commands.ChangeStatusByUserId;
using Application.Doctors.Queries.GetAllDoctors;
using Application.Doctors.Queries.GetStatusByUserId;
using Application.Employees.Queries.GetAvailable;
using Application.Medicines.Queries.GetAllWithPrefix;
using Domain.Entities.Identity.UserRoles;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Controllers.Base;

namespace Presentation.Controllers;

[Route("api/Medicines")]
public class MedicinesController : ApiController
{

    #region DI for MeditR sender
    public MedicinesController(ISender sender) : base(sender)
    {
    }
    #endregion

    //[Authorize(Roles = Roles.DoctorName)]
    [HttpGet]
    public async Task<IActionResult> GetAllWithPrefix([FromQuery] string? prefix = null)
    {
        var query = new GetAllMedicinesWithPrefixQuery { Prefix = prefix };
        var result = await _sender.Send(query);
        if (result.IsFailure)
            return HandleFailure(result);
        return Ok(result.Value);
    }


}
