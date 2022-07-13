using GiocoDizionarioBot.Settings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiocoDizionarioBot.Models
{
    public class GameContext : DbContext
    {
        public DbSet<IPlayer> Players { get; set; }

        public GameContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(DatabaseSettings.ConnectionString);
    }
}
