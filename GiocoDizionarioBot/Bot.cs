using GiocoDizionarioBot.Attributes;
using GiocoDizionarioBot.Commands;
using GiocoDizionarioBot.Helpers;
using GiocoDizionarioBot.Settings;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace GiocoDizionarioBot
{
    public static class Bot
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(Bot));
        private static TelegramBotClient? botClient;

        #region TELEGRAM BOT HANDLING

        public static void Start()
        {
            log4net.Config.BasicConfigurator.Configure();

            botClient = new TelegramBotClient(BotSettings.TOKEN_API);
            CancellationTokenSource cts = new CancellationTokenSource();

            var receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = { }
            };

            botClient.StartReceiving(
                HandleUpdateAsync,
                HandleErrorAsync,
                receiverOptions,
                cts.Token
            );
        }

        async static Task HandleErrorAsync(ITelegramBotClient botClient, Exception ex, CancellationToken ct)
        {
            logger.Error(ex.Message);
        }

        async static Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cts)
        {
            //Controlliamo che sia un messaggio di testo e se sì lo gestiamo
            if (update?.Message?.Type == MessageType.Text)
            {
                string incomingMessage = update?.Message?.Text;

                if (incomingMessage.Trim().StartsWith("/"))
                {
                    await HandleTelegramCommands(update, botClient);
                }
            }

            else if (update?.Type == UpdateType.CallbackQuery)
            {
                await botClient.SendTextMessageAsync(update.CallbackQuery.From.Id, $"Risposta: {update.CallbackQuery.Data}");
            }

            //Se non è un messaggio non va gestito a prescindere
            else return;
        }

        public async static Task HandleTelegramCommands(Update update, ITelegramBotClient botClient)
        {
            MethodInfo[] commandMethods = typeof(GameCommands).GetMethods(BindingFlags.Static | BindingFlags.Public);

            string? incomingMessage = update?.Message?.Text;
            if (incomingMessage == null) { return; }    //?

            string[] messageWithParameters = incomingMessage.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            //Ci sono parametri?
            if (messageWithParameters.Length > 0)
            {
                string inputCommand = messageWithParameters[0].Substring(1);
                string[]? parameters = messageWithParameters.Length > 1 ? messageWithParameters.Skip(1).ToArray() : null;

                foreach (var commandMethod in commandMethods)
                {
                    Command commandAttribute = Attribute.GetCustomAttributes(commandMethod, typeof(Command)).FirstOrDefault() as Command;

                    if (commandAttribute?.Trigger == inputCommand)
                    {
                        if (commandAttribute.OnlyGroup && update.Message.Chat.Type == ChatType.Private)
                        {
                            SendMessage(update.Message.Chat, "Questo comando è solo per i gruppi");
                        }
                        else
                        {
                            commandMethod.Invoke(typeof(GameCommands), new object[] { update, botClient, parameters });
                        }
                    }
                }
            }
        }

        public static async Task SendMessage(ChatId chatId, string messageText, IReplyMarkup replyMarkup = null)
        {
            await botClient.SendTextMessageAsync(chatId, messageText, replyMarkup: replyMarkup);
        }

        #endregion
    }
}
