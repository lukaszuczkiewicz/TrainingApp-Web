using Api.ViewModels;
using Application.Coach.Commands;
using ApplicationQueries.Runners;
using ApplicationQueries.Training;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlainCQRS.Core.Commands;
using PlainCQRS.Core.Queries;
using System;
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
        private readonly IQueryDispatcherAsync queryDispatcher;

        public CoachController(ICommandSenderAsync commandSender, IQueryDispatcherAsync queryDispatcher)
        {
            this.commandSender = commandSender;
            this.queryDispatcher = queryDispatcher;
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
        
        [HttpPost("training")]
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

        [HttpGet("trainings")]
        public async Task<IActionResult> GetTrainings()
        {
            var query = new GetTrainingsQuery();

            var result = await queryDispatcher.ExecuteAsync(query);

            return Ok(result);
        }

        [HttpGet("runners")]
        public async Task<IActionResult> GetRunners()
        {
            var query = new GetRunnersQuery();

            var result = await queryDispatcher.ExecuteAsync(query);

            return Ok(result);
        }

        [HttpPost("runner")]
        public async Task<IActionResult> CreateRunner([FromBody] CreateRunnerViewModel request)
        {
            var command = new CreateRunnerCommand(
                firstName: request.FirstName, 
                lastName: request.LastName, 
                email: request.Email);

            await commandSender.SendAsync(command);

            return Ok();
        }

        [HttpPost("runner/update")]
        public async Task<IActionResult> UpdateRunner([FromBody] UpdateRunnerViewModel request)
        {
            var command = new UpdateRunnerCommand(
                id: request.Id,
                firstName: request.FirstName,
                lastName: request.LastName,
                email: request.Email);

            await commandSender.SendAsync(command);

            return Ok();
        }

        [HttpPost("runner/{runnerId}")]
        public async Task<IActionResult> DeleteRunner(Guid runnerId)
        {
            var command = new DeleteRunnerCommand(runnerId);

            await commandSender.SendAsync(command);

            return Ok();
        }
        [HttpPost("report-issue")]
        public async Task<IActionResult> ReportIssue(string msg)
        {


            return Ok();
        }
    }
}