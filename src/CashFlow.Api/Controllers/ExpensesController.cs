using CashFlow.Application.UseCase.Expenses.Register;
using CashFlow.Communication.Request;
using CashFlow.Communication.Response;
using Microsoft.AspNetCore.Mvc;

namespace CashFlow.Api.Controllers;

[Route("api/[controller]")]
[ProducesResponseType(typeof(ResponseRegisterExpenseJson), 201)]
[ApiController]
public class ExpensesController : ControllerBase
{
    [HttpPost]
    public IActionResult Register([FromBody] RequestRegisterExpenseJson request) 
    {
        try
        {
            var useCase = new RegisterExpenseUseCase();
            var response = useCase.Execute(request);
            return Created(string.Empty, response); ;
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
        catch { return StatusCode(StatusCodes.Status500InternalServerError,"unknown error");}
       
    }

}
