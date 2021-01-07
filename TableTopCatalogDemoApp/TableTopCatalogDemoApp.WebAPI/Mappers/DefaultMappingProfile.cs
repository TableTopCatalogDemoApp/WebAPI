using AutoMapper;
using TableTopCatalogDemoApp.Data.Entities;
using TableTopCatalogDemoApp.WebAPI.Models.Game;
using TableTopCatalogDemoApp.WebAPI.Models.Person;
using TableTopCatalogDemoApp.WebAPI.Models.Publisher;
using TableTopCatalogDemoApp.WebAPI.Models.Role;
using TableTopCatalogDemoApp.WebAPI.Models.TeamMember;

namespace TableTopCatalogDemoApp.WebAPI.Mappers
{
    public class DefaultMappingProfile : Profile
    {
        public DefaultMappingProfile()
        {
            CreateMap<Game, GameModel>();
            CreateMap<Game, GameModelExtended>();

            CreateMap<Person, PersonModel>();
            CreateMap<Person, PersonModelExtended>();
            
            CreateMap<Publisher, PublisherModel>();
            CreateMap<Publisher, PublisherModelExtended>();

            CreateMap<Role, RoleModel>();
            CreateMap<Role, RoleModelExtended>();

            CreateMap<TeamMember, TeamMemberGameModel>();
            CreateMap<TeamMember, TeamMemberPersonModel>();
            CreateMap<TeamMember, TeamMemberRoleModel>();
        }
    }
}
