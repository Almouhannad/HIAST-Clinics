using Application.Doctors.Queries.GetAllDoctors;
using Application.Employees.Queries.GetAvailable;
using MediatR;
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
}
