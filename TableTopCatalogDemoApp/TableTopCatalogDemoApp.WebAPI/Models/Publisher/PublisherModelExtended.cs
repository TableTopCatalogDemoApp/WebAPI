using System.Collections.Generic;
using TableTopCatalogDemoApp.WebAPI.Models.Game;

namespace TableTopCatalogDemoApp.WebAPI.Models.Publisher
{
    public class PublisherModelExtended : PublisherModel
    {
        public List<GameModel> Games { get; set; }
    }
}
