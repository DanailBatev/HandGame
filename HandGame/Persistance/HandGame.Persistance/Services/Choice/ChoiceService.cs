using HandGame.Application.Boundaries.Choice;
using HandGame.Persistance.Models.Choice;
using System.Net.Http.Formatting;
using Choice = HandGame.Domain.Entities.Choice.Choice;

namespace HandGame.Persistance.Services.Choice
{
    public class ChoiceService : IChoiceService
    {
        //private readonly IGenericRepository<ChoiceDataEntity> _choiceRepository;
        //private readonly IMapper _mapper;
        //private readonly ILoggerService<ChoiceService> _logger;
        //private readonly IConfiguration configuration;

        public ChoiceService(
            //IConfiguration configuration,
            //IGenericRepository<ChoiceDataEntity> choiceRepository,
            //IMapper mapper,
            //ILoggerService<ChoiceService> logger
            )
        {
            //this.configuration = configuration;
            //_choiceRepository = choiceRepository;
            //_mapper = mapper;
            //_logger = logger;
        }

        public async Task<Domain.Entities.Choice.Choice> GetRandomChoice()
        {
            try
            {
                RandomNumberResponseModel randomNumber = new RandomNumberResponseModel(-1);

                var client = new HttpClient();
                //string url = this.configuration.GetSection(UrlHolder).Value; //This can be taken from env settings
                string url = "https://rpssl.olegbelousov.online/random";

                while (true)
                {
                    HttpResponseMessage response = await client.GetAsync(url); //As no instructions are given I will not handle the Unsuccessful requests
                    if (response.IsSuccessStatusCode)
                    {
                        randomNumber = await response.Content.ReadAsAsync<RandomNumberResponseModel>(new[] { new JsonMediaTypeFormatter() });

                        Dictionary<int, string> choiceEntities = new Dictionary<int, string>() {
                            {1, "rock" },
                            {2, "paper" },
                            {3, "scissors" },
                            {4, "lizard" },
                            {5, "spock" },
                        };

                        Domain.Entities.Choice.Choice choice = new Domain.Entities.Choice.Choice();

                        if (randomNumber.Random != -1)
                        {
                            switch (randomNumber.Random)
                            {
                                case int n when (n < 50):
                                    choice = new Domain.Entities.Choice.Choice() { Id = choiceEntities.FirstOrDefault(x => x.Key == 1).Key, Name = choiceEntities.FirstOrDefault(x => x.Key == 1).Value };
                                    break;
                                case int n when (n < 100):
                                    choice = new Domain.Entities.Choice.Choice() { Id = choiceEntities.FirstOrDefault(x => x.Key == 2).Key, Name = choiceEntities.FirstOrDefault(x => x.Key == 2).Value };
                                    break;
                                case int n when (n < 150):
                                    choice = new Domain.Entities.Choice.Choice() { Id = choiceEntities.FirstOrDefault(x => x.Key == 3).Key, Name = choiceEntities.FirstOrDefault(x => x.Key == 3).Value };
                                    break;
                                case int n when (n < 200):
                                    choice = new Domain.Entities.Choice.Choice() { Id = choiceEntities.FirstOrDefault(x => x.Key == 4).Key, Name = choiceEntities.FirstOrDefault(x => x.Key == 4).Value };
                                    break;
                                case int n when (n <= 255):
                                    choice = new Domain.Entities.Choice.Choice() { Id = choiceEntities.FirstOrDefault(x => x.Key == 5).Key, Name = choiceEntities.FirstOrDefault(x => x.Key == 5).Value };
                                    break;
                                default:
                                    //this.logger.LogError(ex, "Error occured on attempt to get random choice!");
                                    //throw new UnableToGetRandomChoiceException("Unable to get random choice!", ex);
                                    break;
                            }
                        }
                        else
                        {
                            //this.logger.LogError(ex, "Error occured on attempt to get random choice!");
                            //throw new UnableToGetRandomChoiceException("Unable to get random choice!", ex);
                        }

                        return choice;
                    }

                }

            }
            catch (Exception ex)
            {
                //this.logger.LogError(ex, "Error occured on attempt to get random choice!");
                //throw new UnableToGetRandomChoiceException("Unable to get random choice!", ex);
                throw new Exception();// just so the code can run;
            }
        }

        public async Task<List<Domain.Entities.Choice.Choice>> GetAllChoices()
        {
            try
            {
                Dictionary<int, string> choiceEntities = new Dictionary<int, string>() {
                    {1, "rock" },
                    {2, "paper" },
                    {3, "scissors" },
                    {4, "lizard" },
                    {5, "spock" },
                };

                List<Domain.Entities.Choice.Choice> choices = new List<Domain.Entities.Choice.Choice>();

                foreach (var choiceEntity in choiceEntities)
                {
                    Domain.Entities.Choice.Choice current = new Domain.Entities.Choice.Choice() { Id = choiceEntity.Key, Name = choiceEntity.Value };
                    choices.Add(current);
                }

                return choices;
            }
            catch (Exception ex)
            {
                //this.logger.LogError(ex, "Error occured on attempt to get all choices!");
                //throw new UnableToGetAllChoicesException("Unable to get all choices!", ex);
                throw new Exception();// just so the code can run;
            }
        }
    }
}
