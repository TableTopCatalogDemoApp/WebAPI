namespace TableTopCatalogDemoApp.WebAPI.Models.Game
{
    public class GameModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? YearPublished { get; set; }
        public int? AgeFrom { get; set; }
        public int? PlayersFrom { get; set; }
        public int? PlayersTo { get; set; }
        public int? SessionFrom { get; set; }
        public int? SessionTo { get; set; }
    }
}
