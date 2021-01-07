using TableTopCatalogDemoApp.WebAPI.Models.Person;
using TableTopCatalogDemoApp.WebAPI.Models.Role;

namespace TableTopCatalogDemoApp.WebAPI.Models.TeamMember
{
    public class TeamMemberGameModel
    {
        public RoleModel Role { get; set; }
        public PersonModel Person { get; set; }
    }
}
