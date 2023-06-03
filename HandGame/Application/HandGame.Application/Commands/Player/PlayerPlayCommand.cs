using HandGame.Application.Boundaries.Choice;
using HandGame.Application.Interfaces.Player.Commands;
using HandGame.Application.Models.Enums;
using HandGame.Application.Models.ResponseModels.Player;

namespace HandGame.Application.UseCases.Player
{
    public class PlayerPlayCommand : IPlayerPlayCommand
    {
        //private readonly ILoggerService<GetAllChoicesQuery> _logger;
        private readonly IChoiceService _choiceService;

        public PlayerPlayCommand(
            //ILoggerService<GetAllChoicesQuery> logger
            IChoiceService choiceService)
        {
            //_logger = logger;
            _choiceService = choiceService;
        }

        public async Task<PlayResultResponseModel> Execute(int choiceId)
        {
            PlayResultResponseModel result = new PlayResultResponseModel();
            try
            {
                List<Domain.Entities.Choice.Choice> choices = await _choiceService.GetAllChoices();

                int playerChoice = choiceId;

                if (!choices.Select(x=>x.Id).Contains(choiceId))
                {
                    //this.logger.LogError(ex, "Error occurred while trying to play with choiceId {choiceId}",choiceId);
                    //return Error;
                    throw new Exception("От 1 до 5!");
                }

                Domain.Entities.Choice.Choice botChoice = await _choiceService.GetRandomChoice();

                string PlayerStatus = DetermineWinner(playerChoice, botChoice.Id);

                result.Result = PlayerStatus;
                result.BotChoice = botChoice.Name;
                result.PlayerChoice = choices.First(x=>x.Id == choiceId).Name;

                return result;
            }
            catch (Exception ex)
            {
                //this.logger.LogError(ex, "Error occurred while trying to play with choiceId {choiceId}",choiceId);
                //return Error;
                throw ex; // This is just so the code can run. Because of "not all code paths return.." error
            }
        }

        private static string DetermineWinner(int playerChoice, int computerChoice)
        {
            if (playerChoice == computerChoice)
            {
                return GameResultEnum.Draw.ToString();
            }
            else if (
                (playerChoice == 1 && (computerChoice == 3 || computerChoice == 4)) ||
                (playerChoice == 2 && (computerChoice == 1 || computerChoice == 5)) ||
                (playerChoice == 3 && (computerChoice == 2 || computerChoice == 4)) ||
                (playerChoice == 4 && (computerChoice == 2 || computerChoice == 5)) ||
                (playerChoice == 5 && (computerChoice == 1 || computerChoice == 3))
            )
            {
                return GameResultEnum.Win.ToString();
            }
            else
            {
                return GameResultEnum.Loose.ToString();
            }
        }
    }
}