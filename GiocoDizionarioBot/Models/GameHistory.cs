using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiocoDizionarioBot.Models
{
    public class GameHistory
    {
        [Key]
        public long GameId { get; set; }
        public long GroupId { get; set; }
        public List<RankElement> Rank { get; set; }
        public long WinnerId { get; set; }
    }

    public class RankElement
    {
        [Key]
        public long PlayerID { get; set; }
        public int Points { get; set; }
    }
}
