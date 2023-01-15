using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiocoDizionarioBot.Models
{
    public class Player
    {
        [Key]
        public long TelegramID { get; set; }
        public string Username { get; set; }
    }

}
