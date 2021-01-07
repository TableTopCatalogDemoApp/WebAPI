using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TableTopCatalogDemoApp.Data.Entities
{
    public class Game
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Entities.Publisher))]
        public int? PublisherId { get; set; }
        public Publisher Publisher { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        public string Description { get; set; }

        public int? YearPublished { get; set; }

        [Range(0, 100)]
        public int? AgeFrom { get; set; }

        [Range(1, Int32.MaxValue)]
        public int? PlayersFrom { get; set; }
        [Range(1, Int32.MaxValue)]
        public int? PlayersTo { get; set; }

        [Range(1, Int32.MaxValue)]
        public int? SessionFrom { get; set; }
        [Range(1, Int32.MaxValue)]
        public int? SessionTo { get; set; }

        public virtual List<TeamMember> TeamMembers { get; set; }
    }
}
