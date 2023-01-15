using GiocoDizionarioBot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace GiocoDizionarioBot.Handlers
{
    public static class PlayersHandler
    {
        private static GameContext _gameContext;

        public static void AddPlayerFromTelegram(User user)
        {

            if (!TeleUserInDB(user))
            {
                Player playerToAdd = new Player
                {
                    TelegramID = user.Id,
                    Username = user.Username
                };

                Db.Players.Add(playerToAdd);
                Console.WriteLine($"Il giocatore {user.Username} è stato aggiunto al database dei giocatori");
            }
        }

        public static bool TeleUserInDB(User user)
        {
            return Db.Players.Where(p => p.TelegramID == user.Id).Any();
        }

        public static GameContext Db
        {
            get
            {
                if (_gameContext == null)
                    _gameContext = new GameContext();

                return _gameContext;
            }
        }
    }
}
