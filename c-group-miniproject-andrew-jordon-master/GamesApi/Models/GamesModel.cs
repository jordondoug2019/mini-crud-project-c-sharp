namespace GamesApi.Models
{
    // This is a model that defines the Game Information
    public class GamesModel
    {
        public long Id { get; set; }
        public string gameName { get; set; }
        public string gameGenre { get; set; }

        public string dateReleased {get; set;}
        public string synopsis {get; set;}
    }
}