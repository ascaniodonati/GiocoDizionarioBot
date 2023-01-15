using GiocoDizionarioBot.Attributes;
using GiocoDizionarioBot.Handlers;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace GiocoDizionarioBot.Commands
{
    public static class GameCommands
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(GameCommands));

        [Command(Trigger = "startgame", OnlyGroup = true)]
        public static void StartGame(Update update, ITelegramBotClient botClient, string[]? parameters)
        {
            //Avviamo una partita sul gruppo che ne ha fatto richiesta
            DizionarioGame game = new DizionarioGame(update.Message.Chat);
            GamesHandler.AddGame(game);
        }

        [Command(Trigger = "start", OnlyGroup = false)]
        public static void JoinToGroup(Update update, ITelegramBotClient botClient, string[]? parameters)
        {
            if (update.Message.Chat.Type == ChatType.Private)
            {
                PlayersHandler.AddPlayerFromTelegram(update.Message.From);
                return;
            }

            //L'utente ha usato "/start" senza che quest'ultimo fosse richiamato dal gruppo
            if (parameters == null)
            {
                botClient.SendTextMessageAsync(update.Message.Chat, "Impossibile entrare nella partita.\nIl comando è incompleto");
                return;
            }

            bool groupNameParsed = long.TryParse(parameters[0], out long groupId);

            if (groupNameParsed)
            {
                DizionarioGame? game = GamesHandler.Games.Where(x => x.groupId == groupId).FirstOrDefault();

                if (game != null)
                {
                    bool addedPlayerResponse = game.AddPlayer(update.Message.From);

                    if (addedPlayerResponse)
                    {
                        botClient.SendTextMessageAsync(update.Message.From.Id, "Hai joinato con successo sul gruppo!");
                    }
                }
                else
                {
                    botClient.SendTextMessageAsync(update.Message.From.Id, "Il gioco in cui stai provando a entrare non è disponibile");
                }
            }
        }
    }
}
