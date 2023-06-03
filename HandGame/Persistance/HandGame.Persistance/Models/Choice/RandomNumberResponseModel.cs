namespace HandGame.Persistance.Models.Choice
{
    internal class RandomNumberResponseModel
    {
        public RandomNumberResponseModel(int random)
        {
                this.Random = random;
        }

        internal int Random { get; set; }
    }
}
