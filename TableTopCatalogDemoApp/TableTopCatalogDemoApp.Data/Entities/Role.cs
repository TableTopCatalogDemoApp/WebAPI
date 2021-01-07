using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace TableTopCatalogDemoApp.Data.Entities
{
    [Index(nameof(Title), IsUnique = true)]
    public class Role
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        public virtual List<TeamMember> Members { get; set; }

    }
}
