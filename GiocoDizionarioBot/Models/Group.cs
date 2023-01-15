using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace GiocoDizionarioBot.Models
{
    public class Group
    {
        [Key]
        public long TelegramGroupId { get; set; }
        public string Language { get; set; }

    }
}
