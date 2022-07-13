using Telegram.Bot.Types;

namespace DizionarioGameNode
{
    public class DizionarioGame : IDisposable
    {
        private long groupId;
        public DizionarioGame(long groupId)
        {
            this.groupId = groupId;

            SendMessageToGroup("Una partita di Gioco Dizionario è stata iniziata su questo gruppo");
        }

        public void Dispose()
        {
            
        }

        public async void SendMessageToGroup(string messageText)
        {
            await Bot.SendMessage(groupId, messageText);
        }
    }
}