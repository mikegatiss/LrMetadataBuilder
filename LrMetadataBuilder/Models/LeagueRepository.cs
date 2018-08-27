using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LrMetadataBuilder.Models
{
    public class LeagueRepository : ILeagueRepository
    {
        private readonly AppDbContext _appDbContext;

        public LeagueRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<League> GetAllLeagues()
        {
            return _appDbContext.Leagues;
        }

        public League GetLeagueById(int leagueId)
        {
            return _appDbContext.Leagues.FirstOrDefault(l => l.Id == leagueId);
        }

        public void Add(League league)
        {
            _appDbContext.Leagues.Add(league);
        }

        public void Delete(League league)
        {
           _appDbContext.Leagues.Remove(league);
        }

        public void Edit(League league)
        {
            _appDbContext.Entry(league).State = EntityState.Modified;
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
