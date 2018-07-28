using System.Collections.Generic;
using LrMetadataBuilder.Models;

namespace LrMetadataBuilder.ViewModels
{
    public class LeagueViewModel
    {
        public string Title { get; set; }
        public List<League> Leagues;
        public League League;
    }
}
