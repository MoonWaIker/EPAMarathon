using Marathon.Interfaces.Services;
using Marathon.Services.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Marathon.WebApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WebApplicationController(ILogger<WebApplicationController> logger, IDataBase dataBase) : ControllerBase
    {
        [HttpPost("/CreateAccount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> CreateAccount(string Name, string Lastname, string Surname, string Email, string Password, string ConfirmedPassword)
        {
            if (Password != ConfirmedPassword)
            {
                return BadRequest("Passwords aren't the same.");
            }

            try
            {
                User user = new()
                {
                    Name = Name,
                    Lastname = Lastname,
                    Surname = Surname,
                    Email = Email,
                    Password = Password,
                    SignUpDate = DateOnly.FromDateTime(DateTime.Now)
                };

                dataBase.AddUser(user);

                return Ok();
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (DbUpdateException ex)
            {
                return Conflict(ex.Message);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);

                return StatusCode(500);
            }
        }
    }
}
