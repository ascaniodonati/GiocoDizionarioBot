using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiocoDizionarioBot.Settings
{
    public static class DatabaseSettings
    {
        public const string ServerName = "localhost";
        public const string DatabaseName = "giocodizionariobot";

        public static string ConnectionString => $"Server={ServerName};Database={DatabaseName};Trusted_Connection=True;";
    }
}
