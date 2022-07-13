using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiocoDizionarioBot.Models
{
    public class IPlayer
    {
        public long ID { get; set; }
        public long TelegramID { get; set; }
        public string Username { get; set; }
        public int GamesWons { get; set; }
        public int GameLosts { get; set; }
    }

}
