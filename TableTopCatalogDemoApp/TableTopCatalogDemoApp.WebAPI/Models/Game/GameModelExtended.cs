using System.Collections.Generic;
using TableTopCatalogDemoApp.WebAPI.Models.Publisher;
using TableTopCatalogDemoApp.WebAPI.Models.TeamMember;

namespace TableTopCatalogDemoApp.WebAPI.Models.Game
{
    public class GameModelExtended : GameModel
    {
        public PublisherModel Publisher { get; set; }
        public List<TeamMemberGameModel> TeamMembers { get; set; }
    }
}
