using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages.Internal;

namespace LrMetadataBuilder.Models
{
    public class Game
    {
        [Key]
        public int Id { get; set; }
        public int? EventId { get; set; } // needs to be nullable as not all games are part of bigger event 
        [ForeignKey("HomeTeam")]
        public int HomeTeamId { get; set; }
        [ForeignKey("AwayTeam")]
        public int AwayTeamId { get; set; }
        public int HomeScore { get; set; }
        public int AwayScore { get; set; }

        public virtual Team HomeTeam { get; set; }
        public virtual Team AwayTeam { get; set; }
    }
}
