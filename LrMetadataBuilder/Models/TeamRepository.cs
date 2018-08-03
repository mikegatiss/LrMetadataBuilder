using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            throw new NotImplementedException();
        }

        public void Delete(Team team)
        {
            throw new NotImplementedException();
        }

        public void Edit(Team team)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
