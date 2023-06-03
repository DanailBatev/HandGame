using HandGame.Application.Models.ResponseModels.Player;

namespace HandGame.Application.Interfaces.Player.Commands
{
    public interface IPlayerPlayCommand
    {
        Task<PlayResultResponseModel> Execute(int choiceId);
    }
}