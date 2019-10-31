using Application.Coach.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlainCQRS.Core.Commands;
using System.Threading.Tasks;
using TraingAppBackEnd.ViewModels;

namespace TraingAppBackEnd.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/coach")]
    public class CoachController : ControllerBase
    {
        private readonly ICommandSenderAsync commandSender;

        public CoachController(ICommandSenderAsync commandSender)
        {
            this.commandSender = commandSender;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> CreateCoach([FromBody] RegisterReqest reqest)
        {
            var comand = new CreateCoachCommand(
                login: reqest.Login,
                password: reqest.Password,
                firstName: reqest.FirstName,
                lastName: reqest.LastName,
                email: reqest.Email,
                preSharedKey: reqest.PreSharedKey
                );

            await commandSender.SendAsync(comand);

            return Ok();
        }

        [HttpPost("create-traing")]
        public async Task<IActionResult> CreateTrening([FromBody] NewTrainingReqest reqest)
        {
            var command = new CreateTrainingCommand(
                runnerId: reqest.RunnerId,
                timeToDo: reqest.TimeToDo,
                details: reqest.Details,
                comments: reqest.Comments
                );

            await commandSender.SendAsync(command);

            return Ok();
        }
    }
}
