﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LrMetadataBuilder.Models
{
    public interface ITeamRepository
    {
        IEnumerable<Team> GetAllTeams();
        Team GetTeamById(int teamId);
        void Add(Team team);
        void Delete(Team team);
        void Edit(Team team);
        void Save();
        IEnumerable<SelectListItem> GetSelectListItems();
    }
}
