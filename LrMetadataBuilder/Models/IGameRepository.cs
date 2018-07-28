using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LrMetadataBuilder.Models
{
    public interface IGameRepository
    {
        IEnumerable<Game> GetAllGames();
        Team GetGameById(int gameId);
        void Add(Game game);
        void Delete(Game game);
        void Edit(Game game);
        void Save();
    }
}