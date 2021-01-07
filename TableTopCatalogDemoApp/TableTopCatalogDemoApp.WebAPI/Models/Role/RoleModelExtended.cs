using System.Collections.Generic;
using TableTopCatalogDemoApp.WebAPI.Models.TeamMember;

namespace TableTopCatalogDemoApp.WebAPI.Models.Role
{
    public class RoleModelExtended : RoleModel
    {
        public List<TeamMemberRoleModel> Members { get; set; }
    }
}
