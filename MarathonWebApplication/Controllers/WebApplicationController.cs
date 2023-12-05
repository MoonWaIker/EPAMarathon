using Marathon.Services.Models;
using Microsoft.AspNetCore.Mvc;

namespace Marathon.WebApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WebApplicationController(ILogger<WebApplicationController> logger) : ControllerBase
    {
        [HttpPost("/CreateAccount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> CreateAccount(string Email, string Password)
        {
            try
            {
                _ = new User()
                {
                    Email = Email,
                    Password = Password
                };

                return Ok();
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);

                return StatusCode(500);
            }
        }
    }
}
