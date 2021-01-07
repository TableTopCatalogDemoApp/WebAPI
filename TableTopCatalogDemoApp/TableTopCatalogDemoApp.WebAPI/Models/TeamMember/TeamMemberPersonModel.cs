using TableTopCatalogDemoApp.WebAPI.Models.Game;
using TableTopCatalogDemoApp.WebAPI.Models.Role;

namespace TableTopCatalogDemoApp.WebAPI.Models.TeamMember
{
    public class TeamMemberPersonModel
    {
        public RoleModel Role { get; set; }
        public GameModelExtended Game { get; set; }
    }
}
