using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using LrMetadataBuilder.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LrMetadataBuilder.ViewModels
{
    public class TeamViewModel
    {
        public string Title { get; set; }
        public int Id { get; set; }

        [Display(Name = "Team Name")]
        [Required(ErrorMessage = "Please provide a Team Name")]
        public string Name { get; set; }

        [Display(Name = "League")]
        public League League { get; set; }

        public int SelectedLeague { get; set; }
        public IEnumerable<SelectListItem> SelectLeagues { get; set; }

        public List<Team> Teams;
        public Team Team;
        public IEnumerable<League> Leagues;
    }
}
