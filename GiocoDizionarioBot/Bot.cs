using GiocoDizionarioBot.Attributes;
using GiocoDizionarioBot.Commands;
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

namespace GiocoDizionarioBot
{
    public static class Bot
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(Bot));

        public static void Start()
        {
            log4net.Config.BasicConfigurator.Configure();

            var botClient = new TelegramBotClient(BotSettings.TOKEN_API);
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

            logger.Info("Il bot è stato avviato");
        }

        async static Task HandleErrorAsync(ITelegramBotClient botClient, Exception ex, CancellationToken ct)
        {
            return;
        }

        async static Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cts)
        {
            //Se non è un messaggio non va gestito a prescindere
            if (update.Type != UpdateType.Message) { return; }

            //Controlliamo che sia un messaggio di testo e se sì lo gestiamo
            if (update?.Message?.Type == MessageType.Text)
            {
                string incomingMessage = update?.Message?.Text;

                if (incomingMessage.Trim().StartsWith("/"))
                {
                    await HandleTelegramCommands(update);
                    await botClient.SendTextMessageAsync(update.Message.Chat.Id, "Sono uscito");
                }
            }

            return;
        }

        public async static Task HandleTelegramCommands(Update update)
        {
            MethodInfo[] commandMethods = typeof(GameCommands).GetMethods(BindingFlags.Static | BindingFlags.Public);

            string? incomingMessage = update?.Message?.Text;
            if (incomingMessage == null) { return; }    //?

            string[] messageWithParameters = incomingMessage.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            //Ci sono parametri?
            if (messageWithParameters.Length > 0)
            {
                string inputCommand = messageWithParameters[0].Substring(1);

                foreach(var commandMethod in commandMethods)
                {
                    Command commandAttribute = Attribute.GetCustomAttributes(commandMethod, typeof(Command)).FirstOrDefault() as Command;

                    if (commandAttribute?.Trigger == inputCommand)
                    {
                        commandMethod.Invoke(typeof(GameCommands), new object[] { update });
                    }
                }

                Console.WriteLine("Break");
            }
        }
    }
}
