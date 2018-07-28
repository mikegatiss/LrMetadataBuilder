using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            throw new NotImplementedException();
        }

        public void Delete(League league)
        {
            throw new NotImplementedException();
        }

        public void Edit(League league)
        {
            throw new NotImplementedException();
        }
        public void Update(League league)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
