using GiocoDizionarioBot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiocoDizionarioBot.Handlers
{

    public static class GamesHandler
    {
        public static List<DizionarioGame> Games = new List<DizionarioGame>();
        public static List<GameHistory> GamesHistory = new List<GameHistory>();

        public static void AddGame(DizionarioGame game)
        {
            Games.Add(game);
            Console.WriteLine($"E' stato creato il gioco {game.gameId} sul gruppo {game.groupId}");
        }

        public static void EndGame(DizionarioGame game)
        {
            GameHistory gameHistory = new GameHistory
            {
                GameId = game.gameId,
                GroupId = game.groupId
            };
        }

        public static void UpdateDatabase()
        {
            List<GameHistory> gamesToUpdate;

            using (var db = new GameContext())
            {
                gamesToUpdate = GamesHistory.Where(x => db.GamesHistory.Contains(x)).ToList();

                db.GamesHistory.AddRange(gamesToUpdate.ToArray());
                db.SaveChanges();

                Console.WriteLine($"{gamesToUpdate.Count} nuove partite salvati sul database");
            }
        }
    }
}
