using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LrMetadataBuilder.ViewModels
{
    public class GameListViewModel
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        [Display(Name="Home Team")]
        public string HomeTeam { get; set; }
        [Display(Name="Away Team")]
        public string AwayTeam { get; set; }
        [Display(Name="Home Score")]
        public int HomeScore { get; set; }
        [Display(Name="Away Score")]
        public int AwayScore { get; set; }
        [Display(Name="Whistle Time")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = @"{ 0:HH:mm }")]
        public DateTime WhistleTime { get; set; }
        //TODO: need to add TeamListViewModel so we can pass through teams
    }
}
