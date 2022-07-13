using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiocoDizionarioBot.Helpers
{
    public class LanguageHelper
    {
        public string GetString(string key)
        {
            return File.Exists("Languages/Italian.xml") ? "Sì" : "No";
        }
    }
}
