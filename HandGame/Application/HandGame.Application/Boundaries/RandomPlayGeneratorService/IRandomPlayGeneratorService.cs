namespace HandGame.Application.Boundaries.RandomPlayGeneratorService
{
    public interface IRandomPlayGeneratorService
    {
        Task<Domain.Entities.Choice.Choice> GetRandomPlay();
    }
}
