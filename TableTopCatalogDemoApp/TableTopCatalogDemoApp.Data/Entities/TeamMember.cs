using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TableTopCatalogDemoApp.Data.Entities
{
    [Index(nameof(PersonId), nameof(RoleId), nameof(GameId), IsUnique = true)]
    public class TeamMember
    {
        [Required]
        [ForeignKey(nameof(Entities.Person))]
        public int PersonId { get; set; }
        public Person Person { get; set; }

        [Required]
        [ForeignKey(nameof(Entities.Role))]
        public int RoleId { get; set; }
        public Role Role { get; set; }

        [Required]
        [ForeignKey(nameof(Entities.Game))]
        public int GameId { get; set; }
        public Game Game { get; set; }
    }
}
