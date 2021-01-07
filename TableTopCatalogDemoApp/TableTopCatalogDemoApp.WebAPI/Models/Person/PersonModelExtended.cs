using System.Collections.Generic;
using TableTopCatalogDemoApp.WebAPI.Models.TeamMember;

namespace TableTopCatalogDemoApp.WebAPI.Models.Person
{
    public class PersonModelExtended : PersonModel
    {
        public List<TeamMemberPersonModel> MemberOf { get; set; }
    }
}
