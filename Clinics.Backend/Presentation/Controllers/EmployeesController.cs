using Application.Employees.Commands.CreateEmployee;
using MediatR;
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


    [HttpPost]
    public async Task<IActionResult> Create(CreateEmployeeCommand command)
    {
        var result = await _sender.Send(command);
        if (result.IsFailure)
            return HandleFailure(result);
        return Created();
    }
}
