using HandGame.Application.Boundaries.Choice;
using HandGame.Application.Interfaces.Choice.Queries;
using HandGame.Application.Models.ResponseModels.Choice;

namespace HandGame.Application.Queries.Choice
{
    public class GetAllChoicesQuery : IGetAllChoicesQuery
    {
        //private readonly ILoggerService<GetAllChoicesQuery> _logger;
        private readonly IChoiceService _choiceService;

        public GetAllChoicesQuery
            (
            //ILoggerService<GetAllChoicesQuery> logger
            IChoiceService choiceService
            )
        {
            //_logger = logger;
            _choiceService = choiceService;
        }

        public async Task<List<ChoiceResponseModel>> Execute()
        {
            List<ChoiceResponseModel> result = new List<ChoiceResponseModel>();
            try
            {
                List<Domain.Entities.Choice.Choice> choices = await _choiceService.GetAllChoices();

                foreach (var choice in choices)
                {
                    ChoiceResponseModel current = new ChoiceResponseModel() { Id = choice.Id, Name = choice.Name };
                    result.Add(current);
                }

                return result;
            }
            catch (Exception ex)
            {
                //this.logger.LogError(ex, "Error occured on attempt to fetch all choices");
                //return Error;
                return result; // This is just so the code can run. Because of "not all code paths return.." error
            }
        }
    }
}