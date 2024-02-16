using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sifrovy_Prekladac.src.conf
{
    /// <summary>
    /// Statická třída obsahující globální instanci konfigurace a metody pro její načítání.
    /// </summary>
    public static class ConfigHandler
    {
        /// <summary>
        /// Globální instance konfigurace.
        /// </summary>
        public static Config Config = new Config();

        /// <summary>
        /// Načte konfiguraci z externího zdroje a aktualizuje globální instanci konfigurace.
        /// </summary>
        public static void Load()
        {
            Config = ConfigLoader.Load();
        }
    }
}
