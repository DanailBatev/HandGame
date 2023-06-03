using HandGame.Application.Interfaces.Choice.Queries;
using HandGame.Application.Interfaces.Player.Commands;
using HandGame.Application.Models.ResponseModels.Choice;
using HandGame.Application.Models.ResponseModels.Player;
using Microsoft.AspNetCore.Mvc;

namespace HandGame.Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HandGameController : ControllerBase
    {
        private readonly ILogger<HandGameController> _logger;
        private readonly IGetAllChoicesQuery _getAllChoicesQuery;
        private readonly IGetRandomChoiceQuery _getRandomChoiceQuery;
        private readonly IPlayerPlayCommand _playerPlayCommand;

        public HandGameController(
            ILogger<HandGameController> logger,
            IGetAllChoicesQuery getAllChoicesQuery,
            IGetRandomChoiceQuery getRandomChoiceQuery,
            IPlayerPlayCommand playerPlayCommand)
        {
            _logger = logger;
            _getAllChoicesQuery = getAllChoicesQuery;
            _getRandomChoiceQuery = getRandomChoiceQuery;
            _playerPlayCommand = playerPlayCommand;
        }

        [HttpGet("Choices")]
        public async Task<IActionResult> GetChoices()
        {
            try
            {
                List<ChoiceResponseModel> allChoices = await _getAllChoicesQuery.Execute();
                return this.Ok(allChoices);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured on attempt to fetch all choices!");
            }

            return this.NotFound();
        }

        [HttpGet("Choice")]
        public async Task<IActionResult> GetChoice()
        {
            try
            {
                ChoiceResponseModel randomChoices = await _getRandomChoiceQuery.Execute();
                return this.Ok(randomChoices);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured on attempt to fetch random choice!");
            }

            return this.NotFound();
        }

        [HttpPost("Play")]
        public async Task<IActionResult> Play([FromHeader] int choiceId)
        {
            try
            {
                PlayResultResponseModel playResult = await _playerPlayCommand.Execute(choiceId);
                return this.Ok(playResult);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured on attempt to make a play!");
            }

            return this.NotFound();
        }
    }
}