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
        public DbSet<Player> Players { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<GameHistory> GamesHistory { get; set; }

        public GameContext()
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Group>().HasKey(k => k.TelegramGroupId);
            modelBuilder.Entity<Player>().HasKey(k => k.TelegramID);
            modelBuilder.Entity<GameHistory>().HasKey(k => k.GameId);

            base.OnModelCreating(modelBuilder);
        }


        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(DatabaseSettings.ConnectionString);
    }
}
