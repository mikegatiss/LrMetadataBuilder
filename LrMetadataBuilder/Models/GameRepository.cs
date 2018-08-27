using System;
using System.Collections.Generic;
using System.Linq;
using LrMetadataBuilder.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LrMetadataBuilder.Models
{
    public class GameRepository : IGameRepository
    {
        private readonly AppDbContext _appDbContext;

        public GameRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Game> GetAllGames()
        {
            return _appDbContext.Games;
        }

        public Game GetGameById(int gameId)
        {
            return _appDbContext.Games.FirstOrDefault(g => g.Id == gameId);
        }

        public void Add(Game game)
        {
            _appDbContext.Games.Add(game);
        }

        public void Delete(Game game)
        {
            _appDbContext.Games.Remove(game);
        }

        public void Edit(Game game)
        {
            _appDbContext.Entry(game).State = EntityState.Modified;
        }

        public void Save()
        {
            _appDbContext.SaveChanges();
        }

        
        public void Save(List<GameListViewModel> games)
        {
            if (games != null)
            {
                foreach (var game in games)
                {
                    var record = _appDbContext.Games.Find(game.Id);
                    if (record != null)
                    {
                        record.EventId = game.EventId;
                        //TODO: record.HomeTeam = game.HomeTeam;
                        record.HomeScore = game.HomeScore;
                        //TODO: record.AwayTeam = game.AwayTeam; 
                        record.AwayScore = game.AwayScore;
                        record.WhistleTime = game.WhistleTime;
                    }

                }
            }
        }

        //not sure I'm going to use this as I don't think there's a use case
        //but will leave it for now as it may be required to add something to 
        //build a list of games by event
        public IEnumerable<SelectListItem> GetSelectListItems()
        {
            return from g in _appDbContext.Games
                orderby g.HomeTeam.Name
                   select new SelectListItem
                   {
                       Text = string.Format("{0} vs {1}",g.HomeTeam.Name, g.AwayTeam.Name),
                       Value = g.Id.ToString()
                   };
        }


        public EventGameListViewModel GetGamesByEventId(int eventId)
        {
                var eventRepository = new EventRepository();
                var evnt = eventRepository.GetEventById((int) eventId);
                if (evnt != null)
                {
                    var viewModel = new EventGameListViewModel()
                    {
                        EventId = evnt.Id,
                        EventName = evnt.Name,
                        EventDate = evnt.EventDate,
                        Venue = evnt.Venue//TODO:
                    };
                        return viewModel;
               }

            return null;

        }
    }
}
