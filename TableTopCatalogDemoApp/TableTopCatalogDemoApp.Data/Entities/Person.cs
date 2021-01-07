using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace TableTopCatalogDemoApp.Data.Entities
{
    [Index(nameof(FirstName), nameof(LastName), IsUnique = true)]
    public class Person
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        public virtual List<TeamMember> MemberOf { get; set; }
    }
}
