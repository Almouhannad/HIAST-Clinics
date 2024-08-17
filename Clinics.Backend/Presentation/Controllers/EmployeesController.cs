using Application.Employees.Commands.Create;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeesController : ControllerBase
{
    #region DI for MeditR sender
    private readonly ISender _sender;
    public EmployeesController(ISender sender)
    {
        _sender = sender;
    }
    #endregion


    [HttpPost]
    public async Task<IActionResult> Create(CreateEmployeeCommand command)
    {
        await _sender.Send(command);
        return Ok();
    }
}
