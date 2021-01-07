using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace TableTopCatalogDemoApp.Data.Entities
{
    [Index(nameof(Title), IsUnique = true)]
    public class Publisher
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        public virtual List<Game> Games { get; set; }
    }
}
