using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace GiocoDizionarioBot
{
    public class DizionarioGame : IDisposable
    {
        private long gameId;

        private long groupId;
        private Chat teleGroup;

        public DizionarioGame(Chat group)
        {
            this.groupId = group.Id;
            this.teleGroup = group;

            SendMessageToGroup("Una partita di Gioco Dizionario è stata iniziata su questo gruppo.\nVuoi giocare anche tu?", JoinReplyMarkup());
        }

        public void AddPlayer(User user)
        {

        }

        public void Dispose()
        {

        }

        public IReplyMarkup JoinReplyMarkup()
        {
            InlineKeyboardButton button = InlineKeyboardButton.WithCallbackData("join:culo");
            InlineKeyboardMarkup keyboard = new InlineKeyboardMarkup(button);

            return keyboard;
        }

        public async void SendMessageToGroup(string messageText, IReplyMarkup replyMarkup = null)
        {
            await Bot.SendMessage(groupId, messageText, replyMarkup);
        }
    }
}