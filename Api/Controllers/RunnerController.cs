using System.Threading.Tasks;
using Application.Runner.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlainCQRS.Core.Commands;
using TraingAppBackEnd.ViewModels;

namespace TraingAppBackEnd.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/runner")]    
    public class RunnerController : ControllerBase
    {
        private readonly ICommandSenderAsync commandSender;

        public RunnerController(ICommandSenderAsync commandSender)
        {
            this.commandSender = commandSender;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterReqest reqest)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var command = new CreateRunnerCommand(
                login: reqest.Login,
                password: reqest.Password,
                firstName: reqest.FirstName,
                lastName: reqest.LastName,
                email: reqest.Email,
                preSharedKey: reqest.PreSharedKey
                );

            await commandSender.SendAsync(command);

            return Ok();
        }
    }
}