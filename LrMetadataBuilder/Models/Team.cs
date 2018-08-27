using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LrMetadataBuilder.Models
{
    public class Team
    {

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("League")]
        public int LeagueId { get; set; }

        public virtual League League { get; set; }

        [InverseProperty("AwayTeam")]
        public ICollection<Game> AwayGames { get; set; }
        [InverseProperty("HomeTeam")]
        public ICollection<Game> HomeGames { get; set; }

    }
}
