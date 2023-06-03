using HandGame.Application.Models.ResponseModels.Choice;

namespace HandGame.Application.Interfaces.Choice.Queries
{
    public interface IGetAllChoicesQuery
    {
        Task<List<ChoiceResponseModel>> Execute();
    }
}