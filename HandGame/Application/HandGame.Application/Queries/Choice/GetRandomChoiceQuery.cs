using HandGame.Application.Boundaries.Choice;
using HandGame.Application.Interfaces.Choice.Queries;
using HandGame.Application.Models.ResponseModels.Choice;

namespace HandGame.Application.Queries.Choice
{
    public class GetRandomChoiceQuery : IGetRandomChoiceQuery
    {
        private readonly IChoiceService _choiceService;

        public GetRandomChoiceQuery(IChoiceService choiceService)
        {
            _choiceService = choiceService;
        }

        public async Task<ChoiceResponseModel> Execute()
        {
            ChoiceResponseModel result = new ChoiceResponseModel();
            try
            {
                Domain.Entities.Choice.Choice choice = await _choiceService.GetRandomChoice();

                result = new ChoiceResponseModel() { Id = choice.Id, Name = choice.Name };

                return result;
            }
            catch (Exception ex)
            {
                //this.logger.LogError(ex, "Error occured on attempt to fetch random choice");
                //return Error;
                return result; // This is just so the code can run. Because of "not all code paths return.." error
            }
        }
    }
}