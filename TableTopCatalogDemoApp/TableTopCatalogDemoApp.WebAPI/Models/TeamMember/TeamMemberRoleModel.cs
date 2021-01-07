using TableTopCatalogDemoApp.WebAPI.Models.Game;
using TableTopCatalogDemoApp.WebAPI.Models.Person;

namespace TableTopCatalogDemoApp.WebAPI.Models.TeamMember
{
    public class TeamMemberRoleModel
    {
        public PersonModel Person { get; set; }
        public GameModel Game { get; set; }
    }
}
