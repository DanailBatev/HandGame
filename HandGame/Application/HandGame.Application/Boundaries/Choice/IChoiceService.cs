namespace HandGame.Application.Boundaries.Choice
{
    public interface IChoiceService
    {
        Task<List<Domain.Entities.Choice.Choice>> GetAllChoices();
        Task<Domain.Entities.Choice.Choice> GetRandomChoice();
    }
}