using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LrMetadataBuilder.Models
{
    public interface ILeagueRepository
    {
        IEnumerable<League> GetAllLeagues();
        League GetLeagueById(int leagueId);
        void Add(League league);
        void Delete(League league);
        void Edit(League league);
        void Save();
    }
}
