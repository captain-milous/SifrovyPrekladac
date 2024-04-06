using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sifrovy_Prekladac.src.conf
{
    /// <summary>
    /// Třída obsahující konfigurační nastavení pro aplikaci, včetně cest k vstupním a výstupním souborům, logům a seznamu uživatelů.
    /// </summary>
    public class Config
    {
        public string LogFilePath { get; set; }
        public string ListOfUsersFilePath { get; set; }
        public string UserFolder { get; set; }
        /// <summary>
        /// Inicializuje novou instanci třídy Config bez parametrů.
        /// </summary>
        public Config() { }
    }
}
