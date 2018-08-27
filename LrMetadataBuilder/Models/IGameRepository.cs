using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LrMetadataBuilder.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LrMetadataBuilder.Models
{
    public interface IGameRepository
    {
        IEnumerable<Game> GetAllGames();
        Game GetGameById(int gameId);

        void Add(Game game);
        void Delete(Game game);
        void Edit(Game game);
        void Save();
        void Save(List<GameListViewModel> games);
        IEnumerable<SelectListItem> GetSelectListItems();

        EventGameListViewModel GetGamesByEventId(int eventId);

    }
}