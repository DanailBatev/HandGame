using HandGame.Application.Models.ResponseModels.Choice;

namespace HandGame.Application.Interfaces.Choice.Queries
{
    public interface IGetRandomChoiceQuery
    {
        Task<ChoiceResponseModel> Execute();
    }
}