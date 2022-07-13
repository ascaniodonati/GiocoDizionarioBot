using GiocoDizionarioBot.Attributes;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace GiocoDizionarioBot.Commands
{
    public static class GameCommands
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(GameCommands));

        [Command(Trigger = "startgame", OnlyGroup = true)]
        public static void StartGame(Update update, ITelegramBotClient botClient)
        {
            //Avviamo una partita sul gruppo che ne ha fatto richiesta
            DizionarioGame game = new DizionarioGame(update.Message.Chat);
        }
    }
}
