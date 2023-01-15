using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiocoDizionarioBot.Models
{
    internal class Rank
    {
        public long GameId { get; set; }
        public long PlayerId { get; set; }
        public int Points { get; set; }     
    }
}
