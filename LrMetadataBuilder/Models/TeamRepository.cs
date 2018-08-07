using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LrMetadataBuilder.Models
{
    public class TeamRepository : ITeamRepository
    {
        private readonly AppDbContext _appDbContext;

        public TeamRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Team> GetAllTeams()
        {
            return _appDbContext.Teams.Include(t => t.League);
        }

        public Team GetTeamById(int teamId)
        {
            var query = _appDbContext.Teams.Include(t => t.League);
            return query.FirstOrDefault(t => t.Id == teamId);
        }

        public void Add(Team team)
        {
            _appDbContext.Teams.Add(team);
        }

        public void Delete(Team team)
        {
            _appDbContext.Teams.Remove(team);
        }

        public void Edit(Team team)
        {
            _appDbContext.Entry(team).State = EntityState.Modified;
        }

        public void Save()
        {
            _appDbContext.SaveChanges();
        }

        public IEnumerable<SelectListItem> GetSelectListItems()
        {
            return from l in _appDbContext.Leagues
                orderby l.Name
                select new SelectListItem
                {
                    Text = l.Name,
                    Value = l.Id.ToString()
                };
        }
    }
}
