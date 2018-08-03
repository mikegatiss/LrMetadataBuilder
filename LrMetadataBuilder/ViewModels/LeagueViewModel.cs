using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using LrMetadataBuilder.Models;

namespace LrMetadataBuilder.ViewModels
{
    public class LeagueViewModel
    {
        public int Id;

        [Display(Name= "League Name")]
        [Required(ErrorMessage = "Please provide a League Name")]
        public string Name;
        public string Title { get; set; }
        public List<League> Leagues;
        public League League;
    }
}
