using GiocoDizionarioBot.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace GiocoDizionarioBot.Commands
{
    public static class GameCommands
    {
        [Command(Trigger = "startgame", OnlyGroup = true)]
        public static void StartGame(Update update)
        {
            Console.WriteLine("Una partita è stata avviata");
        }
    }
}
