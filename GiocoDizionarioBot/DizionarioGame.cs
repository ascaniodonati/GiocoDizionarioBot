using GiocoDizionarioBot.Handlers;
using GiocoDizionarioBot.Models;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace GiocoDizionarioBot
{
    public class DizionarioGame : IDisposable
    {
        public long gameId;
        public long groupId;
        Chat teleGroup;
        List<Player> players = new List<Player>();
        Dictionary<Player, int> rank;

        Timer enteringPlayersTimer;

        public DizionarioGame(Chat group)
        {
            this.groupId = group.Id;
            this.teleGroup = group;

            enteringPlayersTimer = new Timer(CheckJoinedPlayers, null, 0, 30000);
            SendMessageToGroup("Una partita di Gioco Dizionario è stata iniziata su questo gruppo.\nVuoi giocare anche tu?", JoinReplyMarkup());
        }

        private void CheckJoinedPlayers(object? state)
        {
            
        }

        public bool AddPlayer(User user)
        {
            if (!players.Where(p => p.Username == user.Username).Any())
            {
                SendMessageToGroup($"{user.FirstName} ha appena joinato!");
                return true;
            }
            else
            {
                SendMessageToGroup("Non si joina una seconda volta!");
                return false;
            }
        }

        public void Dispose()
        {

        }

        public IReplyMarkup JoinReplyMarkup()
        {
            string joinCallback = $"http://telegram.me/giocodeldizionariobot?start={groupId}";
            InlineKeyboardButton joinButton = InlineKeyboardButton.WithUrl("Join!", joinCallback);
            InlineKeyboardMarkup joinKeyboard = new InlineKeyboardMarkup(joinButton);

            return joinKeyboard;
        }

        public async void SendMessageToGroup(string messageText, IReplyMarkup replyMarkup = null)
        {
            await Bot.SendMessage(groupId, messageText, replyMarkup);
        }

    }
}